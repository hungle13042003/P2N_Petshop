import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';



@Injectable({ providedIn: 'root' })
export class PetDetailService {
    public petDetail: Observable<any>;

    constructor(private http: HttpClient) { }

    GetListPetDetail(condition) {
        return this.http.post(`${environment.apiUrl}AProductDetail/Index`, condition);
    }

    GetDetailPetDetail(Id: string){
        return this.http.get(`${environment.apiUrl}AProductDetail/GetDetailProductDetail?Id=${Id}`);
    }

    CreatePetDetail(condition) {
        return this.http.post(`${environment.apiUrl}AProductDetail/CreateProductDetail`, condition);
    }

    UpdatePetDetail(condition){
        return this.http.post(`${environment.apiUrl}AProductDetail/UpdateProductDetail`, condition);
    }

    DeletePetDetail(Id: string){
        return this.http.post(`${environment.apiUrl}AProductDetail/DeleteProductDetail?Id=${Id}`, null);
    }

    DeletePetDetailImage(petImageId){
        return this.http.post(`${environment.apiUrl}AProductDetail/DeleteProductDetailImage?productImageId=${petImageId}`, null);
    }

    GetNormalAgeSelection(){
        return this.http.get(`${environment.apiUrl}AData/GetNormalAgeSelection`);
    }

    GetNormalColorSelection(){
        return this.http.get(`${environment.apiUrl}AData/GetNormalColorSelection`);
    }

    GetNormalSizeSelection(){
        return this.http.get(`${environment.apiUrl}AData/GetNormalSizeSelection`);
    }

    GetNormalSexSelection(){
        return this.http.get(`${environment.apiUrl}AData/GetNormalSexSelection`);
    }

    GetNormalBreedPetDetailSelection(supplierid){
        return this.http.get(`${environment.apiUrl}AData/GetNormalBreedProductDetailSelection?supplierid=${supplierid}`);
    }

    GetNormalSupplierPetDetailSelection(breedid){
        return this.http.get(`${environment.apiUrl}AData/GetNormalSupplierProductDetailSelection?breedid=${breedid}`);
    }

    GetNormalStatusDetailSelection(){
        return this.http.get(`${environment.apiUrl}AData/GetNormalStatusDetailSelection`);
    }

    GetNormalTypeProductSelection(){
        return this.http.get(`${environment.apiUrl}AData/GetNormalTypeProductSelection`);
    }
    
    GetNormalCategory(){
        return this.http.get(`${environment.apiUrl}AData/GetNormalCategorySelection`);
    }

    GetNormalBrandSelection(){
        return this.http.get(`${environment.apiUrl}AData/GetNormalBrandSelection`);
    }

    GetSupplierPetDetailSelection(categoryid){
        return this.http.get(`${environment.apiUrl}AData/GetSupplierProductDetailSelection?categoryid=${categoryid}`);
    }

    GetNormalCategoryProductDetailSelection(supplierid){
        return this.http.get(`${environment.apiUrl}AData/GetNormalCategoryProductDetailSelection?supplierid=${supplierid}`);
    }
}
