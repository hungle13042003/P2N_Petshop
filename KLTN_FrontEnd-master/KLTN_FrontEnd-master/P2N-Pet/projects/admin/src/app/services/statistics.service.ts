import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';



@Injectable({ providedIn: 'root' })
export class StatisticsService {
    public statistics: Observable<any>;

    constructor(private http: HttpClient) { }

    GetStatistics() {
        return this.http.get(`${environment.apiUrl}AStatistics/GetStatistics`);
    }

    GetStatisticsBreed(condition){
        return this.http.post(`${environment.apiUrl}AStatistics/GetStatisticsBreed`, condition);
    }
}
