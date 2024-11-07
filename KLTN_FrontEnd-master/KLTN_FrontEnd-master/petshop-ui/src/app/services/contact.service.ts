import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  public contact : Observable<any>;
  
  constructor(private http: HttpClient) { }

  CreateContact(condition: any){
    return this.http.post(`${environment.apiUrl}Contact/CreateContact`, condition);
  }
}
