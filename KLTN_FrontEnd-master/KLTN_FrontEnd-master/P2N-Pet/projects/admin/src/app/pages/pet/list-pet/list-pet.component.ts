import { CategorySelection } from './../../../models/pet';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ChangeEnumToList, FormatDateVN, FormatDaySearch } from '../../../heplers/utils';
import { Pagination } from '../../../models/condition';
import { BreedSelection, PetCondition, SupplierSelection } from '../../../models/pet';
import { StatusNormal } from '../../../models/status';
import { PaginationService } from '../../../services/pagination.service';
import { PetService } from '../../../services/pet.service';

@Component({
  selector: 'app-list-pet',
  templateUrl: './list-pet.component.html',
  styleUrls: ['./list-pet.component.scss']
})
export class ListPetComponent implements OnInit {

  loading = false;
  pagination: Pagination = new Pagination();
  listPage: number[] = [];
  petCondition: PetCondition = new PetCondition();
  subscriptionPagination: Subscription;

  petStatusText = StatusNormal;
  petStatusOptions = []

  breedSelection: BreedSelection[];
  supplierSelection: SupplierSelection[];

  categorySelection : CategorySelection[];
  categorySelectionAll : CategorySelection[];

  public pets: any;

  // Loại sản phẩm
  typeProductId: number;

  constructor(private petService: PetService,
    private paginationService: PaginationService,
    private router: Router) {
      this.pagination.CurrentDate = FormatDaySearch(new Date());
      this.buildSelection();
      this.getBreedSelection();
      this.getSupplierSelection();
      this.getCategoryNormalSelection();

      this.typeProductId = 10;
  }

  ngOnInit(): void {
    this.getListProduct(this.typeProductId);
    this.subscriptionPagination = this.paginationService.getChangePage().subscribe(pagenumber => {
      this.pagination.CurrentPage = pagenumber;
      this.getListProduct(this.typeProductId);
    });
  }

  getListProduct(type){
    this.typeProductId = type;
    this.petCondition.TypeProductId = this.typeProductId;
    if(type != 10){
      this.categorySelection = this.categorySelectionAll.filter(p => p.TypeProductId == type);
    }
    this.petCondition.CategoryId = 0;
    this.petCondition.SupplierId = '0';
    this.petCondition.Status = '0';
    this.getList();
  }

  getList() {
    this.loading = true;
    this.petService.GetListPet({
      ...this.pagination,
      ...this.petCondition
    }).subscribe((res: any) => {
        this.pets = res.content.Products;
        this.pagination = res.content.Pagination;
        this.getNumPage();
        this.loading = false;
      });
  }

  deletePet(Id){
    this.petService.DeletePet(Id).subscribe((res: any) => {
      this.getList();
    });
  }

  confirmAlertDelete(Id){
    let textConfirm = 'Bạn muốn xoá thú cưng / sản phẩm này ?';

    let isCheck = confirm(textConfirm);

    if(isCheck){
      this.deletePet(Id);
      alert('Xoá thú cưng / sản phẩm thành công');
    }
  }

  buildSelection() {
    ChangeEnumToList(this.petStatusText, this.petStatusOptions);
  }

  formatDateVN(input) {
    return FormatDateVN(input);
  }

  getBreedSelection() {
    this.loading = true;
    this.petService.GetNormalBreed().subscribe((res: any) => {
      this.breedSelection = res.content.BreedSelection;
      this.loading = false;
    });
  }

  getSupplierSelection() {
    this.loading = true;
    this.petService.GetNormalSupplier().subscribe((res: any) => {
      this.supplierSelection = res.content.SupplierSelection;
      this.loading = false;
    });
  }

  getCategoryNormalSelection(){
    this.loading = true;

    this.petService.GetNormalCategory().subscribe( (res: any) => {
      this.categorySelectionAll = res.content.Selection;

      this.loading = false;
    })
  }

  onSearch() {
    this.pagination.CurrentPage = 0;
    this.pagination.CurrentDate = FormatDaySearch(new Date());
    this.getList();
  }

  clearForm(){
    this.petCondition = new PetCondition();
    this.pagination.CurrentPage = 0;
    this.loading = true;
    this.getList();
  }

  ngOnDestroy() {
    this.subscriptionPagination.unsubscribe();
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

  routingForm(){
    this.router.navigate(["admin/pet/create"]);
  }
}
