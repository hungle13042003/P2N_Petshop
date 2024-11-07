import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';



@Injectable({ providedIn: 'root' })
export class BreedService {
    public breed: Observable<any>;

    constructor(private http: HttpClient) { }

    GetListBreed(condition) {
        return this.http.post(`${environment.apiUrl}ABreed/Index`, condition);
    }

    GetDetailBreed(Id: string){
        return this.http.get(`${environment.apiUrl}ABreed/GetDetailBreed?Id=${Id}`);
    }

    CreateBreed(condition) {
        return this.http.post(`${environment.apiUrl}ABreed/CreateBreed`, condition);
    }

    UpdateBreed(condition){
        return this.http.post(`${environment.apiUrl}ABreed/UpdateBreed`, condition);
    }

    DeleteBreed(Id: string){
        return this.http.post(`${environment.apiUrl}ABreed/DeleteBreed?Id=${Id}`, null);
    }

    GetNormalBreedDefault(){
        return this.http.get(`${environment.apiUrl}AData/GetNormalBreedDefault`);
    }
    GetListCategory(condition){
        return this.http.post(`${environment.apiUrl}ACategory/GetListCategory`, condition);
    }

    GetNormalTypeProductSelection(){
        return this.http.get(`${environment.apiUrl}AData/GetNormalTypeProductSelection`);
    }

    GetNormalCategoryRootSelection(){
        return this.http.get(`${environment.apiUrl}AData/GetNormalCategoryRootSelection`);
    }
}
