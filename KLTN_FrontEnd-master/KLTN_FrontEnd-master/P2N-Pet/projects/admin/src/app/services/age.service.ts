import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';



@Injectable({ providedIn: 'root' })
export class AgeService {
    public age: Observable<any>;

    constructor(private http: HttpClient) { }

    GetListAge(condition) {
        return this.http.post(`${environment.apiUrl}AAge/Index`, condition);
    }

    GetDetailAge(Id: string){
        return this.http.get(`${environment.apiUrl}AAge/GetDetailAge?Id=${Id}`);
    }

    CreateAge(condition) {
        return this.http.post(`${environment.apiUrl}AAge/CreateAge`, condition);
    }

    UpdateAge(condition){
        return this.http.post(`${environment.apiUrl}AAge/UpdateAge`, condition);
    }

    DeleteAge(Id: string){
        return this.http.post(`${environment.apiUrl}AAge/DeleteAge?Id=${Id}`, null);
    }
}
