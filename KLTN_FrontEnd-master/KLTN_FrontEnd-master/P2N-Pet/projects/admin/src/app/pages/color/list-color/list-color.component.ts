import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ChangeEnumToList, FormatDateVN, FormatDaySearch } from '../../../heplers/utils';
import { ColorCondition } from '../../../models/color';
import { Pagination } from '../../../models/condition';
import { StatusNormal } from '../../../models/status';
import { ColorService } from '../../../services/color.service';
import { PaginationService } from '../../../services/pagination.service';

@Component({
  selector: 'app-list-color',
  templateUrl: './list-color.component.html',
  styleUrls: ['./list-color.component.scss']
})
export class ListColorComponent implements OnInit {

  loading = false;
  pagination: Pagination = new Pagination();
  listPage: number[] = [];
  colorCondition: ColorCondition = new ColorCondition();
  subscriptionPagination: Subscription;

  colorStatusText = StatusNormal;
  colorStatusOptions = []

  public colors: any;

  constructor(private colorService: ColorService,
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
    this.colorService.GetListColor({
      ...this.pagination,
      ...this.colorCondition
    }).subscribe((res: any) => {
        this.colors = res.content.Colors;
        this.pagination = res.content.Pagination;
        this.getNumPage()
        this.loading = false;
      });
  }

  deleteColor(Id){
    this.colorService.DeleteColor(Id).subscribe((res: any) => {
      this.getList();
    });
  }

  confirmAlertDelete(ColorId){
    let textConfirm = 'Bạn muốn xoá màu sắc này ?';

    let isCheck = confirm(textConfirm);

    if(isCheck){
      this.deleteColor(ColorId);
      alert('Xoá màu sắc thành công');
    }
  }

  buildSelection() {
    ChangeEnumToList(this.colorStatusText, this.colorStatusOptions);
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
    this.colorCondition = new ColorCondition();
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
