import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';



@Injectable({ providedIn: 'root' })
export class CustomerService {
    public customer: Observable<any>;

    constructor(private http: HttpClient) { }

    GetListCustomer(condition) {
        return this.http.post(`${environment.apiUrl}ACustomer/Index`, condition);
    }

    GetDetailCustomer(Id: string){
        return this.http.get(`${environment.apiUrl}ACustomer/GetDetailCustomer?Id=${Id}`);
    }

    CreateCustomer(condition) {
        return this.http.post(`${environment.apiUrl}ACustomer/CreateCustomer`, condition);
    }

    UpdateCustomer(condition){
        return this.http.post(`${environment.apiUrl}ACustomer/UpdateCustomer`, condition);
    }

    DeleteCustomer(Id: string){
        return this.http.post(`${environment.apiUrl}ACustomer/DeleteCustomer?Id=${Id}`, null);
    }
}
