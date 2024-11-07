import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { FormatDateVN, FormatDaySearch } from 'src/app/heplers/utils';
import { Pagination } from 'src/app/models/condition';
import { NewsCondition } from 'src/app/models/new';
import { BlogService } from 'src/app/services/blog.service';
import { PaginationService } from 'src/app/services/pagination.service';

@Component({
  selector: 'app-list-blog',
  templateUrl: './list-blog.component.html',
  styleUrls: ['./list-blog.component.scss']
})
export class ListBlogComponent implements OnInit {

  loading = false;
  blogs: any;

  pagination: Pagination = new Pagination();
  newsCondtion: NewsCondition = new NewsCondition(); 
  listPage: number[] = [];
  subscriptionPagination: Subscription;
  countSub: Subscription;

  constructor(
    private blogService: BlogService,
    private paginationService: PaginationService) { 
      this.pagination.CurrentDate = FormatDaySearch(new Date());
    }

  ngOnInit(): void {
    this.pagination.Limit = 4;

    this.getBlogs();

    this.subscriptionPagination = this.paginationService.getChangePage().subscribe(page => {
      this.pagination.CurrentPage = page;
      this.getBlogs();
    });

    let target = document.getElementById('target1');
    this.scroll(target);
  }

  getBlogs(){
    this.loading = true;

    this.blogService.GetListNews({...this.pagination,...this.newsCondtion}).subscribe((res: any) =>{
      this.blogs = res.content.ListNews;
      this.pagination = res.content.Pagination;
      this.getNumPage();
      this.loading = false;
    }, error =>{
      this.loading = false;
    });
  }

  formatDateVN(input) {
    return FormatDateVN(input);
  }

  scroll(el: HTMLElement) {
    el.scrollIntoView({behavior: 'smooth'});
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
    console.log(this.pagination);
    this.listPage = [];
    for(var i = 0; i < 3; i++){
      let value = this.pagination.CurrentPage - 1 + i;
      if(value > -1 && value < this.pagination.TotalPage) {
        this.listPage.push(value);
      }
    }
  }
}
