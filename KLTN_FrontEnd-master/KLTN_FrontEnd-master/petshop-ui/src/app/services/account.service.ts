import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { User } from '../models/account';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class AccountService {
  private userSubject: BehaviorSubject<User>;
  public user: Observable<User>;

  constructor(private router: Router,
    private http: HttpClient) {

    this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem("pet-shop-ui") || "{}"));
    this.user = this.userSubject.asObservable();
  }

  public get userValue(): User {
    return this.userSubject.value;
  }

  login(Email: string, Password: string) {
    return this.http.post(`${environment.apiUrl}Login/Index`, { Email, Password })
      .pipe(map((data: any) => {
        localStorage.setItem('pet-shop-ui', JSON.stringify({ ...data.content.UserInfo, Token: data.content.Token }));
        this.userSubject.next({ ...data.content.UserInfo, Token: data.content.Token });
        return data;
      }));
  }

  register(condition){
    return this.http.post(`${environment.apiUrl}Login/RegisterUser`, condition);
  }

  logout() {
    // remove user from local storage and set current user to null
    localStorage.removeItem('pet-shop-ui');
    this.userSubject.next(null);
    this.router.navigate(['/index']);
  }

  forgetPassword(condition){
    return this.http.post(`${environment.apiUrl}Login/ForgetPassword`, condition);
  }

  forgetPasswordV2(condition){
    return this.http.post(`${environment.apiUrl}Login/ForgotPasswordV2`, condition);
  }
}
