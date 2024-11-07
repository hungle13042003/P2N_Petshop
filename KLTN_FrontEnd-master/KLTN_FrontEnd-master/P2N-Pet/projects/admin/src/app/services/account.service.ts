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

    this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('p2n-pet-manager')));
    this.user = this.userSubject.asObservable();
  }

  public get userValue(): User {
    return this.userSubject.value;
  }

  login(Email: string, Password: string) {
    return this.http.post(`${environment.apiUrl}Login/Index`, { Email, Password })
      .pipe(map((data: any) => {
        localStorage.setItem('p2n-pet-manager', JSON.stringify({ ...data.content.UserInfo, Token: data.content.Token }));
        this.userSubject.next({ ...data.content.UserInfo, Token: data.content.Token });
        return data;
      }));
  }

  logout() {
    // remove user from local storage and set current user to null
    localStorage.removeItem('p2n-pet-manager');
    this.userSubject.next(null);
    this.router.navigate(['/admin/login']);
  }

  getProfile() {
    return this.http.post(`${environment.apiUrl}User/GetDetailUser`, null);
  }

  EditProfile(condition){
    return this.http.post(`${environment.apiUrl}User/EditProfile`, condition);
  }

  ChangePassword(condition){
    return this.http.post(`${environment.apiUrl}User/ChangePassword`, condition);
  }

  GetListAccount(condition) {
    return this.http.post(`${environment.apiUrl}Admin/GetListAccountUser`, condition);
  }

  GetDetailAccount(Id){
    return this.http.get(`${environment.apiUrl}Admin/GetDetailAccountUser?userId=${Id}`);
  }

  CreateAccountManager(condition) {
      return this.http.post(`${environment.apiUrl}Admin/CreateAccountManager`, condition);
  }

  UpdateAccount(condition){
      return this.http.post(`${environment.apiUrl}Admin/UpdateAccount`, condition);
  }

  DeleteAccount(condition){
      return this.http.post(`${environment.apiUrl}Admin/DeleteAccountUser`, condition);
  }

  BlockUser(condition){
    return this.http.post(`${environment.apiUrl}Admin/BlockUser`, condition);
  }

  OpenBlockUser(condition){
    return this.http.post(`${environment.apiUrl}Admin/OpenBlockUser`, condition);
  }

  GetRoleSelection(){
    return this.http.get(`${environment.apiUrl}Admin/GetRoleSelection`);
  }
}