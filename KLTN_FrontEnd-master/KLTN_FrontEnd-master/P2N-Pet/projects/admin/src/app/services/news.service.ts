import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NewsService {

  constructor(private http: HttpClient) { }

  GetListNews(condition: any){
    return this.http.post(`${environment.apiUrl}ANews/GetListNews`, condition);
  }

  GetOneNews(id: any){
    return this.http.get(`${environment.apiUrl}ANews/GetOneNews?newsId=${id}`)
  }

  CreateNews(condition){
    return this.http.post(`${environment.apiUrl}ANews/CreateNews`, condition);
  }

  UpdateNews(condition){
    return this.http.post(`${environment.apiUrl}ANews/UpdateNews`, condition);
  }

  DeleteNews(Id){
    return this.http.post(`${environment.apiUrl}ANews/DeleteNews?NewsId=${Id}`, '');
  }

  GetNormalTypeNewsSelection(){
    return this.http.get(`${environment.apiUrl}AData/GetNormalTypeNewsSelection`);
  }
}
