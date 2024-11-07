import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';



@Injectable({ providedIn: 'root' })
export class SupplierService {
    public supplier: Observable<any>;

    constructor(private http: HttpClient) { }

    GetListSupplier(condition) {
        return this.http.post(`${environment.apiUrl}ASupplier/Index`, condition);
    }

    GetDetailSupplier(Id: string){
        return this.http.get(`${environment.apiUrl}ASupplier/GetDetailSupplier?Id=${Id}`);
    }

    CreateSupplier(condition) {
        return this.http.post(`${environment.apiUrl}ASupplier/CreateSupplier`, condition);
    }

    UpdateSupplier(condition){
        return this.http.post(`${environment.apiUrl}ASupplier/UpdateSupplier`, condition);
    }

    DeleteSupplier(Id: string){
        return this.http.post(`${environment.apiUrl}ASupplier/DeleteSupplier?Id=${Id}`, null);
    }
}
