import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PromotionService {

  public promotion: Observable<any>;

  constructor( private httpClient : HttpClient) { }

  getPromotion(){
    return this.httpClient.get(`${environment.apiUrl}Promotion/GetPromotion`);
  }
}
