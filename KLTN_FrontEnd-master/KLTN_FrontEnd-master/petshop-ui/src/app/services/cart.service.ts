import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  public cart : Observable<any>;
  
  constructor(private http: HttpClient) { }

  AddToCart(condition: any){
    return this.http.post(`${environment.apiUrl}Cart/AddToCart`, condition);
  }

  UpdateQuantity(condition : any){
    return this.http.post(`${environment.apiUrl}Cart/UpdateQuantityCartItem`, condition);
  }

  DeleteItem( CartItemId: any){
    return this.http.post(`${environment.apiUrl}Cart/DeleteCartItem?CartItemId=${CartItemId}`, null);
  }

  GetListCartItem(){
    return this.http.get(`${environment.apiUrl}Cart/GetListCartItem`);
  }

  getQuantityPetDetailIdAndUserId(PetDetailId){
    return this.http.get(`${environment.apiUrl}Cart/GetQuantityByProductDetailIdAndUser?productDetailId=${PetDetailId}`);
  }
}
