import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';



@Injectable({ providedIn: 'root' })
export class ContactService {
    public contact: Observable<any>;

    constructor(private http: HttpClient) { }

    GetListContact(condition) {
        return this.http.post(`${environment.apiUrl}AContact/Index`, condition);
    }

    GetDetailContact(Id: string){
        return this.http.get(`${environment.apiUrl}AContact/GetDetailContact?Id=${Id}`);
    }

    CreateContact(condition) {
        return this.http.post(`${environment.apiUrl}AContact/CreateContact`, condition);
    }

    UpdateContact(condition){
        return this.http.post(`${environment.apiUrl}AContact/UpdateContact`, condition);
    }

    DeleteContact(Id: string){
        return this.http.post(`${environment.apiUrl}AContact/DeleteContact?Id=${Id}`, null);
    }
}
