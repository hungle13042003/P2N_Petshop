import { Component, ElementRef, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, ROUTES } from '@angular/router';
import { User } from 'src/app/models/account';
import { AccountService } from 'src/app/services/account.service';
import { CartCountService } from 'src/app/services/cartcount.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  user: any;
  obj : any;
  public FindString: string;
  form: FormGroup;

  cartCount$: any;

  constructor(private formBuilder: FormBuilder,
    private accountService: AccountService,private router: Router,
    private cartCountService: CartCountService) {
      this.cartCount$ = this.cartCountService.cartCount$

    this.FindString = '';
  }

  get f() { return this.form.controls; }

  ngOnInit(): void {
    this.router.routeReuseStrategy.shouldReuseRoute = () => {
      return false;
    }
    
     this.form = this.formBuilder.group({
      findString: "",
    });

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

    if( this.user.Id > 0){
      this.cartCountService.getCountQuantity().subscribe((res: any) =>{
        var countQuantity = res.content.countQuantity;
        
        this.cartCountService.setCartCount(countQuantity);
      });
    }
  }

  ngAfterViewInit() {
    //this.router.onSameUrlNavigation = 'reload';
  }

  logout(){
    this.cartCountService.setCartCount(0);

    this.accountService.logout();

    // this.obj = JSON.parse(this.user);

 //   let currentUrl = this.router.url;
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    //this.router.navigate([`/index`]);
  }

  checkLogin(){

    if (this.accountService.user) {
      this.accountService.user.subscribe((x) => {
        if (x) {
          this.user = JSON.stringify(x);
        } 
        else {
          this.user = null;
        }
      });
    }
    this.obj = JSON.parse(this.user);
  }

  findText(){

    let str = this.removeAccents(this.f.findString.value);
    let url = '/pets/find/'+ str;
    console.log(url);
    this.router.navigate([url]);
  }

  removeAccents(str) {
    var AccentsMap = [
      "aàảãáạăằẳẵắặâầẩẫấậ",
      "AÀẢÃÁẠĂẰẲẴẮẶÂẦẨẪẤẬ",
      "dđ", "DĐ",
      "eèẻẽéẹêềểễếệ",
      "EÈẺẼÉẸÊỀỂỄẾỆ",
      "iìỉĩíị",
      "IÌỈĨÍỊ",
      "oòỏõóọôồổỗốộơờởỡớợ",
      "OÒỎÕÓỌÔỒỔỖỐỘƠỜỞỠỚỢ",
      "uùủũúụưừửữứự",
      "UÙỦŨÚỤƯỪỬỮỨỰ",
      "yỳỷỹýỵ",
      "YỲỶỸÝỴ"    
    ];
    for (var i=0; i<AccentsMap.length; i++) {
      var re = new RegExp('[' + AccentsMap[i].substr(1) + ']', 'g');
      var char = AccentsMap[i][0];
      str = str.replace(re, char);
    }
    return str;
  }

  viewCart(){
    if(this.user.Id > 0){
      this.router.navigate(['/cart']);
    }
    else {
      this.router.navigate(['/login']);
    }
  }

}
