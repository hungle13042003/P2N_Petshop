import { RouterModule } from '@angular/router';
import { ComponentsModule } from './../../components/components.module';
import { ClientLayoutRoutingModule } from './client-layout.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientLayoutComponent } from './client-layout.component';
import { LoginComponent } from '../../pages/account/login/login.component';
import { ProfileComponent } from '../../pages/account/profile/profile.component';
import { IndexComponent } from '../../pages/index/index.component';
import { AboutComponent } from '../../pages/about/about.component';
import { CheckoutComponent } from '../../pages/checkout/checkout.component';
import { MailerComponent } from '../../pages/mailer/mailer.component';
import { ProductsComponent } from '../../pages/products/products.component';
import { PetsComponent } from '../../pages/pets/pets.component';
import { SingleComponent } from '../../pages/single/single.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from '../../pages/account/register/register.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { ListOrderComponent } from '../../pages/myorder/list-order/list-order.component';
import { ForgetPasswordComponent } from '../../pages/account/forget-password/forget-password.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CartComponent } from '../../pages/cart/cart.component';
import { DetailOrderComponent } from '../../pages/myorder/detail-order/detail-order.component';
import { ListBlogComponent } from '../../pages/blog/list-blog/list-blog.component';
import { DetailBlogComponent } from '../../pages/blog/detail-blog/detail-blog.component';
import { SafeHtmlPipe } from 'src/app/heplers/safehtml';
import { ChangePasswordComponent } from '../../pages/account/change-password/change-password.component';



@NgModule({
  declarations: [
    ClientLayoutComponent,
    LoginComponent,
    ProfileComponent,
    IndexComponent,
    AboutComponent,
    CheckoutComponent,
    MailerComponent,
    ProductsComponent,
    PetsComponent,
    SingleComponent,
    RegisterComponent,
    ListOrderComponent,
    ForgetPasswordComponent,
    CartComponent,
    DetailOrderComponent,
    ListBlogComponent,
    DetailBlogComponent,
    SafeHtmlPipe,
    ChangePasswordComponent
  ],
  imports: [
    CommonModule,
    ComponentsModule,
    RouterModule,
    ClientLayoutRoutingModule,
    FormsModule,
    NgSelectModule,
    ReactiveFormsModule,
    NgbModule
  ]
})
export class ClientLayoutModule { }
