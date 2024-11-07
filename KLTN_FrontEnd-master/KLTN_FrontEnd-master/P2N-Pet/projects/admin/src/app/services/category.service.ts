import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  public categories : Observable<any>;
  constructor(private http: HttpClient) { }

  GetNormalTypeProductSelection(){
    return this.http.get(`${environment.apiUrl}AData/GetNormalTypeProductSelection`);
  }

  GetNormalCategoryRootSelection(){
    return this.http.get(`${environment.apiUrl}AData/GetNormalCategoryRootSelection`);
  }

  CreateCategory(condition){
    return this.http.post(`${environment.apiUrl}ACategory/CreateCategory`, condition);
  }

  UpdateCategory(condition){
    return this.http.post(`${environment.apiUrl}ACategory/UpdateCategory`, condition);
  }

  DeleteCategory(id){
    return this.http.get(`${environment.apiUrl}ACategory/DeleteCategory?categoryid=${id}`);
  }

  GetDetailCategory(id){
    return this.http.get(`${environment.apiUrl}ACategory/GetDetailCategory?Id=${id}`);
  }
  
}
