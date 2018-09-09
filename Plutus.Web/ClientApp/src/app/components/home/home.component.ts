import { Component } from '@angular/core';
import { Balance, Receipt } from '../../models/index';
import { AccountService, ReceiptService } from '../../services/index';
import { mobiscroll } from '@mobiscroll/angular';
import * as $ from 'jquery';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    //#region Private Fields

    private year: number;
    private income: string;
    private expense: string;
    private balance: string;
    private receipts: Receipt[] = [];

    //#endregion

    //#region Init

    constructor(private accountService: AccountService, private receiptService: ReceiptService) {
        mobiscroll.settings = {
            theme: 'ios',
            onPosition: () => {
                setTimeout(() => {
                    this.setYear();
                }, 5);
            }
        };

        this.init();
    }

    //#endregion

    //#region Private Methods

    private init(): void {
        let today = new Date();
        this.year = today.getFullYear();

        this.accountService.getBalance(this.year, today.getMonth() + 1,
            (result: Balance) => {
                this.income = this.formatMoney(result.Income);
                this.expense = this.formatMoney(result.Expense);
                this.balance = this.formatMoney(result.Balance);
            }, () => { });
    }

    private setDay(event: any): void {
        let date = event.valueText.split('/');
        this.getDetail(`${date[2]}-${date[0]}-${date[1]}`);
    }

    private changeMonth(event: any): void {
        this.year = event.year;
        this.setYear();
    }

    private formatMoney(money: number): string {
        return (money).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }

    private getDetail(date: string): void {
        this.receiptService.getAllByDate(date, (result: Receipt[]) => {
            this.receipts = result;
        }, () => { });
    }

    private setYear(): void {
        let node = $('.mbsc-cal-month');
        let title = node.text();
        node.text(title + ' ' + this.year);
    }

    //#endregion
}
