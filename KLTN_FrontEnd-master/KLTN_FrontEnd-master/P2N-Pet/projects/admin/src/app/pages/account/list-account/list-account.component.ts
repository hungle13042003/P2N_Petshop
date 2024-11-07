import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ChangeEnumToList, FormatDateVN, FormatDaySearch } from '../../../heplers/utils';
import { AccountCondition, RoleSelection } from '../../../models/account';
import { Pagination } from '../../../models/condition';
import { StatusNormal } from '../../../models/status';
import { AccountService } from '../../../services/account.service';
import { PaginationService } from '../../../services/pagination.service';

@Component({
  selector: 'app-list-account',
  templateUrl: './list-account.component.html',
  styleUrls: ['./list-account.component.scss']
})
export class ListAccountComponent implements OnInit {

  loading = false;
  pagination: Pagination = new Pagination();
  listPage: number[] = [];
  accountCondition: AccountCondition = new AccountCondition();
  roleSelection: RoleSelection[];
  subscriptionPagination: Subscription;

  statusaccount: number;

  accountStatusText = StatusNormal;
  accountStatusOptions = [];

  public accounts: any;

  constructor(private accountService: AccountService,
    private paginationService: PaginationService) {
      this.pagination.CurrentDate = FormatDaySearch(new Date());
      this.getNormalRoleSelection();
      this.buildSelection();
      this.statusaccount = 30;
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
    this.accountService.GetListAccount({
      ...this.pagination,
      ...this.accountCondition
    }).subscribe((res: any) => {
        this.accounts = res.content.Users;
        this.pagination = res.content.Pagination;
        this.getNumPage();
        this.loading = false;
      });
  }

  buildSelection() {
    ChangeEnumToList(this.accountStatusText, this.accountStatusOptions);
  }

  formatDateVN(input) {
    return FormatDateVN(input);
  }

  getAccountFollowStatus(statusid){
    if(statusid != 50){
      this.statusaccount = statusid;
      this.accountCondition.RoleId = this.statusaccount;
      this.accountCondition.StatusBlock = 50;
      this.accountCondition.Status = 0;
      this.pagination.CurrentPage = 0;
      this.getList();
    }
    else
    {
      this.statusaccount = statusid;
      this.accountCondition.RoleId = 0;
      this.accountCondition.StatusBlock = 0;
      this.accountCondition.Status = this.statusaccount;
      this.pagination.CurrentPage = 0;
      this.getList();
    }
  }

  blockAccount(accountid){
    this.accountService.BlockUser({UserId: accountid}).subscribe((res: any) => {
      this.getList();
    });
  }

  openAccount(accountid){
    this.accountService.OpenBlockUser({UserId: accountid}).subscribe((res: any)=>{
      this.getList();
    });
  }

  deleteAccount(accountid){
    this.accountService.DeleteAccount({UserId: accountid}).subscribe((res: any) => {
      this.getList();
    });
  }

  confirmAlertAction(action, accountId, msg){
    let textConfirm = '';

    let isCheck = false;

    if(action == 'Delete'){
      textConfirm = 'Bạn muốn xoá tài khoản của '+ msg +' ?';
      isCheck = confirm(textConfirm);

      if(isCheck){
        this.deleteAccount(accountId);
        alert('Xoá tài khoản thành công...');
      }
    }
    else if( action == 'Open'){
      textConfirm = 'Bạn muốn mở khoá tài khoản của '+ msg +' ?';
      isCheck = confirm(textConfirm);

      if(isCheck){
        this.openAccount(accountId);
        alert('Mở khoá tài khoản thành công...');
      }
    }
    else if( action == 'Block'){
      textConfirm = 'Bạn muốn khoá tài khoản của '+ msg +' ?';
      isCheck = confirm(textConfirm);

      if(isCheck){
        this.blockAccount(accountId);
        alert('Khoá tài khoản thành công...');
      }
    }


  }

  getNormalRoleSelection(){
    this.loading = true;
    this.accountService.GetRoleSelection().subscribe((res: any) => {
      this.roleSelection = res.content.roles;
      this.loading = false;
    });
  }

  onSearch() {
    this.pagination.CurrentPage = 0;
    this.pagination.CurrentDate = FormatDaySearch(new Date());
    this.getList();
  }

  clearForm(){
    this.accountCondition = new AccountCondition();

    if(this.statusaccount != 50){
      this.accountCondition.RoleId = this.statusaccount;
      this.accountCondition.StatusBlock = 50;
      this.accountCondition.Status = 0;
    }
    else
    {
      this.accountCondition.RoleId = 0;
      this.accountCondition.StatusBlock = 0;
      this.accountCondition.Status = this.statusaccount;
    }

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
