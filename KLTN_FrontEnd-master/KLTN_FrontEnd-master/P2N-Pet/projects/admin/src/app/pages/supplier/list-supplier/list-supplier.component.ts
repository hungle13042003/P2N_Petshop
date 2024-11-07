import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ChangeEnumToList, FormatDateVN, FormatDaySearch } from '../../../heplers/utils';
import { Pagination } from '../../../models/condition';
import { StatusNormal } from '../../../models/status';
import { SupplierCondition } from '../../../models/supplier';
import { PaginationService } from '../../../services/pagination.service';
import { SupplierService } from '../../../services/supplier.service';

@Component({
  selector: 'app-list-supplier',
  templateUrl: './list-supplier.component.html',
  styleUrls: ['./list-supplier.component.scss']
})
export class ListSupplierComponent implements OnInit {

  loading = false;
  pagination: Pagination = new Pagination();
  listPage: number[] = [];
  supplierCondition: SupplierCondition = new SupplierCondition();
  subscriptionPagination: Subscription;

  supplierStatusText = StatusNormal;
  supplierStatusOptions = []

  public suppliers: any;

  constructor(private supplierService: SupplierService,
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
    this.supplierService.GetListSupplier({
      ...this.pagination,
      ...this.supplierCondition
    }).subscribe((res: any) => {
        this.suppliers = res.content.Suppliers;
        this.pagination = res.content.Pagination;
        this.getNumPage();
        this.loading = false;
      });
  }

  deleteSupplier(Id){
    this.supplierService.DeleteSupplier(Id).subscribe((res: any) => {
      this.getList();
    });
  }

  confirmAlertDelete(Id){
    let textConfirm = 'Bạn muốn xoá nhà cung cấp này ?';

    let isCheck = confirm(textConfirm);

    if(isCheck){
      this.deleteSupplier(Id);
      alert('Xoá nhà cung cấp thành công...');
    }
  }

  buildSelection() {
    ChangeEnumToList(this.supplierStatusText, this.supplierStatusOptions);
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
    this.supplierCondition = new SupplierCondition();
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
