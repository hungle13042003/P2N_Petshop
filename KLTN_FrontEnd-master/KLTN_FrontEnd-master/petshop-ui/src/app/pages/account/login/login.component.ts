import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AccountService } from 'src/app/services/account.service';
import { CartCountService } from 'src/app/services/cartcount.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  form: FormGroup;
  loading = false;
  submitted = false;
  returnUrlIndex: string;
  countSub: Subscription;

  message = "";

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService,
    private cartCountService: CartCountService) { 
      this.countSub = this.cartCountService.cartCount$.subscribe(
        count => {
        });
      
    }

  ngOnInit(): void {
    
    let target = document.getElementById('target');
    this.scroll(target);

    this.form = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
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
    this.accountService.login(this.f.username.value, this.f.password.value)
        .subscribe((res: any) => {
          if( res.result == 0){
            this.message = res.message;
          }
          else{
            this.message = "";
            var user = res.content.UserInfo;

            this.cartCountService.getCountQuantity().subscribe((res: any) =>{
              var countQuantity = res.content.countQuantity;
    
              this.cartCountService.setCartCount(countQuantity);
            });
    
            this.router.navigate(['index']);
            //this.refresh();
          }
          
        }, error => {
          this.message = 'Tài khoản hoặc mật khẩu không chính xác';
          this.loading = false;
        });
  }

  refresh(){
    window.location.reload();
  }

  scroll(el: HTMLElement) {
    el.scrollIntoView({behavior: 'smooth'});
  }

}
