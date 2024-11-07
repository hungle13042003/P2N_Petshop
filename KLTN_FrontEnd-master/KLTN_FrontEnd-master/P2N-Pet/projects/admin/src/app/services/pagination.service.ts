import { Injectable, TemplateRef } from '@angular/core';
import { Subject } from 'rxjs';
import { Observable } from 'rxjs';

import { Pagination } from '../models/condition';

@Injectable({
  providedIn: 'root'
})
export class PaginationService {

  _pagination = new Subject<Pagination>();
  _paginationChange = new Subject<number>();

  constructor() {
  }

  detect(paginationInput: Pagination) {
    this._pagination.next(paginationInput);
  }

  clear() {
    this._pagination.next(null);
  }

  getPagination(): Observable<Pagination> {
    return this._pagination.asObservable();
  }
  
  changePage(pageNumber: number) {
    this._paginationChange.next(pageNumber);
  }

  getChangePage() {
    return this._paginationChange.asObservable();
  }
}