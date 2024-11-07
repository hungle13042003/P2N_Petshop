import { CartUpdateCondition } from './../../models/cart';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/account';
import { AccountService } from 'src/app/services/account.service';
import { CartService } from 'src/app/services/cart.service';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { CartCountService } from 'src/app/services/cartcount.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  loading = false;
  user: User;
  cartItemList: any;
  total: number;
  count: number;
  countSub: Subscription;

  form: FormGroup;
  fQuantity : FormGroup;
  submitted = false;  
  cartUpdateCondition : CartUpdateCondition = new CartUpdateCondition();

  message: string;

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private cartService: CartService,
    private accountService: AccountService,
    private cartCountService: CartCountService) { 
      this.total = 0;
      this.count = 0;
      this.message = '';
      this.countSub = this.cartCountService.cartCount$.subscribe(
        count => {});
    }

  get f() { return this.form.controls; }

  ngOnInit(): void {

    this.router.routeReuseStrategy.shouldReuseRoute = () => {
      return false;
    }
    
    this.checkLogin();

    this.form = this.formBuilder.group({
      Quantity: 1,
    });
    
    this.fQuantity = this.formBuilder.group({
      Quantities : this.formBuilder.array([ new FormControl()])
    });
    
    this.getListCartItem();
    
    /* if(this.user.Id > 0){
      let target = document.getElementById('target');
      this.scroll(target);
    }
    else{
      let target = document.getElementById('target1');
      this.scroll(target);
    } */
  }

  scroll(el: HTMLElement) {
    el.scrollIntoView({behavior: 'smooth'});
  }

  checkLogin(){

    if (this.accountService.user) {
      this.accountService.user.subscribe((x) => {
        if (x) {
          this.user = x;
        } 
        else {
          this.user = new User();
        }
      });
    }
  }

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

  DeleteItem(CartItemId: number){
    this.cartService.DeleteItem(CartItemId).subscribe((res =>{
      this.getListCartItem();

      this.cartCountService.getCountQuantity().subscribe((res: any) =>{
        var countQuantity = res.content.countQuantity;
        
        this.cartCountService.setCartCount(countQuantity);
      });

      let currentUrl = this.router.url;
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
      this.router.onSameUrlNavigation = 'reload';
      this.router.navigate([currentUrl]);
    }))
  }

  changeQuantityItem(CartItemId, ProductDetailId, Quantity){
    this.cartUpdateCondition.CartItemId = CartItemId;
    this.cartUpdateCondition.ProductDetailId = ProductDetailId;
    this.cartUpdateCondition.Quantity = Quantity;

    this.cartService.UpdateQuantity(this.cartUpdateCondition).subscribe(() =>{
      this.getListCartItem();
      this.cartCountService.getCountQuantity().subscribe((res: any) =>{
        var countQuantity = res.content.countQuantity;
        
        this.cartCountService.setCartCount(countQuantity);
      });
    });
  }

}
