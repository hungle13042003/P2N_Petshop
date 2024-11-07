import { Injectable, TemplateRef } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  toasts: any[] = [];

  // Push new Toasts to array with content and options
  show(textOrTpl: string | TemplateRef<any>, options: any = {}) {
    this.toasts.push({ textOrTpl, ...options });
  }

  // Callback method to remove Toast DOM element from view
  remove(toast:any) {
    this.toasts = this.toasts.filter(t => t !== toast);
  }

  // clear alerts
  clear() {
    this.toasts = [];
  }

  showSuccess(text: string) {
    this.show(text, {
      classname: 'bg-success text-light',
      delay: 2000,
      autohide: true,
    });
  }

  showDefault(text: string) {
    this.show(text, {
      classname: 'bg-default text-light',
      delay: 2000,
      autohide: true,
    });
  }

  showError(text: string) {
    this.show(text, {
      classname: 'bg-danger text-light',
      delay: 2000,
      autohide: true,
    });
  }

  showWarning(text: string) {
    this.show(text, {
      classname: 'bg-warning text-light',
      delay: 2000,
      autohide: true,
    });
  }
}