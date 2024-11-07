import { ChangePasswordComponent } from './../../pages/account/change-password/change-password.component';
import { DetailOrderComponent } from './../../pages/myorder/detail-order/detail-order.component';
import { ForgetPasswordComponent } from './../../pages/account/forget-password/forget-password.component';
import { ListOrderComponent } from './../../pages/myorder/list-order/list-order.component';
import { ProfileComponent } from './../../pages/account/profile/profile.component';
import { RegisterComponent } from './../../pages/account/register/register.component';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { SingleComponent } from 'src/app/pages/single/single.component';
import { ProductsComponent } from 'src/app/pages/products/products.component';
import { PetsComponent } from 'src/app/pages/pets/pets.component';
import { MailerComponent } from 'src/app/pages/mailer/mailer.component';
import { LoginComponent } from 'src/app/pages/account/login/login.component';
import { CheckoutComponent } from 'src/app/pages/checkout/checkout.component';
import { AboutComponent } from 'src/app/pages/about/about.component';
import { IndexComponent } from 'src/app/pages/index/index.component';
import { CartComponent } from 'src/app/pages/cart/cart.component';
import { ListBlogComponent } from 'src/app/pages/blog/list-blog/list-blog.component';
import { DetailBlogComponent } from 'src/app/pages/blog/detail-blog/detail-blog.component';

const routes: Routes = [
  {path: "index", component: IndexComponent},
  {path: "about", component: AboutComponent},
  {path: "checkout", component: CheckoutComponent},
  {path: "login", component: LoginComponent},
  {path: "register", component: RegisterComponent},
  {path: "mailer", component: MailerComponent},
  {path: "pets", component: PetsComponent},
  {path: "products", component: ProductsComponent},
  {path: "single", component: SingleComponent},
  {path: "profile", component: ProfileComponent},
  {path: "myorder", component: ListOrderComponent},
  {path: 'category/root/:rid', component:PetsComponent},
  {path: "category/child/:bid", component:PetsComponent},
  {path: "category/sup/:sid", component:PetsComponent},
  {path: 'forget', component: ForgetPasswordComponent},
  {path: "pets/find/:find", component: PetsComponent},
  {path: 'pets/:id', component: SingleComponent},
  {path: 'cart', component: CartComponent},
  {path: 'orders/:id', component: DetailOrderComponent},
  {path: 'blogs', component: ListBlogComponent},
  {path: 'blogs/:id', component: DetailBlogComponent},
  {path: 'category/cateroot/:crid', component:PetsComponent},
  {path: "category/catechild/:ccid", component:PetsComponent},
  {path: "typeproduct/:tid", component:PetsComponent},
  {path: 'details/:id/:brandid', component: SingleComponent},
  {path: 'changepassword', component: ChangePasswordComponent}


]

@NgModule({
  declarations: [],
  imports: [ RouterModule.forChild(routes)],
  exports:[RouterModule]
})
export class ClientLayoutRoutingModule { }
