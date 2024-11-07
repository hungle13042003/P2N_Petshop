import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ChangeEnumToList, FormatDateVN, FormatDaySearch } from '../../../heplers/utils';
import { Pagination } from '../../../models/condition';
import { CategorySelection } from '../../../models/pet';
import { AgeSelection, BreedSelection, ColorSelection, PetDetailCondition, SexSelection, SizeSelection, StatusDetailSelection, SupplierSelection } from '../../../models/petdetail';
import { StatusNormal } from '../../../models/status';
import { PaginationService } from '../../../services/pagination.service';
import { PetDetailService } from '../../../services/petdetail.service';

@Component({
  selector: 'app-list-petdetail',
  templateUrl: './list-petdetail.component.html',
  styleUrls: ['./list-petdetail.component.scss']
})
export class ListPetdetailComponent implements OnInit {

  loading = false;
  pagination: Pagination = new Pagination();
  listPage: number[] = [];
  petDetailCondition: PetDetailCondition = new PetDetailCondition();
  subscriptionPagination: Subscription;

  breedSelection: BreedSelection[];
  supplierSelection: SupplierSelection[];
  ageSelection: AgeSelection[];
  colorSelection: ColorSelection[];
  sizeSelection: SizeSelection[];
  sexSelection: SexSelection[];
  statusDetailSelection: StatusDetailSelection[];

  petDetailStatusText = StatusNormal;
  petDetailStatusOptions = [];
  categorySelection : CategorySelection[];

  categorySelectionAll : CategorySelection[];

  public petDetails: any;

  // Loại sản phẩm
  typeProductId: number;

  constructor(private petDetailService: PetDetailService,
    private paginationService: PaginationService,
    private router: Router) {
    this.pagination.CurrentDate = FormatDaySearch(new Date());
    this.buildSelection();
    this.getNormalAgeSelection();
    this.getNormalColorSelection();
    this.getNormalSizeSelection();
    this.getNormalSexSelection();
    this.getNormalStatusDetailSelection();
    this.getNormalBreedPetDetailSelection();
    this.getNormalSupplierPetDetailSelection();
    this.getCategoryNormalSelection();

    this.typeProductId = 10;
  }

  ngOnInit(): void {
    // let target = document.getElementById('target');
    // this.scroll(target);
    //this.getList();
    this.getListProductDetail(this.typeProductId);

    this.subscriptionPagination = this.paginationService.getChangePage().subscribe(pagenumber => {
      this.pagination.CurrentPage = pagenumber;
      this.getListProductDetail(this.typeProductId);
    });
  }

  // scroll(el: HTMLElement) {
  //   el.scrollIntoView({behavior: 'smooth'});
  // }

  routingForm(){
    this.router.navigate(["admin/petdetail/create"]);
  }

  getListProductDetail(type){
    this.typeProductId = type;

    if(type != 10){
      this.categorySelection = this.categorySelectionAll.filter(p => p.TypeProductId == type);
    }
    this.petDetailCondition.CategoryId = 0;

    this.petDetailCondition.TypeProductId = this.typeProductId;
    this.getList();
  }

  getList() {
    this.loading = true;
    this.petDetailService.GetListPetDetail({
      ...this.pagination,
      ...this.petDetailCondition
    }).subscribe((res: any) => {
        this.petDetails = res.content.ProductDetails;
        this.pagination = res.content.Pagination;
        this.getNumPage();
        this.loading = false;
      });
  }

  deletePetDetail(Id){
    this.petDetailService.DeletePetDetail(Id).subscribe((res: any) => {
      this.getList();
    });
  }

  confirmAlertDelete(Id){
    let textConfirm = 'Bạn muốn xoá thông tin chi tiết của thú cưng / sản phẩm này ?';

    let isCheck = confirm(textConfirm);

    if(isCheck){
      this.deletePetDetail(Id);
      alert('Xoá thông tin thú cưng / sản phẩm thành công');
    }
  }

  buildSelection() {
    ChangeEnumToList(this.petDetailStatusText, this.petDetailStatusOptions);
  }

  getCategoryNormalSelection(){
    this.loading = true;

    this.petDetailService.GetNormalCategory().subscribe( (res: any) => {
      this.categorySelectionAll = res.content.Selection;

      this.loading = false;
    })
  }

  formatDateVN(input) {
    return FormatDateVN(input);
  }


  getNormalAgeSelection() {
    this.loading = true;
    this.petDetailService.GetNormalAgeSelection().subscribe((res: any) => {
      this.ageSelection = res.content.AgeSelection;
      this.loading = false;
    });
  }

  getNormalColorSelection(){
    this.loading = true;
    this.petDetailService.GetNormalColorSelection().subscribe((res: any) => {
      this.colorSelection = res.content.ColorSelection;
      this.loading = false;
    });
  }

  getNormalSizeSelection(){
    this.loading = true;
    this.petDetailService.GetNormalSizeSelection().subscribe((res: any) => {
      this.sizeSelection = res.content.SizeSelection;
      this.loading = false;
    });
  }

  getNormalSexSelection(){
    this.loading = true;
    this.petDetailService.GetNormalSexSelection().subscribe((res: any) => {
      this.sexSelection = res.content.SexSelection;
      this.loading = false;
    });
  }

  getNormalBreedPetDetailSelection(){
    this.loading = true;
    this.petDetailService.GetNormalBreedPetDetailSelection(this.petDetailCondition.SupplierId).subscribe((res: any) => {
      this.breedSelection = res.content.BreedSelection;
      this.loading = false;
    });
  }

  getNormalSupplierPetDetailSelection(){
    this.loading = true;
    this.petDetailService.GetNormalSupplierPetDetailSelection(this.petDetailCondition.BreedId).subscribe((res: any) => {
      this.supplierSelection = res.content.SupplierSelection;
      this.loading = false;
    });
  }

  getNormalStatusDetailSelection(){
    this.loading = true;
    this.petDetailService.GetNormalStatusDetailSelection().subscribe((res: any) => {
      this.statusDetailSelection = res.content.StatusDetailSelection;
      this.loading = false;
    });
  }

  onSearch() {
    this.pagination.CurrentPage = 0;
    this.pagination.CurrentDate = FormatDaySearch(new Date());
    this.getList();
  }

  clearForm(){
    this.petDetailCondition = new PetDetailCondition();
    this.pagination.CurrentPage = 0;
    this.loading = true;
    this.petDetailCondition.TypeProductId = this.typeProductId;
    this.getList();
    this.getNormalBreedPetDetailSelection();
    this.getNormalSupplierPetDetailSelection();
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
}
