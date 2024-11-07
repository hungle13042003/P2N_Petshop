import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { FormatDaySearch } from 'src/app/heplers/utils';
import { User } from 'src/app/models/account';
import { CartCreateCondition, CartItem } from 'src/app/models/cart';
import { Pagination } from 'src/app/models/condition';
import { PetCondition } from 'src/app/models/pet';
import { AccountService } from 'src/app/services/account.service';
import { CartService } from 'src/app/services/cart.service';
import { CartCountService } from 'src/app/services/cartcount.service';
import { PaginationService } from 'src/app/services/pagination.service';
import { PetService } from 'src/app/services/pet.service';

@Component({
  selector: 'app-pets',
  templateUrl: './pets.component.html',
  styleUrls: ['./pets.component.scss']
})
export class PetsComponent implements OnInit {

  loading = false;
  pagination: Pagination = new Pagination();
  listPage: number[] = [];
  petCondition: PetCondition = new PetCondition();
  subscriptionPagination: Subscription;
  countSub: Subscription;
 // cartCount: any;

  pets : any;
  rid: number = 0;
  bid: number = 0;
  sid: number = 0;
  fString = "";

  // for category
  crid:number = 0;
  ccid:number = 0;

  // typeproductid
  tid: number = 0;

  // Cart
  cartItem: CartItem = new CartItem();
  cartList: Array<CartItem> = [];

  cartCondition: CartCreateCondition = new CartCreateCondition();
  submitted = false;
  user: User;
  message: string = "";
  tempQuantity: number;

  paramSetText = 0; // TypeProductId api trả về

  constructor(private route: ActivatedRoute,
    private router: Router,
    private petService: PetService,
    private paginationService: PaginationService,
    private cartService: CartService,
    private accountService: AccountService,
    private cartCountService: CartCountService) {
      this.pagination.CurrentDate = FormatDaySearch(new Date());
      this.countSub = this.cartCountService.cartCount$.subscribe(
        count => {
           // this runs everytime the count changes
        //   this.cartCount = count;
        }
     );
     //this.cartCountService.setCartCount(2); // init to 0?
  }

  ngOnDestroy() {
    this.countSub.unsubscribe(); // important to unsubscribe
 }

  ngOnInit(): void {
    this.router.routeReuseStrategy.shouldReuseRoute = () => {
      return false;
    } // thay đổi route load lại trang

    this.rid = this.route.snapshot.params['rid'];
    this.bid = this.route.snapshot.params['bid'];
    this.sid = this.route.snapshot.params['sid'];
    this.fString = this.route.snapshot.params['find'];

    this.crid = this.route.snapshot.params['crid'];
    this.ccid = this.route.snapshot.params['ccid'];
    this.tid = this.route.snapshot.params['tid'];

    this.petCondition.BreedId = this.bid;
    this.petCondition.BreedIdRoot = this.rid;
    this.petCondition.SupplierId = this.sid;
    this.petCondition.FindString = this.fString === undefined ? "" : this.fString.replace('%20', ' ');
    this.petCondition.TypeProducuctId = this.tid;
    this.petCondition.CategoryId = this.ccid;
    this.petCondition.CategoryIdRoot = this.crid;

    this.getList();
    this.subscriptionPagination = this.paginationService.getChangePage().subscribe(page => {
      this.pagination.CurrentPage = page;
      this.getList();
    });

    let target = document.getElementById('target1');
    this.scroll(target);
  }

  getList(){
    this.loading = true;
    this.petService.getListPet({
      ...this.pagination,
      ...this.petCondition
    }).subscribe((res: any) => {
        this.pets = res.content.Products;
        this.pagination = res.content.Pagination;
        this.paramSetText = res.content.TypeProductId;
        this.getNumPage();
        this.loading = false;
      });
  }


  previous() {
    let value = this.pagination.CurrentPage - 1;
    if(value < 0) {
      return;
    }
    this.paginationService.changePage(value);
  }

  next() {
    let value = this.pagination.CurrentPage + 1;
    if(value >= this.pagination.TotalPage) {
      return;
    }
    this.paginationService.changePage(value);
  }

  change(number: any) {
    if(this.pagination.CurrentPage == number) {
      return;
    }
    this.paginationService.changePage(number);
  }

  getNumPage(){
    this.listPage = [];
    for(var i = 0; i < 3; i++){
      let value = this.pagination.CurrentPage - 1 + i;
      if(value > -1 && value < this.pagination.TotalPage) {
        this.listPage.push(value);
      }
    }
  }

  scroll(el: HTMLElement) {
    el.scrollIntoView({behavior: 'smooth'});
  }

  AddToCart(Id: any, PetQuantity: number){

    this.submitted = true;

    this.loading = true;

    this.tempQuantity = this.tempQuantity + 1;

    if( this.tempQuantity > PetQuantity){
      this.message = "Số lượng bạn đặt đã vượt qua số lượng tối đa.";

      this.tempQuantity = this.tempQuantity - 1;

      this.loading = false;
      this.submitted = false;

      return;
    }
    else{
      this.message ="";
    }

    if(this.accountService.user){
      this.accountService.user.subscribe( x =>{
        if(x){
          this.user = x;
        }
        else{
          this.user = new User();
        }
      })
    }
    console.log("user login: "+ this.user.Id);

    if(!(this.user.Id > 0)){
      this.router.routeReuseStrategy.shouldReuseRoute = () => {
        return false;
      }
      this.router.onSameUrlNavigation = 'reload';
      this.router.navigate([`/login`]);

      /* sessionStorage.removeItem('cart-pet');

      this.cartItem.PetDetailId = this.petDetail.PetDetailId;
      this.cartItem.Quantity = this.f.Quantity.value;

      this.cartList.push(this.cartItem);
      sessionStorage.setItem('cart-pet', JSON.stringify({...this.cartList}));

      console.log("message : " + this.message);
      console.log("cartList: " + this.cartList);
      console.log("cartItem: " + this.cartItem);

      this.loading = false;
      this.submitted = false; */
    }
    else{
      this.cartCondition.ProductDetailId = Id;
      this.cartCondition.Quantity = 1;

      this.cartService.AddToCart({...this.cartCondition }).subscribe( (res : any) =>{
        if( res.result == 0){
          this.loading = false;
          this.submitted = false;

          return;
        }

        this.cartCountService.getCountQuantity().subscribe((res: any) =>{
          var countQuantity = res.content.countQuantity;

          this.cartCountService.setCartCount(countQuantity);
        });

        let target = document.getElementById('headerpet1');
        this.scroll(target);

        this.loading = false;
        this.submitted = false;
      }, error => {
        this.loading = false;
        this.submitted = false;
      });
    }
  }
}


