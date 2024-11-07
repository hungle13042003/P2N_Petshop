import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


@Injectable({providedIn: 'root'})
export class CartCountService {
  private cartCount = new BehaviorSubject<number>(0);

  cartCount$ = this.cartCount.asObservable();
  
  setCartCount(count: number) {
    // encapsulate with logic to set local storage
    localStorage.setItem("cart_count", JSON.stringify(count));
    this.cartCount.next(count);
  }

  constructor(private http: HttpClient) {
    // can check local storage here to initialize?
  }

  getCountQuantity(){
    return this.http.get(`${environment.apiUrl}Cart/GetCountQuantityCartItem`);
  }
}