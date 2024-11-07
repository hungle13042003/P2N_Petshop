import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';



@Injectable({ providedIn: 'root' })
export class PromotionService {
    public promotion: Observable<any>;

    constructor(private http: HttpClient) { }

    GetListPromotion(condition) {
        return this.http.post(`${environment.apiUrl}APromotion/Index`, condition);
    }

    GetDetailPromotion(Id: string){
        return this.http.get(`${environment.apiUrl}APromotion/GetDetailPromotion?Id=${Id}`);
    }

    CreatePromotion(condition) {
        return this.http.post(`${environment.apiUrl}APromotion/CreatePromotion`, condition);
    }

    UpdatePromotion(condition){
        return this.http.post(`${environment.apiUrl}APromotion/UpdatePromotion`, condition);
    }

    DeletePromotion(Id: string){
        return this.http.post(`${environment.apiUrl}APromotion/DeletePromotion?Id=${Id}`, null);
    }
}
