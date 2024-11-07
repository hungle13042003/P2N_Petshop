import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ChangeEnumToList, FormatDateVN, FormatDaySearch } from '../../../heplers/utils';
import { Pagination } from '../../../models/condition';
import { CustomerCondition } from '../../../models/customer';
import { StatusNormal } from '../../../models/status';
import { CustomerService } from '../../../services/customer.service';
import { PaginationService } from '../../../services/pagination.service';

@Component({
  selector: 'app-list-customer',
  templateUrl: './list-customer.component.html',
  styleUrls: ['./list-customer.component.scss']
})
export class ListCustomerComponent implements OnInit {

  loading = false;
  pagination: Pagination = new Pagination();
  listPage: number[] = [];
  customerCondition: CustomerCondition = new CustomerCondition();
  subscriptionPagination: Subscription;

  customerStatusText = StatusNormal;
  customerStatusOptions = []

  public customers: any;

  constructor(private customerService: CustomerService,
    private paginationService: PaginationService) { 
      this.pagination.CurrentDate = FormatDaySearch(new Date());
      this.buildSelection();
  }

  ngOnInit(): void {
    this.getList();
    this.subscriptionPagination = this.paginationService.getChangePage().subscribe(pagenumber => {
      this.pagination.CurrentPage = pagenumber;
      this.getList();
    });
  }

  getList() {
    this.loading = true;
    this.customerService.GetListCustomer({
      ...this.pagination,
      ...this.customerCondition
    }).subscribe((res: any) => {
        this.customers = res.content.Customers;
        this.pagination = res.content.Pagination;
        this.getNumPage();
        this.loading = false;
      });
  }

  deleteCustomer(Id){
    this.customerService.DeleteCustomer(Id).subscribe((res: any) => {
      this.getList();
    });
  }

  buildSelection() {
    ChangeEnumToList(this.customerStatusText, this.customerStatusOptions);
  }

  formatDateVN(input) {
    return FormatDateVN(input);
  }

  onSearch() {
    this.pagination.CurrentPage = 0;
    this.pagination.CurrentDate = FormatDaySearch(new Date());
    this.getList();
  }
    
  clearForm(){
    this.customerCondition = new CustomerCondition();
    this.pagination.CurrentPage = 0;
    this.loading = true;
    this.getList();
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
