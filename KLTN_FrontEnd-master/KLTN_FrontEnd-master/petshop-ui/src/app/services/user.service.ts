import { User } from './../models/account';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  user : User
  constructor(private http : HttpClient) { }


  getProfile() {
    return this.http.post(`${environment.apiUrl}User/GetDetailUser`, null);
  }

  EditProfile(condition){
    return this.http.post(`${environment.apiUrl}User/EditProfile`, condition);
  }

  ChangePassword(condition){
    return this.http.post(`${environment.apiUrl}User/ChangePassword`, condition);
  }
}
