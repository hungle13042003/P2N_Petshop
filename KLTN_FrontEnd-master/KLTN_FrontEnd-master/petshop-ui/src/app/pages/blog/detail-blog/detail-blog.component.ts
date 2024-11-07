import { Component, OnInit, Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { FormatDateVN } from 'src/app/heplers/utils';
import { BlogService } from 'src/app/services/blog.service';

@Component({
  selector: 'app-detail-blog',
  templateUrl: './detail-blog.component.html',
  styleUrls: ['./detail-blog.component.scss']
})
export class DetailBlogComponent implements OnInit {

  loading = false;
  blog: any;
  blogId: any;
  constructor(
    private blogService: BlogService,
    private route: ActivatedRoute) { 
    }

  ngOnInit(): void {
    this.blogId = this.route.snapshot.params['id'];

    this.getDetailBlogs();

    let target = document.getElementById('target1');
    this.scroll(target);
  }

  getDetailBlogs(){
    this.loading = true;

    this.blogService.GetDetailNews(this.blogId).subscribe((res: any) =>{
      this.blog = res.content.News;

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
}
