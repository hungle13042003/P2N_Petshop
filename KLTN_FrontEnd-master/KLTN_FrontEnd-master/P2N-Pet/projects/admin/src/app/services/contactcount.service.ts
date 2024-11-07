import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../../environments/environment';


@Injectable({providedIn: 'root'})
export class ContactCountService {
  private contactCount = new BehaviorSubject<number>(0);

  contactCount$ = this.contactCount.asObservable();
  
  setContactCount(count: number) {
    // encapsulate with logic to set local storage
    localStorage.setItem("contact_count", JSON.stringify(count));
    this.contactCount.next(count);
  }

  constructor(private http: HttpClient) {
    // can check local storage here to initialize?
  }

  GetCountContact(){
    return this.http.get(`${environment.apiUrl}AContact/GetCountContact`);
  }
}