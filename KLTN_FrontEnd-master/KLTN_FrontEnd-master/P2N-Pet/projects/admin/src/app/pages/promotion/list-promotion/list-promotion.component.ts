import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

import { ChangeEnumToList, FormatDateVN, FormatDaySearch } from '../../../heplers/utils';
import { Pagination } from '../../../models/condition';
import { PromotionCondition } from '../../../models/promotion';
import { StatusNormal } from '../../../models/status';
import { PaginationService } from '../../../services/pagination.service';
import { PromotionService } from '../../../services/promotion.service';

@Component({
  selector: 'app-list-promotion',
  templateUrl: './list-promotion.component.html',
  styleUrls: ['./list-promotion.component.scss']
})
export class ListPromotionComponent implements OnInit {

  loading = false;
  pagination: Pagination = new Pagination();
  listPage: number[] = [];
  promotionCondition: PromotionCondition = new PromotionCondition();
  subscriptionPagination: Subscription;

  promotionStatusText = StatusNormal;
  promotionStatusOptions = []

  public promotions: any;

  constructor(private promotionService: PromotionService,
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
    this.promotionService.GetListPromotion({
      ...this.pagination,
      ...this.promotionCondition
    }).subscribe((res: any) => {
        this.promotions = res.content.Promotions;
        this.pagination = res.content.Pagination;
        this.getNumPage();
        this.loading = false;
      });
  }

  deletePromotion(Id){
    this.promotionService.DeletePromotion(Id).subscribe((res: any) => {
      this.getList();
    });
  }

  confirmAlertDelete(Id){
    let textConfirm = 'Bạn muốn xoá quảng cáo này ?';

    let isCheck = confirm(textConfirm);

    if(isCheck){
      this.deletePromotion(Id);
      alert('Xoá quảng cáo thành công..');
    }
  }

  buildSelection() {
    ChangeEnumToList(this.promotionStatusText, this.promotionStatusOptions);
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
    this.promotionCondition = new PromotionCondition();
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
