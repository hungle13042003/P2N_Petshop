import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AccountService } from '../services/account.service';
import { ToastService } from '../services/toast.service';
import { PaginationService } from '../services/pagination.service';



@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private accountService: AccountService,
    private toastService: ToastService,
    private paginationService: PaginationService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      map((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse) {
          if (event.body) {
            if (event.body.Result === 1) {
              this.toastService.clear();
              if(event.body.Content && event.body.Content.Pagination) {
                this.paginationService.detect(event.body.Content.Pagination);
              }
              if (event.body.Message) {
                this.toastService.showSuccess(event.body.Message);
              }
              return event.clone({ body: event.body.Content });
            } else if (event.body.Result === 0) {
              throw (new HttpErrorResponse({ status: 500, statusText: event.body.Message, error: {} }));
            } else {
              return event;
            }
          } else {
            throw (new HttpErrorResponse({ status: 500, statusText: 'Đã có lỗi xảy ra.', error: {} }));
          }
        }
      }),
      catchError(err => {
        if (err.status === 401) {
          // auto logout if 401 response returned from api
          this.accountService.logout();
        }

        const error = err.error.message || err.statusText;
        this.toastService.clear();
        this.toastService.showDefault(error);
        return throwError(error);
      }))
  }
}