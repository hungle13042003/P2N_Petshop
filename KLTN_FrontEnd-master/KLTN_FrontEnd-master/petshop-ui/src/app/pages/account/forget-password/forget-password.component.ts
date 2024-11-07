import { AccountService } from 'src/app/services/account.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-forget-password',
  templateUrl: './forget-password.component.html',
  styleUrls: ['./forget-password.component.scss']
})
export class ForgetPasswordComponent implements OnInit {

  form: FormGroup;
  loading = false;
  submitted = false;
  message = "";

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private accountService : AccountService) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      Email: ['', [Validators.required, Validators.email,Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$')]],
      //Password: ['', Validators.required],
      //RepeatPassword: ['', Validators.required],
    });
  }

  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }

    this.loading = true;

    this.accountService.forgetPasswordV2({...this.form.value})
        .subscribe((res: any) => {
          if(res.result == 0){
            this.message = res.message;
            this.loading = false;
          }
          else{
            this.message = '';
            this.router.navigate(["login"]);
          }

        }, error => {
            this.loading = false;
        });
  }

}
