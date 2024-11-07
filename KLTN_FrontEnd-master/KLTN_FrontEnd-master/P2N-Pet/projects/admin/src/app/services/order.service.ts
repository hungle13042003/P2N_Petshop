import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';



@Injectable({ providedIn: 'root' })
export class OrderService {
    public color: Observable<any>;

    constructor(private http: HttpClient) { }

    GetListOrder(condition) {
        return this.http.post(`${environment.apiUrl}AOrder/GetListOrder`, condition);
    }

    UpgradeStatusOrder(condition){
        return this.http.post(`${environment.apiUrl}AOrder/UpgradeStatusOrder`, condition);
    }

    CancelOrder(condition){
        return this.http.post(`${environment.apiUrl}AOrder/CancelOrder`, condition);
    }

    GetOrderDetail(orderid){
        return this.http.get(`${environment.apiUrl}AOrder/GetOrderDetail?OrderId=${orderid}`);
    }

    UpdateStatusPayment(orderId, statusPaymentId){
        return this.http.post(`${environment.apiUrl}AOrder/UpdateStatusPayment?orderId=${orderId}&statusPaymentId=${statusPaymentId}`, null);
    }

    UpdateStatusPendingOrder(orderid){
        return this.http.post(`${environment.apiUrl}AOrder/UpdateStatusPendingOrder?orderId=${orderid}`, null);
    }
}
