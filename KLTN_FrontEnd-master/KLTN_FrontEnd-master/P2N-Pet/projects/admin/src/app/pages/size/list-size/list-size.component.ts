import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

import { ChangeEnumToList, FormatDateVN, FormatDaySearch } from '../../../heplers/utils';
import { Pagination } from '../../../models/condition';
import { SizeCondition } from '../../../models/size';
import { StatusNormal } from '../../../models/status';
import { PaginationService } from '../../../services/pagination.service';
import { SizeService } from '../../../services/size.service';

@Component({
  selector: 'app-list-size',
  templateUrl: './list-size.component.html',
  styleUrls: ['./list-size.component.scss']
})
export class ListSizeComponent implements OnInit {

  loading = false;
  pagination: Pagination = new Pagination();
  listPage: number[] = [];
  sizeCondition: SizeCondition = new SizeCondition();
  subscriptionPagination: Subscription;

  sizeStatusText = StatusNormal;
  sizeStatusOptions = []

  public sizes: any;

  constructor(private sizeService: SizeService,
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
    this.sizeService.GetListSize({
      ...this.pagination,
      ...this.sizeCondition
    }).subscribe((res: any) => {
        this.sizes = res.content.Sizes;
        this.pagination = res.content.Pagination;
        this.getNumPage();
        this.loading = false;
      });
  }

  deleteSize(Id){
    this.sizeService.DeleteSize(Id).subscribe((res: any) => {
      this.getList();
    });
  }

  confirmAlertDelete(Id){
    let textConfirm = 'Bạn muốn xoá kích cỡ này ?';

    let isCheck = confirm(textConfirm);

    if(isCheck){
      this.deleteSize(Id);
      alert('Xoá kích cỡ thành công...');
    }
  }

  buildSelection() {
    ChangeEnumToList(this.sizeStatusText, this.sizeStatusOptions);
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
    this.sizeCondition = new SizeCondition();
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
