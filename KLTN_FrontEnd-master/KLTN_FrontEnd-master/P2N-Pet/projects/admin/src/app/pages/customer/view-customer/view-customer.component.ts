import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ChangeEnumToList } from '../../../heplers/utils';
import { StatusNormal } from '../../../models/status';
import { CustomerService } from '../../../services/customer.service';

@Component({
  selector: 'app-view-customer',
  templateUrl: './view-customer.component.html',
  styleUrls: ['./view-customer.component.scss']
})
export class ViewCustomerComponent implements OnInit {

  id: string;
  form: FormGroup;
  loading = false;
  submitted = false;
  firstload = false;

  customerStatusText = StatusNormal;
  customerStatusOptions = []

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private customerService: CustomerService,
    private modalService: NgbModal,
    private datePipe: DatePipe) {
    this.buildSelection();
  }

  ngOnInit() {
    this.firstload = true;
    this.id = this.route.snapshot.params['id'];

    this.customerService.GetDetailCustomer(this.id)
    .subscribe((x: any) => {
      var customer = x.content.Customer;
      var birthday = this.datePipe.transform(customer.Birthday, 'yyyy-MM-dd');
      this.f.Name.setValue(customer.Name);
      this.f.Birthday.setValue(birthday);
      this.f.Email.setValue(customer.Email);
      this.f.Phone.setValue(customer.Phone);
      this.f.Address.setValue(customer.Address);
      this.f.Status.setValue(customer.Status);
      this.firstload = false;
    });

    this.form = this.formBuilder.group({
      Name: ['', Validators.required],
      Birthday: null,
      Email: ['', Validators.required],
      Phone: ['', Validators.required],
      Address: ['', Validators.required],
      Status: [10, Validators.required]
    });

    this.form.disable();
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
    this.customerService.UpdateCustomer({ Id: this.id, ...this.form.value })
    .subscribe(() => {
      this.router.navigate(["admin/list-customer"]);
    }, error => {
      this.loading = false;
    });
  }

  buildSelection() {
    ChangeEnumToList(this.customerStatusText, this.customerStatusOptions);
  }

}
