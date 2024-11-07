import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ChangeEnumToList, FormatDateVN, FormatDaySearch } from '../../../heplers/utils';
import { BrandCondition } from '../../../models/brand';
import { Pagination } from '../../../models/condition';
import { StatusNormal } from '../../../models/status';
import { BrandService } from '../../../services/brand.service';
import { PaginationService } from '../../../services/pagination.service';

@Component({
  selector: 'app-list-brand',
  templateUrl: './list-brand.component.html',
  styleUrls: ['./list-brand.component.scss']
})
export class ListBrandComponent implements OnInit {

  loading = false;
  pagination: Pagination = new Pagination();
  listPage: number[] = [];
  brandCondition: BrandCondition = new BrandCondition();
  subscriptionPagination: Subscription;

  brandStatusText = StatusNormal;
  brandStatusOptions = [];

  public brands: any;

  constructor(private brandService: BrandService,
    private paginationService: PaginationService,) {
      this.pagination.CurrentDate = FormatDaySearch(new Date());
      this.buildSelection();
    }

  ngOnInit(): void {
    this.getListBrand();
    this.subscriptionPagination = this.paginationService.getChangePage().subscribe(pageNumber => {
      this.pagination.CurrentPage = pageNumber;
      this.getListBrand();
    });
  }

  getListBrand(){
    this.loading = true;
    this.brandService.GetListBrand({
      ...this.pagination,
      ...this.brandCondition
    }).subscribe((res:any) =>{
      this.brands = res.content.Brands;
      this.pagination = res.content.Pagination;
      this.getNumPage()
      this.loading = false;
    })
  }

  confirmAlertDelete(brandId, msg){
    let textConfirm = "Bạn muốn xoá chi nhánh tại " + msg + " ?";

    let isCheck = confirm(textConfirm);

    if(isCheck){
      this.deleteBrand(brandId);
      alert('Xoá chi nhánh thành công..')
    }
  }

  deleteBrand(BrandId){
    this.brandService.DeleteBrand(BrandId).subscribe((res : any) => {
      this.getListBrand();
    })
  }

  onSearch() {
    this.pagination.CurrentPage = 0;
    this.pagination.CurrentDate = FormatDaySearch(new Date());
    this.getListBrand();
  }

  clearForm(){
    this.brandCondition = new BrandCondition();
    this.pagination.CurrentPage = 0;
    this.loading = true;
    this.getListBrand();
  }

  buildSelection() {
    ChangeEnumToList(this.brandStatusText, this.brandStatusOptions);
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
