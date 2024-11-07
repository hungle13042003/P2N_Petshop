import { UpdateNewsComponent } from './../../pages/news/update-news/update-news.component';
import { CreateNewsComponent } from './../../pages/news/create-news/create-news.component';
import { ListNewsComponent } from './../../pages/news/list-news/list-news.component';
import { UpdateBrandComponent } from './../../pages/brand/update-brand/update-brand.component';
import { CreateBrandComponent } from './../../pages/brand/create-brand/create-brand.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateAccountComponent } from '../../pages/account/create-account/create-account.component';
import { ListAccountComponent } from '../../pages/account/list-account/list-account.component';
import { UpdateAccountComponent } from '../../pages/account/update-account/update-account.component';
import { ViewAccountComponent } from '../../pages/account/view-account/view-account.component';
import { CreateAgeComponent } from '../../pages/age/create-age/create-age.component';
import { ListAgeComponent } from '../../pages/age/list-age/list-age.component';
import { UpdateAgeComponent } from '../../pages/age/update-age/update-age.component';
import { CreateBreedComponent } from '../../pages/breed/create-breed/create-breed.component';
import { ListBreedComponent } from '../../pages/breed/list-breed/list-breed.component';
import { UpdateBreedComponent } from '../../pages/breed/update-breed/update-breed.component';
import { CreateColorComponent } from '../../pages/color/create-color/create-color.component';
import { ListColorComponent } from '../../pages/color/list-color/list-color.component';
import { UpdateColorComponent } from '../../pages/color/update-color/update-color.component';
import { CreateContactComponent } from '../../pages/contact/create-contact/create-contact.component';
import { ListContactComponent } from '../../pages/contact/list-contact/list-contact.component';
import { UpdateContactComponent } from '../../pages/contact/update-contact/update-contact.component';
import { CreateCustomerComponent } from '../../pages/customer/create-customer/create-customer.component';
import { ListCustomerComponent } from '../../pages/customer/list-customer/list-customer.component';
import { UpdateCustomerComponent } from '../../pages/customer/update-customer/update-customer.component';
import { ViewCustomerComponent } from '../../pages/customer/view-customer/view-customer.component';
import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { ListOrderComponent } from '../../pages/order/list-order/list-order.component';
import { ViewOrderComponent } from '../../pages/order/view-order/view-order.component';
import { CreatePetComponent } from '../../pages/pet/create-pet/create-pet.component';
import { ListPetComponent } from '../../pages/pet/list-pet/list-pet.component';
import { UpdatePetComponent } from '../../pages/pet/update-pet/update-pet.component';
import { CreatePetdetailComponent } from '../../pages/petdetail/create-petdetail/create-petdetail.component';
import { ListPetdetailComponent } from '../../pages/petdetail/list-petdetail/list-petdetail.component';
import { UpdatePetdetailComponent } from '../../pages/petdetail/update-petdetail/update-petdetail.component';
import { ViewPetdetailComponent } from '../../pages/petdetail/view-petdetail/view-petdetail.component';
import { CreatePromotionComponent } from '../../pages/promotion/create-promotion/create-promotion.component';
import { ListPromotionComponent } from '../../pages/promotion/list-promotion/list-promotion.component';
import { UpdatePromotionComponent } from '../../pages/promotion/update-promotion/update-promotion.component';
import { CreateSizeComponent } from '../../pages/size/create-size/create-size.component';
import { ListSizeComponent } from '../../pages/size/list-size/list-size.component';
import { UpdateSizeComponent } from '../../pages/size/update-size/update-size.component';
import { CreateSupplierComponent } from '../../pages/supplier/create-supplier/create-supplier.component';
import { ListSupplierComponent } from '../../pages/supplier/list-supplier/list-supplier.component';
import { UpdateSupplierComponent } from '../../pages/supplier/update-supplier/update-supplier.component';
import { PasswordUserComponent } from '../../pages/users/password-user/password-user.component';
import { ProfileUserComponent } from '../../pages/users/profile-user/profile-user.component';
import { CreateCategoryComponent } from './../../pages/category/create-category/create-category.component';
import { UpdateCategoryComponent } from './../../pages/category/update-category/update-category.component';
import { ListBrandComponent } from './../../pages/brand/list-brand/list-brand.component';

const routes: Routes = [
    { path: '',      component: DashboardComponent },
    { path: 'admin/dashboard',      component: DashboardComponent },
    { path: 'admin/list-age',           component: ListAgeComponent },
    { path: 'admin/age/create',         component: CreateAgeComponent },
    { path: 'admin/age/update/:id',     component: UpdateAgeComponent },
    { path: 'admin/list-breed',              component: ListBreedComponent },
    { path: 'admin/breed/create',       component: CreateBreedComponent },
    { path: 'admin/breed/update/:id',   component: UpdateBreedComponent },
    { path: 'admin/list-color',         component: ListColorComponent },
    { path: 'admin/color/create',       component: CreateColorComponent },
    { path: 'admin/color/update/:id',   component: UpdateColorComponent },
    { path: 'admin/list-contact',       component: ListContactComponent },
    { path: 'admin/contact/create',       component: CreateContactComponent },
    { path: 'admin/contact/update/:id',   component: UpdateContactComponent },
    { path: 'admin/list-customer',      component: ListCustomerComponent },
    { path: 'admin/customer/create',       component: CreateCustomerComponent },
    { path: 'admin/customer/update/:id',   component: UpdateCustomerComponent },
    { path: 'admin/list-pet',           component: ListPetComponent },
    { path: 'admin/pet/create',       component: CreatePetComponent },
    { path: 'admin/pet/update/:id',   component: UpdatePetComponent },
    { path: 'admin/list-promotion',     component: ListPromotionComponent },
    { path: 'admin/promotion/create',          component: CreatePromotionComponent },
    { path: 'admin/promotion/update/:id',          component: UpdatePromotionComponent },
    { path: 'admin/list-size',          component: ListSizeComponent },
    { path: 'admin/size/create',          component: CreateSizeComponent },
    { path: 'admin/size/update/:id',          component: UpdateSizeComponent },
    { path: 'admin/list-supplier',      component: ListSupplierComponent },
    { path: 'admin/supplier/create',          component: CreateSupplierComponent },
    { path: 'admin/supplier/update/:id',          component: UpdateSupplierComponent },
    { path: 'admin/list-petdetail',      component: ListPetdetailComponent },
    { path: 'admin/petdetail/create',          component: CreatePetdetailComponent },
    { path: 'admin/petdetail/update/:id',          component: UpdatePetdetailComponent },
    { path: 'admin/petdetail/view/:id',           component: ViewPetdetailComponent },
    { path: 'admin/list-order',      component: ListOrderComponent },
    { path: 'admin/order/view/:id',          component: ViewOrderComponent },
    { path: 'admin/list-account',            component: ListAccountComponent},
    { path: 'admin/account/create',          component: CreateAccountComponent},
    { path: 'admin/account/update/:id',      component: UpdateAccountComponent},
    { path: 'admin/account/view/:id',      component: ViewAccountComponent},
    { path: 'admin/user/profile',      component:ProfileUserComponent},
    { path: 'admin/user/password',      component: PasswordUserComponent},
    { path: 'admin/customer/view/:id',          component: ViewCustomerComponent },
    { path: 'admin/cate/create-category',      component: CreateCategoryComponent},
    { path: 'admin/brand/list-brand',        component : ListBrandComponent},
    { path: 'admin/cate/update-category/:id',        component : UpdateCategoryComponent},
    { path: 'admin/brand/create',        component : CreateBrandComponent},
    { path: 'admin/brand/update/:id',     component: UpdateBrandComponent},
    { path: 'admin/list-news', component: ListNewsComponent},
    { path: 'admin/news/create', component: CreateNewsComponent},
    { path: 'admin/news/update/:id', component: UpdateNewsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminLayoutRoutingModule { }
