import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ChangeEnumToList } from '../../../heplers/utils';
import { StatusNormal } from '../../../models/status';
import { CustomerService } from '../../../services/customer.service';
import { ToastService } from '../../../services/toast.service';

@Component({
  selector: 'app-create-customer',
  templateUrl: './create-customer.component.html',
  styleUrls: ['./create-customer.component.scss']
})
export class CreateCustomerComponent implements OnInit {

  form: FormGroup;
  loading = false;
  submitted = false;

  customerStatusText = StatusNormal;
  customerStatusOptions = [];

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private customerService: CustomerService,
    private toastService: ToastService,) {
    this.buildSelection();
  }

  ngOnInit() {
    this.form = this.formBuilder.group({
      Name: ['', Validators.required],
      Birthday: null,
      Email: ['', Validators.required],
      Phone: ['', Validators.required],
      Address: ['', Validators.required],
      Status: [10, Validators.required]
    });
  }

  get f() { return this.form.controls; }

  ngAfterViewInit() {

  }

  onSubmit() {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }

    this.loading = true;
    this.customerService.CreateCustomer({...this.form.value})
      .subscribe((response: any) => {
        
          this.router.navigate(["admin/list-customer"]);
      }, error => {
        this.loading = false;
      });
  }

  buildSelection() {
    ChangeEnumToList(this.customerStatusText, this.customerStatusOptions);
  }

}
