import { Component } from '@angular/core';
import { Chart } from 'angular-highcharts';
import { ReceiptService } from '../../services/index';
import { Analysis } from '../../models/index';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
    //#region Private Fields

    private year: number;
    private month: number;
    private hasExpenses: boolean = true;
    private tab: string = 'expenses';
    private analysis: Analysis;
    private summary = {};

    //#endregion

    //#region Init

    constructor(private receiptService: ReceiptService) {
        this.init();
    }

    //#endregion

    //#region Private Methods

    private init(): void {
        let today = new Date();
        this.year = today.getFullYear();
        this.month = today.getMonth() + 1;
        this.getAnalysis();
    }

    private setSummary(tab: string): void {
        this.hasExpenses = tab == 'expenses';
        this.getAnalysis();
    }

    private getAnalysis(): void {
        this.receiptService.getAnalysis(this.year, this.month, this.hasExpenses ? 2 : 1,
            (result: Analysis) => {
                this.analysis = result;
                this.setChart();
            }, () => { });
    }

    private setChart(): void {
        let points = [];
        let balance = this.analysis.Balance;

        this.analysis.Summary.forEach((x) => {
            let percentaje = x.Amount / balance * 100;

            points.push({
                name: `${x.Category.Title} ${percentaje.toFixed(2)}%`,
                y: x.Amount,
                color: x.Category.Color
            });
        });

        this.summary = new Chart({
            chart: {
                plotBackgroundColor: null,
                plotBorderWidth: null,
                plotShadow: false,
                type: 'pie'
            },
            title: {
                text: ''
            },
            tooltip: {
                pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: false
                    },
                    showInLegend: true
                }
            },
            series: [{
                name: 'Categories',
                data: points
            }]
        });
    }

    private formatMoney(money: number): string {
        return (money).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }

    //#endregion
}
