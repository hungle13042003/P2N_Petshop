import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AccountService } from '../../../services/account.service';

@Component({
  selector: 'app-password-user',
  templateUrl: './password-user.component.html',
  styleUrls: ['./password-user.component.scss']
})
export class PasswordUserComponent implements OnInit {

  id: string;
  form: FormGroup;
  loading = false;
  submitted = false;
  firstload = false;

  message: string;

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService,
    private modalService: NgbModal) {
      this.message = '';
  }

  ngOnInit() {
    this.firstload = true;

    this.form = this.formBuilder.group({
      oldpassword: ['', Validators.required],
      newpassword: ['', Validators.required]
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
    this.accountService.ChangePassword({ ...this.form.value })
    .subscribe((res: any) => {
      if(res.result == 0){
        this.message = res.message;
        this.loading = false;
      }
      else{
        this.message = '';
        this.accountService.getProfile()
        .subscribe((x: any) => {
          var account = x.content.user;
          if(account.RoleId == 20){
             this.router.navigate(["admin/dashboard"]);
          }
          else{
            this.router.navigate(["admin/list-account"]);
          }
        });
      }
    }, error => {
      this.loading = false;
    });
  }

}
