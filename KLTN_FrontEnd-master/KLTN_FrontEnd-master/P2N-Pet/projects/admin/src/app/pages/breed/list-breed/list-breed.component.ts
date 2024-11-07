import { CategoryService } from './../../../services/category.service';
import { TypeProductSelection, CategoryCondition, CategoryRootSelection } from './../../../models/category';
import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ChangeEnumToList, FormatDateVN, FormatDaySearch } from '../../../heplers/utils';
import { BreedCondition, BreedDefaultSelection } from '../../../models/breed';
import { Pagination } from '../../../models/condition';
import { StatusNormal } from '../../../models/status';
import { BreedService } from '../../../services/breed.service';
import { PaginationService } from '../../../services/pagination.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-list-breed',
  templateUrl: './list-breed.component.html',
  styleUrls: ['./list-breed.component.scss']
})
export class ListBreedComponent implements OnInit {

  loading = false;
  pagination: Pagination = new Pagination();
  paginationCategory : Pagination = new Pagination();
  listPage: number[] = [];
  breedCondition: BreedCondition = new BreedCondition();
  subscriptionPagination: Subscription;
  subscriptionPaginationCategory: Subscription;

  breedStatusText = StatusNormal;
  breedStatusOptions = []

  breedDefaultSelection: BreedDefaultSelection[];
  public breeds: any;

  typeProductId: number;
  public categories : any;
  typeProductSelection : TypeProductSelection[];
  categoryCondition : CategoryCondition = new CategoryCondition();
  categoryRootSelection : CategoryRootSelection[];
  categoryRootSelectionAll : CategoryRootSelection[];

  constructor(private breedService: BreedService,
    private paginationService: PaginationService,
    private categoryService: CategoryService,
    private route: ActivatedRoute,
    private router: Router,) {
      this.pagination.CurrentDate = FormatDaySearch(new Date());
      this.paginationCategory.CurrentDate = FormatDaySearch(new Date());
      this.buildSelection();
      this.getBreedDefaultSelection();
      this.getCategoryRootSelection();
      this.typeProductId = 10;
  }

  ngOnInit(): void {
    this.getList();

    if(this.typeProductId == 10){
      this.subscriptionPagination = this.paginationService.getChangePage().subscribe(pagenumber => {
        this.pagination.CurrentPage = pagenumber;
        this.getList();
      });
    }

  }

  routingForm(){
    if(this.typeProductId == 10){
      this.router.navigate(["admin/breed/create"]);
    }
    else{
      this.router.navigate(["admin/cate/create-category"]);
    }
  }

  getList() {
    this.loading = true;
    this.breedService.GetListBreed({
      ...this.pagination,
      ...this.breedCondition
    }).subscribe((res: any) => {
        this.breeds = res.content.Breeds;
        this.pagination = res.content.Pagination;
        this.getNumPage();
        this.loading = false;
      });
  }

  getListCategory(){
    this.loading = true;
    this.breedService.GetListCategory({
      ...this.paginationCategory,
      ...this.categoryCondition
    }).subscribe((res: any) => {
      this.categories = res.content.Categories;
      this.paginationCategory = res.content.Pagination;
      this.getNumPage();
      this.loading = false;
    })
  }

  getListCategoryFollowProduct(typeproductid : number){
    this.typeProductId = typeproductid;

    if( this.typeProductId != 10){
      this.categoryRootSelection = this.categoryRootSelectionAll.filter(p => p.TypeProductId == typeproductid);

      console.log("type khác 10: " + this.typeProductId);
      this.subscriptionPaginationCategory = this.paginationService.getChangePage().subscribe(pageNumber => {
        this.paginationCategory.CurrentPage = pageNumber;
        this.getListCategory();
      });
    }

    if( this.typeProductId == 10){
      this.pagination.CurrentPage = 0;
      this.getList();

      console.log(this.breeds);
    }
    else{
      this.breedCondition = new BreedCondition();
      this.categoryCondition = new CategoryCondition();
      this.pagination.CurrentPage = 0;
      this.categoryCondition.TypeProductId = this.typeProductId;
      this.paginationCategory.CurrentPage = 0;
      this.getListCategory();

      //console.log(this.categories);
    }

  }

  deleteBreed(Id){
    this.breedService.DeleteBreed(Id).subscribe((res: any) => {
      this.getList();
    });
  }

  deleteCategory(Id){
    this.categoryService.DeleteCategory(Id).subscribe((res: any) => {
      this.getListCategory();
    })
  }

  confirmAlertDelete(action, Id, msg){
    let textConfirm = "";

    if( action == 'Breed'){
      textConfirm = 'Bạn muốn xoá loại thú cưng ' + msg + ' ?';

      let isCheck = confirm(textConfirm);

      if(isCheck){
        this.deleteBreed(Id);
        alert('Xoá thú cưng thành công..');
      }
    }
    else if( action == 'Category'){
      textConfirm = 'Bạn muốn xoá loại sản phẩm ' + msg + ' ?';

      let isCheck = confirm(textConfirm);

      if(isCheck){
        this.deleteCategory(Id);
        alert('Xoá loại sản phẩm thành công..');
      }

    }
  }

  buildSelection() {
    ChangeEnumToList(this.breedStatusText, this.breedStatusOptions);
  }

  formatDateVN(input) {
    return FormatDateVN(input);
  }

  getBreedDefaultSelection() {
    this.loading = true;
    this.breedService.GetNormalBreedDefault().subscribe((res: any) => {
      this.breedDefaultSelection = res.content.BreedDefaultSelection;
      this.loading = false;
    });
  }

  getCategoryRootSelection(){
    this.loading = true;
    this.breedService.GetNormalCategoryRootSelection().subscribe((res: any) => {
      this.categoryRootSelectionAll = res.content.Selection;
      this.loading = false;
    });
  }

  onSearch() {

    if(this.typeProductId == 10){
      this.pagination.CurrentPage = 0;
      this.pagination.CurrentDate = FormatDaySearch(new Date());
      this.getList();
    }
    else{
      this.paginationCategory.CurrentPage = 0;
      this.paginationCategory.CurrentDate = FormatDaySearch(new Date());
      this.categoryCondition.TypeProductId = this.typeProductId;
      this.categoryCondition.Name = this.breedCondition.Name;
      this.categoryCondition.Status = parseInt(this.breedCondition.Status);
      this.getListCategory();
    }

  }

  clearForm(){
    this.breedCondition = new BreedCondition();
    this.categoryCondition = new CategoryCondition();
    this.pagination.CurrentPage = 0;
    this.loading = true;
    //this.getList
    this.getListCategoryFollowProduct(this.typeProductId);
  }

  ngOnDestroy() {
    this.subscriptionPagination.unsubscribe();
    if(this.typeProductId != 10 && this.subscriptionPagination){
      console.log('destroy khác 10')
    }
    else if( this.typeProductId == 10 && this.subscriptionPaginationCategory){
      console.log('destroy = 10')
      this.subscriptionPaginationCategory.unsubscribe();
    }
  }

  previous() {
    let value = 0;
    if(this.typeProductId == 10){
      value = this.pagination.CurrentPage - 1;
    }
    else{
      value = this.paginationCategory.CurrentPage - 1;
    }

    if(value < 0) {
      return;
    }
    this.paginationService.changePage(value);
  }

  next() {
    let value = 0;
    if(this.typeProductId == 10){
      value = this.pagination.CurrentPage + 1;

      if(value >= this.pagination.TotalPage) {
        return;
      }
    }
    else{
      value = this.paginationCategory.CurrentPage + 1;

      if(value >= this.paginationCategory.TotalPage) {
        return;
      }
    }
    //let value = this.pagination.CurrentPage + 1;

    this.paginationService.changePage(value);
  }

  change(number: any) {
    if(this.typeProductId == 10){
      if(this.pagination.CurrentPage == number) {
        return;
      }
    }
    else{
      if(this.paginationCategory.CurrentPage == number) {
        return;
      }
    }

    this.paginationService.changePage(number);
  }

  getNumPage(){
    this.listPage = [];
    for(var i = 0; i < 3; i++){
      if(this.typeProductId == 10){
        let value = this.pagination.CurrentPage - 1 + i;
        if(value > -1 && value < this.pagination.TotalPage) {
          this.listPage.push(value);
        }
      }
      else{
        let value = this.paginationCategory.CurrentPage - 1 + i;
        if(value > -1 && value < this.paginationCategory.TotalPage) {
          this.listPage.push(value);
        }
      }

    }
  }
}
