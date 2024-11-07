import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  form: FormGroup;
  loading = false;
  submitted = false;
  returnUrlManager: string;
  returnUrlAdmin: string;

  message: string;
  
  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService) {
      this.message = '';
    }

  ngOnInit() {
    this.form = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    // get return url from route parameters or default to '/'
    this.returnUrlManager = this.route.snapshot.queryParams['returnUrl'] || '/admin/dashboard';
    this.returnUrlAdmin = this.route.snapshot.queryParams['returnUrl'] || '/admin/list-account';
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
    this.accountService.login(this.f.username.value, this.f.password.value)
        .subscribe((res) => {
          this.message = '';

          var user = res.content.UserInfo;

          if(user.Role == 20)
          {
            this.router.navigate([this.returnUrlManager]);
          }
          else if(user.Role == 10)
          {
            this.router.navigate([this.returnUrlAdmin]);
          }
        }, error => {
          this.message = 'Tài khoản hoặc mật khẩu không chính xác';
          
          this.loading = false;
        });
  }
  
  ngOnDestroy() {


  }

}
