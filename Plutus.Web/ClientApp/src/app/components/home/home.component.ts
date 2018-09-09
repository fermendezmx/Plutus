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
    private total: string;
    private income: string;
    private expense: string;
    private balance: Balance;
    private receipts: Receipt[] = [];
    private hasExpenses: boolean = true;

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

        this.getBalance(month, () => {
            this.getDetail(`${this.year}-${month}-${today.getDate()}`);
        });
    }

    private setDay(event: any): void {
        let date = event.valueText.split('/');
        this.getDetail(`${date[2]}-${date[0]}-${date[1]}`);
    }

    private changeMonth(event: any): void {
        this.year = event.year;
        this.summary = [];
        this.setYear();

        this.getBalance(event.month + 1, () => {
            this.detector.detectChanges();
        });
    }

    private getBalance(month: number, onSuccess: () => void): void {
        this.accountService.getBalance(this.year, month,
            (result: Balance) => {
                this.balance = result;
                this.income = this.formatMoney(result.Income);
                this.expense = this.formatMoney(result.Expense);
                this.total = this.formatMoney(result.Balance);
                this.setSummary();
                onSuccess();
            }, () => { });
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

    private setCalendar(showExpenses: boolean) : void {
        this.hasExpenses = showExpenses;
        this.summary = [];
        this.setSummary();
    }

    private setSummary() : void {
        this.balance.Summary.forEach((x) => {
            let date = new Date(x.Date);
            let year = date.getFullYear();
            let month = date.getMonth();
            let day = date.getDate();

            if (this.hasExpenses && x.Withdrawal) {
                this.summary.push({
                    d: new Date(year, month, day),
                    text: this.formatMoney(x.Withdrawal),
                    color: '#f13f77'
                });
            }

            if (!this.hasExpenses && x.Deposit) {
                this.summary.push({
                    d: new Date(year, month, day),
                    text: this.formatMoney(x.Deposit),
                    color: '#8dec7d'
                });
            }
        });
    }

    private formatMoney(money: number): string {
        return (money).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }

    //#endregion
}
