import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactService } from 'src/app/services/contact.service';

@Component({
  selector: 'app-mailer',
  templateUrl: './mailer.component.html',
  styleUrls: ['./mailer.component.scss']
})
export class MailerComponent implements OnInit {

  form: FormGroup;
  loading = false;
  submitted = false;

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private contactService: ContactService,) {
  }

  ngOnInit() {
    this.form = this.formBuilder.group({
      Name: ['', Validators.required],
      Phone: ['', Validators.required],
      Email: ['', [Validators.required, Validators.email,Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$')]],
      Subject: ['', Validators.required],
      Content: ['', Validators.required]
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
        
          this.router.navigate(["index"]);
      }, error => {
        this.loading = false;
      });
  }
}
