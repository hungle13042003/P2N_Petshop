import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  public blog : Observable<any>;
  
  constructor(private http: HttpClient) { }

  GetListNews(condition: any){
    return this.http.post(`${environment.apiUrl}News/GetListNews`, condition);
  }

  GetDetailNews(newsId: any){
    return this.http.get(`${environment.apiUrl}News/GetDetailNews?newsId=${newsId}`);
  }
}
