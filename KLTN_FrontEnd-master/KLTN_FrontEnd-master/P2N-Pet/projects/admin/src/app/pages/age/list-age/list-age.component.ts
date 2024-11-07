import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

import { ChangeEnumToList, FormatDateVN, FormatDaySearch } from '../../../heplers/utils';
import { AgeCondition } from '../../../models/age';
import { Pagination } from '../../../models/condition';
import { StatusNormal } from '../../../models/status';
import { AgeService } from '../../../services/age.service';
import { PaginationService } from '../../../services/pagination.service';

@Component({
  selector: 'app-list-age',
  templateUrl: './list-age.component.html',
  styleUrls: ['./list-age.component.scss']
})
export class ListAgeComponent implements OnInit {
  loading = false;
  pagination: Pagination = new Pagination();
  listPage: number[] = [];
  ageCondition: AgeCondition = new AgeCondition();
  subscriptionPagination: Subscription;

  ageStatusText = StatusNormal;
  ageStatusOptions = []

  public ages: any;

  constructor(private ageService: AgeService,
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
    this.ageService.GetListAge({
      ...this.pagination,
      ...this.ageCondition
    }).subscribe((res: any) => {
        this.ages = res.content.Ages;
        this.pagination = res.content.Pagination;
        this.getNumPage();
        this.loading = false;
      });
  }

  onSearch() {
    this.pagination.CurrentPage = 0;
    this.pagination.CurrentDate = FormatDaySearch(new Date());
    this.getList();
  }

  clearForm(){
    this.ageCondition = new AgeCondition();
    this.pagination.CurrentPage = 0;
    this.loading = true;
    this.getList();
  }

  deleteAge(Id){
    this.ageService.DeleteAge(Id).subscribe((res: any) => {
      this.getList();
    });
  }

  confirmAlertDelete(AgeId){
    let textConfirm = 'Bạn muốn xoá độ tuổi này ?';

    let isCheck = confirm(textConfirm);

    if(isCheck){
      this.deleteAge(AgeId);
      alert('Xoá độ tuổi thành công');
    }
  }

  buildSelection() {
    ChangeEnumToList(this.ageStatusText, this.ageStatusOptions);
  }

  formatDateVN(input) {
    return FormatDateVN(input);
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
