import { Subscription } from 'rxjs';
import { NewsService } from './../../../services/news.service';
import { Component, OnInit } from '@angular/core';
import { Pagination } from '../../../models/condition';
import { NewsCondition, TypeNewsSelection } from '../../../models/news';
import { StatusNormal } from '../../../models/status';
import { PaginationService } from '../../../services/pagination.service';
import { ChangeEnumToList, FormatDateVN, FormatDaySearch } from '../../../heplers/utils';

type NewType = Subscription;

@Component({
  selector: 'app-list-news',
  templateUrl: './list-news.component.html',
  styleUrls: ['./list-news.component.scss']
})
export class ListNewsComponent implements OnInit {

  loading = false;
  pagination: Pagination = new Pagination();
  listPage: number[] = [];

  newsCondition: NewsCondition = new NewsCondition();
  subscriptionPagination: Subscription;

  newsStatusText = StatusNormal;
  newsStatusOptions = [];

  typeNewsSelection : TypeNewsSelection;

  public newsList: any

  constructor(private newsService: NewsService,
    private paginationService: PaginationService) {
      this.pagination.CurrentDate = FormatDaySearch(new Date());
      this.buildSelection();
      this.getNormalTypeNewsSelection();
    }

  ngOnInit(): void {
    this.getListNews();
    this.subscriptionPagination = this.paginationService.getChangePage().subscribe(pageNumber => {
      this.pagination.CurrentPage = pageNumber;
      this.getListNews();
    });
  }

  getListNews(){
    this.loading = true;
    this.newsService.GetListNews({
      ...this.pagination,
      ...this.newsCondition
    }).subscribe((res:any) =>{
      this.newsList = res.content.ListNews;
      this.pagination = res.content.Pagination;
      this.getNumPage()
      this.loading = false;
    })

    console.log( JSON.stringify(this.newsList));
  }

  getNormalTypeNewsSelection(){
    this.loading = true;
    this.newsService.GetNormalTypeNewsSelection().subscribe( (res: any) =>{
      this.typeNewsSelection = res.content.Selection;
      this.loading = false;
    })
  }

  deleteNews(newsId){
    this.newsService.DeleteNews(newsId).subscribe((res : any) => {
      this.getListNews();
    })
  }

  confirmAlertDelete(Id){
    let textConfirm = 'Bạn muốn xoá bài viết này ?';

    let isCheck = confirm(textConfirm);

    if(isCheck){
      this.deleteNews(Id);
      alert('Xoá bài viết thành công');
    }
  }

  onSearch() {
    this.pagination.CurrentPage = 0;
    this.pagination.CurrentDate = FormatDaySearch(new Date());
    this.getListNews();
  }

  clearForm(){
    this.newsCondition = new NewsCondition();
    this.pagination.CurrentPage = 0;
    this.loading = true;
    this.getListNews();
  }

  buildSelection() {
    ChangeEnumToList(this.newsStatusText, this.newsStatusOptions);
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
