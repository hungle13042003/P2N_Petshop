import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';



@Injectable({ providedIn: 'root' })
export class SizeService {
    public size: Observable<any>;

    constructor(private http: HttpClient) { }

    GetListSize(condition) {
        return this.http.post(`${environment.apiUrl}ASize/Index`, condition);
    }

    GetDetailSize(Id: string){
        return this.http.get(`${environment.apiUrl}ASize/GetDetailSize?Id=${Id}`);
    }

    CreateSize(condition) {
        return this.http.post(`${environment.apiUrl}ASize/CreateSize`, condition);
    }

    UpdateSize(condition){
        return this.http.post(`${environment.apiUrl}ASize/UpdateSize`, condition);
    }

    DeleteSize(Id: string){
        return this.http.post(`${environment.apiUrl}ASize/DeleteSize?Id=${Id}`, null);
    }
}
