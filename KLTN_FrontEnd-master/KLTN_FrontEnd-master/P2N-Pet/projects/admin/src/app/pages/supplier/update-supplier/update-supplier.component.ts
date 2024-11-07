import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ChangeEnumToList } from '../../../heplers/utils';
import { StatusNormal } from '../../../models/status';
import { SupplierService } from '../../../services/supplier.service';

@Component({
  selector: 'app-update-supplier',
  templateUrl: './update-supplier.component.html',
  styleUrls: ['./update-supplier.component.scss']
})
export class UpdateSupplierComponent implements OnInit {

  id: string;
  form: FormGroup;
  loading = false;
  submitted = false;
  firstload = false;

  supplierStatusText = StatusNormal;
  supplierStatusOptions = []

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private supplierService: SupplierService,
    private modalService: NgbModal) {
    this.buildSelection();
  }

  ngOnInit() {
    this.firstload = true;
    this.id = this.route.snapshot.params['id'];

    this.supplierService.GetDetailSupplier(this.id)
    .subscribe((x: any) => {
      var supplier = x.content.Supplier;

      this.f.Name.setValue(supplier.Name);
      this.f.Email.setValue(supplier.Email);
      this.f.Phone.setValue(supplier.Phone);
      this.f.Address.setValue(supplier.Address);
      this.f.Status.setValue(supplier.Status);
      this.firstload = false;
    });

    this.form = this.formBuilder.group({
      Name: ['', Validators.required],
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
    this.supplierService.UpdateSupplier({ Id: this.id, ...this.form.value })
    .subscribe(() => {
      this.router.navigate(["admin/list-supplier"]);
    }, error => {
      this.loading = false;
    });
  }

  buildSelection() {
    ChangeEnumToList(this.supplierStatusText, this.supplierStatusOptions);
  }

}
