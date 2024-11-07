import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';



@Injectable({ providedIn: 'root' })
export class PetService {
    public pet: Observable<any>;

    constructor(private http: HttpClient) { }

    GetListPet(condition) {
        return this.http.post(`${environment.apiUrl}AProduct/Index`, condition);
    }

    GetDetailPet(Id: string){
        return this.http.get(`${environment.apiUrl}AProduct/GetDetailProduct?Id=${Id}`);
    }

    CreatePet(condition) {
        return this.http.post(`${environment.apiUrl}AProduct/CreateProduct`, condition);
    }

    UpdatePet(condition){
        return this.http.post(`${environment.apiUrl}AProduct/UpdateProduct`, condition);
    }

    DeletePet(Id: string){
        return this.http.post(`${environment.apiUrl}AProduct/DeleteProduct?Id=${Id}`, null);
    }

    GetNormalBreed(){
        return this.http.get(`${environment.apiUrl}AData/GetNormalBreedSelection`);
    }

    GetNormalSupplier(){
        return this.http.get(`${environment.apiUrl}AData/GetNormalSupplierSelection`);
    }

    GetNormalCategory(){
        return this.http.get(`${environment.apiUrl}AData/GetNormalCategorySelection`);
    }

    GetNormalTypeProductSelection(){
        return this.http.get(`${environment.apiUrl}AData/GetNormalTypeProductSelection`);
    }
}
