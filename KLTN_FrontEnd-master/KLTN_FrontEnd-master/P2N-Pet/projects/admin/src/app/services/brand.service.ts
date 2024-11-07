import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BrandService {

  public brand : Observable<any>;

  constructor(private http: HttpClient) { }

  GetListBrand(condition) {
    return this.http.post(`${environment.apiUrl}ABrand/GetListBrand`, condition);
  }

  GetDetailBrand(brandId){
    return this.http.get(`${environment.apiUrl}ABrand/GetDetailBrand?brandid=${brandId}`);
  }

  CreateBrand(condition){
    return this.http.post(`${environment.apiUrl}ABrand/CreateBrandPet`, condition);
  }

  UpdateBrand(condition){
    return this.http.post(`${environment.apiUrl}ABrand/UpdateBrandPet`, condition);
  }

  DeleteBrand(brandId){
    return this.http.get(`${environment.apiUrl}ABrand/DeleteBrandPet?brandid=${brandId}`);
  }

  GetListProductDetailSelection(){
    return this.http.get(`${environment.apiUrl}AData/GetNormalProductDetailSelection`);
  }
}
