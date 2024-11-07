import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  public category : Observable<any>;

  constructor(private httpClient : HttpClient) { }

  getListBreedParent(){
    return this.httpClient.get(`${environment.apiUrl}Category/GetListBreedParent`);
  }

  getListBreedChild(id: any){
    return this.httpClient.get(`${environment.apiUrl}Category/GetListBreedChild?breeid=${id}`);
  }

  getListSupplierChild(){
    return this.httpClient.get(`${environment.apiUrl}Category/GetListSupplierChild`)
  }

  getListBreedAll(){
    return this.httpClient.get(`${environment.apiUrl}Category/GetListBreedAll`);
  }

  getListCategoryAll(){
    return this.httpClient.get(`${environment.apiUrl}Category/GetListCategoryAll`);
  }

  getListTypeProduct(){
    return this.httpClient.get(`${environment.apiUrl}Category/GetNormalTypeProductSelection`);
  }
}
