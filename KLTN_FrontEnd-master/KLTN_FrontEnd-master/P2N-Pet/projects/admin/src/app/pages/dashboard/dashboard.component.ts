import { Component, OnInit } from '@angular/core';
import Chart from 'chart.js';
import { Subscription } from 'rxjs';
import { FormatDaySearch } from '../../heplers/utils';
import { ChartModel } from '../../models/chart';
import { Pagination } from '../../models/condition';
import { PaginationService } from '../../services/pagination.service';
import { StatisticsService } from '../../services/statistics.service';

// core components
import {
  chartOptions,
  parseOptions,
  chartExample1,
  chartExample2
} from "../../variables/charts";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  public datasets: any;
  public data: any;
  public salesChart;
  public clicked: boolean = true;
  public clicked1: boolean = false;

  statistics: any;
  statisticsBreed: any;
  pagination: Pagination = new Pagination();
  listPage: number[] = [];
  chartmodel: ChartModel = new ChartModel();

  subscriptionPagination: Subscription;

  constructor(private statisticsService: StatisticsService,
    private paginationService: PaginationService) { 
    this.pagination.CurrentDate = FormatDaySearch(new Date());
  }

  ngOnInit() {
    this.datasets = [
      [],
      [],
      []
    ];
    
    this.getStatistics();

    this.getList();
    this.subscriptionPagination = this.paginationService.getChangePage().subscribe(pagenumber => {
      this.pagination.CurrentPage = pagenumber;
      this.getList();
    });

    this.data = this.datasets[0];

    this.chartmodel.labels = this.datasets[2];
 //   this.chartmodel.datasets[0] = { label: 'Tiền', data: this.datasets[1] };


    var chartOrders = document.getElementById('chart-orders');

    parseOptions(Chart, chartOptions());


    var ordersChart = new Chart(chartOrders, {
      type: 'bar',
      options: chartExample2.options,
      data: chartExample2.data
    });

    var chartSales = document.getElementById('chart-sales');

    this.salesChart = new Chart(chartSales, {
			type: 'line',
			options: chartExample1.options,
			data: this.chartmodel
		});
  }


  public updateOptions() {
    this.salesChart.data.datasets[0].data = this.data;
    this.salesChart.update();
  }

  getStatistics() {
    this.statisticsService.GetStatistics().subscribe((res: any) => {
        this.statistics = res.content.Statistics;
      });
  }

  getList() {
    this.statisticsService.GetStatisticsBreed({
      ...this.pagination
    }).subscribe((res: any) => {
        this.statisticsBreed = res.content.StatisticsBreed;
        this.pagination = res.content.Pagination;
        this.getNumPage();
      });
  }

  ngOnDestroy() {
    this.subscriptionPagination.unsubscribe();
  }

  previous() {
    let value = this.pagination.CurrentPage - 1;
    if(value < 0) {
      return;
    }
    this.paginationService.changePage(value);
  }

  next() {
    let value = this.pagination.CurrentPage + 1;
    if(value >= this.pagination.TotalPage) {
      return;
    }
    this.paginationService.changePage(value);
  }

  change(number: any) {
    if(this.pagination.CurrentPage == number) {
      return;
    }
    this.paginationService.changePage(number);
  }

  getNumPage(){
    this.listPage = [];
    for(var i = 0; i < 3; i++){
      let value = this.pagination.CurrentPage - 1 + i;
      if(value > -1 && value < this.pagination.TotalPage) {
        this.listPage.push(value);
      }
    }
  }
}
