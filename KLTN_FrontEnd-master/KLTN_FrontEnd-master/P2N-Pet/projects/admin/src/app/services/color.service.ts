import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';



@Injectable({ providedIn: 'root' })
export class ColorService {
    public color: Observable<any>;

    constructor(private http: HttpClient) { }

    GetListColor(condition) {
        return this.http.post(`${environment.apiUrl}AColor/Index`, condition);
    }

    GetDetailColor(Id: string){
        return this.http.get(`${environment.apiUrl}AColor/GetDetailColor?Id=${Id}`);
    }

    CreateColor(condition) {
        return this.http.post(`${environment.apiUrl}AColor/CreateColor`, condition);
    }

    UpdateColor(condition){
        return this.http.post(`${environment.apiUrl}AColor/UpdateColor`, condition);
    }

    DeleteColor(Id: string){
        return this.http.post(`${environment.apiUrl}AColor/DeleteColor?Id=${Id}`, null);
    }
}
