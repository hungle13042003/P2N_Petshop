import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../../environments/environment';


@Injectable({providedIn: 'root'})
export class OrderCountService {
  private orderCount = new BehaviorSubject<number>(0);

  orderCount$ = this.orderCount.asObservable();
  
  setOrderCount(count: number) {
    // encapsulate with logic to set local storage
    localStorage.setItem("order_count", JSON.stringify(count));
    this.orderCount.next(count);
  }

  constructor(private http: HttpClient) {
    // can check local storage here to initialize?
  }

  GetCountPending(){
    return this.http.get(`${environment.apiUrl}AOrder/GetCountPending`);
  }
}