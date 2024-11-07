import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/account';
import { AccountService } from 'src/app/services/account.service';
import { CartService } from 'src/app/services/cart.service';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {

  loading = false;
  user: User;
  cartItemList: any;
  total: number;
  count: number;

  form: FormGroup;
  submitted = false;
  message: string;

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private cartService: CartService,
    private accountService: AccountService,
    private orderService: OrderService) {
      this.total = 0;
      this.count = 0;
      this.message = '';
    }

  ngOnInit(): void {
    this.router.routeReuseStrategy.shouldReuseRoute = () => {
      return false;
    }

    this.form = this.formBuilder.group({
      Name: ['', Validators.required],
      Email: ['', Validators.required],
      Phone: ['', Validators.required],
      Address: ['', Validators.required],
      Note: [''],
      TypePaymentId: 10
    });

    if(this.accountService.user){
      this.accountService.user.subscribe( x =>{
        if(x){
          this.user = x;

          this.f.Name.setValue(this.user.Name);
          this.f.Email.setValue(this.user.Email);
          this.f.Phone.setValue(this.user.Phone);
          this.f.Address.setValue(this.user.Address);
          this.f.Note.setValue("");

          console.log('có userrrrrrr')
        }
        else{
          this.user = new User();
        }
      });
    }

    this.getListCartItem();

    let view = document.getElementById('view-checkout');
    this.scroll(view);
  }

  get f() { return this.form.controls; }

  getListCartItem(){
    this.loading = true;

    this.cartService.GetListCartItem().subscribe((res: any) =>{
      this.cartItemList = res.content.CartItem;
      this.count = res.content.Count;
      this.total = res.content.Total;

      this.loading = false;
    }, error =>{
      this.loading = false;
    });
  }

  CreateOrder(){
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }

    this.loading = true;

    this.orderService.CreateOrder({...this.form.value}).subscribe((res:any) =>{
      if(res.result == 0){
        this.message = res.message;
        let target = document.getElementById('target');
        this.scroll(target);
      }
      else{
        this.message = '';
        /* this.loading = false;
        this.submitted = false; */
        /* this.router.routeReuseStrategy.shouldReuseRoute = () => {
          return false;
        } */
        /* this.router.onSameUrlNavigation = 'reload'; */
        window.alert("Đặt hàng thành công!");

        if( this.f.TypePaymentId.value == 20 || this.f.TypePaymentId.value == 30){
          window.open(res.content.LinkPayment);
        }
        else{
          this.router.navigate([`/index`]);
        }
      }
    }, error => {
        this.loading = false;
        this.submitted = false;
    });
  }

  scroll(el: HTMLElement) {
    el.scrollIntoView({behavior: 'smooth'});
  }

  UpdateTypePayment(typepaymentid){
    this.f.TypePaymentId.setValue(typepaymentid);
  }

}
