import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ChangeEnumToList } from '../../../heplers/utils';
import { StatusContactNormal } from '../../../models/status';
import { ContactService } from '../../../services/contact.service';
import { ToastService } from '../../../services/toast.service';

@Component({
  selector: 'app-create-contact',
  templateUrl: './create-contact.component.html',
  styleUrls: ['./create-contact.component.scss']
})
export class CreateContactComponent implements OnInit {

  form: FormGroup;
  loading = false;
  submitted = false;

  contactStatusText = StatusContactNormal;
  contactStatusOptions = [];

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private contactService: ContactService,
    private toastService: ToastService,) {
    this.buildSelection();
  }

  ngOnInit() {
    this.form = this.formBuilder.group({
      Name: ['', Validators.required],
      Email: ['', Validators.required],
      Phone: ['', Validators.required],
      Subject: ['', Validators.required],
      Content: ['', Validators.required],
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
    this.contactService.CreateContact({...this.form.value})
      .subscribe((response: any) => {
        
          this.router.navigate(["admin/list-contact"]);
      }, error => {
        this.loading = false;
      });
  }

  buildSelection() {
    ChangeEnumToList(this.contactStatusText, this.contactStatusOptions);
  }
}
