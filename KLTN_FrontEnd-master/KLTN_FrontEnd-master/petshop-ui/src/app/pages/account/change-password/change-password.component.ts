import { UserService } from 'src/app/services/user.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit {

  form: FormGroup;
  loading = false;
  submitted = false;
  message = "";

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private accountService : AccountService,
    private userService: UserService) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      OldPassword: ['', Validators.required],
      NewPassword: ['', Validators.required],
      RepeatNewPassword: ['', Validators.required],
    });
  }

  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }

    this.loading = true;

    this.userService.ChangePassword({...this.form.value})
        .subscribe((res: any) => {
          if(res.result == 0){
            this.message = res.message;
            this.loading = false;
          }
          else{
            this.message = '';
            this.router.navigate(['index']);

            // let currentUrl = this.router.url;
            // this.router.routeReuseStrategy.shouldReuseRoute = () => false;
            // this.router.onSameUrlNavigation = 'reload';
            // this.router.navigate([currentUrl]);
          }

        }, error => {
            this.loading = false;
        });
  }

}
