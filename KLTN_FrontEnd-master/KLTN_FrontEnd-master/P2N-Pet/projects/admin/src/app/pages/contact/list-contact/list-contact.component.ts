import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ChangeEnumToList, FormatDateVN, FormatDaySearch, FormatDayVN } from '../../../heplers/utils';
import { Pagination } from '../../../models/condition';
import { ContactCondition } from '../../../models/contact';
import { StatusContactNormal } from '../../../models/status';
import { ContactService } from '../../../services/contact.service';
import { PaginationService } from '../../../services/pagination.service';

@Component({
  selector: 'app-list-contact',
  templateUrl: './list-contact.component.html',
  styleUrls: ['./list-contact.component.scss']
})
export class ListContactComponent implements OnInit {

  loading = false;
  pagination: Pagination = new Pagination();
  listPage: number[] = [];
  contactCondition: ContactCondition = new ContactCondition();
  subscriptionPagination: Subscription;

  contactStatusText = StatusContactNormal;
  contactStatusOptions = []

  public contacts: any;

  constructor(private contactService: ContactService,
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
    this.contactService.GetListContact({
      ...this.pagination,
      ...this.contactCondition
    }).subscribe((res: any) => {
        this.contacts = res.content.Contacts;
        this.pagination = res.content.Pagination;
        this.getNumPage();
        this.loading = false;
      });
  }

  deleteContact(Id){
    this.contactService.DeleteContact(Id).subscribe((res: any) => {
      this.getList();
    });
  }

  confirmAlertDelete(Id){
    let textConfirm = 'Bạn muốn xoá liên hệ này ?';

    let isCheck = confirm(textConfirm);

    if(isCheck){
      this.deleteContact(Id);
      alert('Xoá liên hệ thành công..');
    }
  }

  buildSelection() {
    ChangeEnumToList(this.contactStatusText, this.contactStatusOptions);
  }

  onSearch() {
    this.pagination.CurrentPage = 0;
    this.pagination.CurrentDate = FormatDaySearch(new Date());
    this.getList();
  }

  clearForm(){
    this.contactCondition = new ContactCondition();
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

  formatDayVN(input) {
    return FormatDayVN(input);
  }
}
