import { Component, ChangeDetectorRef } from '@angular/core';
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
    private summary = [];
    private income: string;
    private expense: string;
    private balance: string;
    private receipts: Receipt[] = [];

    //#endregion

    //#region Init

    constructor(private accountService: AccountService, private receiptService: ReceiptService, private detector: ChangeDetectorRef) {
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
        let month = today.getMonth() + 1;

        this.accountService.getBalance(this.year, month,
            (result: Balance) => {
                this.income = this.formatMoney(result.Income);
                this.expense = this.formatMoney(result.Expense);
                this.balance = this.formatMoney(result.Balance);
                this.setSummary(result);

                this.getDetail(`${this.year}-${month}-${today.getDate()}`);
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

    private getDetail(date: string): void {
        this.receiptService.getAllByDate(date, (result: Receipt[]) => {
            this.receipts = result;
            this.detector.detectChanges();
        }, () => { });
    }

    private setYear(): void {
        let node = $('.mbsc-cal-month');
        let title = node.text();
        node.text(title + ' ' + this.year);
    }

    private setSummary(balance: Balance) {
        balance.Summary.forEach((x) => {
            let date = new Date(x.Date);

            this.summary.push({
                d: new Date(date.getFullYear(), date.getMonth(), date.getDate()),
                text: this.formatMoney(x.Withdrawal),
                color: '#f13f77'
            });
        });
    }

    private formatMoney(money: number): string {
        return (money).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }

    //#endregion
}
