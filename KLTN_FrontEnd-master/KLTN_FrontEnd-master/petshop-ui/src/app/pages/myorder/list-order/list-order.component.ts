import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { FormatDateVN } from 'src/app/heplers/utils';
import { Pagination } from 'src/app/models/condition';
import { OrderService } from 'src/app/services/order.service';
import { PaginationService } from 'src/app/services/pagination.service';

@Component({
  selector: 'app-list-order',
  templateUrl: './list-order.component.html',
  styleUrls: ['./list-order.component.scss'],
})
export class ListOrderComponent implements OnInit {

  orders : any;
  loading = false;
  existed: number;

  pagination: Pagination = new Pagination();

  listPage: number[] = [];
  subscriptionPagination: Subscription;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private orderService: OrderService,
    private paginationService: PaginationService) { 
      this.existed = 0;
    }

  ngOnInit(): void {
    this.pagination.Limit = 6;
    this.router.routeReuseStrategy.shouldReuseRoute = () => {
      return false;
    };

    this.GetListHistoryOrder();

    this.subscriptionPagination = this.paginationService.getChangePage().subscribe(page => {
      this.pagination.CurrentPage = page;
      this.GetListHistoryOrder();
    });

    if( this.existed == 1){
      let target = document.getElementById('target');
      this.scroll(target);
    }
    else{
      let target = document.getElementById('target1');
    this.scroll(target);
    }
  }

  GetListHistoryOrder(){
    this.loading = true;

    this.orderService.GetListHistoryOrder(this.pagination).subscribe((res:any) =>{
      if(res.result == 0){
        this.existed = 0;
      }
      else{
        this.orders = res.content.Orders;
        this.pagination = res.content.Pagination;
        this.getNumPage();
        this.existed = 1;
      }
      

      this.loading = false;
    })
  }

  CancelOrder(OrderId: any){
    this.loading = true;

    this.orderService.CancelOrder(OrderId).subscribe((res: any) =>{
      this.GetListHistoryOrder();

      let currentUrl = this.router.url;
      this.router.routeReuseStrategy.shouldReuseRoute = () => {
        return false;
      }
      this.router.onSameUrlNavigation = 'reload';
      this.router.navigate([currentUrl]);
    });
  }

  formatDateVN(input) {
    return FormatDateVN(input);
  }

  scroll(el: HTMLElement) {
    el.scrollIntoView({behavior: 'smooth'});
  }

  previous() {
    let value = this.pagination.CurrentPage - 1;
    if(value < 0) {
      return;
    }
    this.paginationService.changePage(value);

    let target = document.getElementById('target');
    this.scroll(target);
  }

  next() {
    let value = this.pagination.CurrentPage + 1;
    if(value >= this.pagination.TotalPage) {
      return;
    }
    this.paginationService.changePage(value);

    let target = document.getElementById('target');
    this.scroll(target);
  }

  change(number: any) {
    if(this.pagination.CurrentPage == number) {
      return;
    }
    this.paginationService.changePage(number);

    let target = document.getElementById('target');
    this.scroll(target);
  }

  getNumPage(){
    console.log(this.pagination);
    this.listPage = [];
    for(var i = 0; i < 3; i++){
      let value = this.pagination.CurrentPage - 1 + i;
      if(value > -1 && value < this.pagination.TotalPage) {
        this.listPage.push(value);
      }
    }
  }
}
