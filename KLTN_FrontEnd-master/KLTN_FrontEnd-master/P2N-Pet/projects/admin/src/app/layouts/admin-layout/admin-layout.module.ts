import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgxNumberFormatModule } from 'ngx-number-format';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ClipboardModule } from 'ngx-clipboard';
import { AdminLayoutRoutingModule } from './admin-layout-routing.module';
import { ListAgeComponent } from '../../pages/age/list-age/list-age.component';
import { CreateAgeComponent } from '../../pages/age/create-age/create-age.component';
import { UpdateAgeComponent } from '../../pages/age/update-age/update-age.component';
import { ListColorComponent } from '../../pages/color/list-color/list-color.component';
import { CreateColorComponent } from '../../pages/color/create-color/create-color.component';
import { UpdateColorComponent } from '../../pages/color/update-color/update-color.component';
import { ListSizeComponent } from '../../pages/size/list-size/list-size.component';
import { CreateSizeComponent } from '../../pages/size/create-size/create-size.component';
import { UpdateSizeComponent } from '../../pages/size/update-size/update-size.component';
import { ListPromotionComponent } from '../../pages/promotion/list-promotion/list-promotion.component';
import { CreatePromotionComponent } from '../../pages/promotion/create-promotion/create-promotion.component';
import { UpdatePromotionComponent } from '../../pages/promotion/update-promotion/update-promotion.component';
import { ListSupplierComponent } from '../../pages/supplier/list-supplier/list-supplier.component';
import { CreateSupplierComponent } from '../../pages/supplier/create-supplier/create-supplier.component';
import { UpdateSupplierComponent } from '../../pages/supplier/update-supplier/update-supplier.component';
import { ListCustomerComponent } from '../../pages/customer/list-customer/list-customer.component';
import { CreateCustomerComponent } from '../../pages/customer/create-customer/create-customer.component';
import { UpdateCustomerComponent } from '../../pages/customer/update-customer/update-customer.component';
import { ListContactComponent } from '../../pages/contact/list-contact/list-contact.component';
import { CreateContactComponent } from '../../pages/contact/create-contact/create-contact.component';
import { UpdateContactComponent } from '../../pages/contact/update-contact/update-contact.component';
import { ListPetComponent } from '../../pages/pet/list-pet/list-pet.component';
import { CreatePetComponent } from '../../pages/pet/create-pet/create-pet.component';
import { UpdatePetComponent } from '../../pages/pet/update-pet/update-pet.component';
import { ListBreedComponent } from '../../pages/breed/list-breed/list-breed.component';
import { CreateBreedComponent } from '../../pages/breed/create-breed/create-breed.component';
import { UpdateBreedComponent } from '../../pages/breed/update-breed/update-breed.component';
import { ListPetdetailComponent } from '../../pages/petdetail/list-petdetail/list-petdetail.component';
import { CreatePetdetailComponent } from '../../pages/petdetail/create-petdetail/create-petdetail.component';
import { UpdatePetdetailComponent } from '../../pages/petdetail/update-petdetail/update-petdetail.component';
import { ListOrderComponent } from '../../pages/order/list-order/list-order.component';
import { ViewOrderComponent } from '../../pages/order/view-order/view-order.component';
import { ViewPetdetailComponent } from '../../pages/petdetail/view-petdetail/view-petdetail.component';
import { ListAccountComponent } from '../../pages/account/list-account/list-account.component';
import { CreateAccountComponent } from '../../pages/account/create-account/create-account.component';
import { UpdateAccountComponent } from '../../pages/account/update-account/update-account.component';
import { ViewAccountComponent } from '../../pages/account/view-account/view-account.component';
import { ProfileUserComponent } from '../../pages/users/profile-user/profile-user.component';
import { PasswordUserComponent } from '../../pages/users/password-user/password-user.component';
import { ViewCustomerComponent } from '../../pages/customer/view-customer/view-customer.component';
import { ListCategoryComponent } from '../../pages/category/list-category/list-category.component';
import { CreateCategoryComponent } from '../../pages/category/create-category/create-category.component';
import { UpdateCategoryComponent } from '../../pages/category/update-category/update-category.component';
import { ListBrandComponent } from '../../pages/brand/list-brand/list-brand.component';
import { UpdateBrandComponent } from '../../pages/brand/update-brand/update-brand.component';
import { CreateBrandComponent } from '../../pages/brand/create-brand/create-brand.component';
import { ListNewsComponent } from '../../pages/news/list-news/list-news.component';
import { CreateNewsComponent } from '../../pages/news/create-news/create-news.component';
import { UpdateNewsComponent } from '../../pages/news/update-news/update-news.component';
import { TooltipModule } from 'ng2-tooltip-directive';

@NgModule({
  declarations: [
    DashboardComponent,
    ListAgeComponent,
    CreateAgeComponent,
    UpdateAgeComponent,
    ListBreedComponent,
    CreateBreedComponent,
    UpdateBreedComponent,
    ListColorComponent,
    CreateColorComponent,
    UpdateColorComponent,
    ListPromotionComponent,
    CreatePromotionComponent,
    UpdatePromotionComponent,
    ListSizeComponent,
    CreateSizeComponent,
    UpdateSizeComponent,
    ListSupplierComponent,
    CreateSupplierComponent,
    UpdateSupplierComponent,
    ListCustomerComponent,
    CreateCustomerComponent,
    UpdateCustomerComponent,
    ListContactComponent,
    CreateContactComponent,
    UpdateContactComponent,
    ListPetComponent,
    CreatePetComponent,
    UpdatePetComponent,
    ListPetdetailComponent,
    CreatePetdetailComponent,
    UpdatePetdetailComponent,
    ViewPetdetailComponent,
    ListOrderComponent,
    ViewOrderComponent,
    ListAccountComponent,
    CreateAccountComponent,
    UpdateAccountComponent,
    ViewAccountComponent,
    ProfileUserComponent,
    PasswordUserComponent,
    ViewCustomerComponent,
    ListCategoryComponent,
    CreateCategoryComponent,
    UpdateCategoryComponent,
    ListBrandComponent,
    UpdateBrandComponent,
    CreateBrandComponent,
    ListNewsComponent,
    CreateNewsComponent,
    UpdateNewsComponent
  ],
  imports: [
    CommonModule,
    AdminLayoutRoutingModule,
    FormsModule,
    HttpClientModule,
    NgbModule,
    ClipboardModule,
    ReactiveFormsModule,
    NgSelectModule,
    NgxNumberFormatModule,
    RouterModule,
    CKEditorModule,
    TooltipModule
  ],
  providers: [
    DatePipe
  ]
})
export class AdminLayoutModule { }
