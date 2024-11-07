import { PetDetailOneModel, productBrands } from './../../../models/petdetail';
import { Category } from './../../../models/category';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ChangeEnumToList, FormBuilderConvertData } from '../../../heplers/utils';
import { CategorySelection } from '../../../models/pet';
import { AgeSelection, BrandSelection, BreedSelection, ColorSelection, SexSelection, SizeSelection, StatusDetailSelection, SupplierSelection } from '../../../models/petdetail';
import { StatusNormal } from '../../../models/status';
import { PetDetailService } from '../../../services/petdetail.service';

@Component({
  selector: 'app-view-petdetail',
  templateUrl: './view-petdetail.component.html',
  styleUrls: ['./view-petdetail.component.scss']
})
export class ViewPetdetailComponent implements OnInit {

  id: string;
  form: FormGroup;
  loading = false;
  submitted = false;
  firstload = false;

  urls: any;
  petimagedeletes: number[] = [];

  urlnews: string[] = [];
  FileData:string [] = [];

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
  brandSelection: BrandSelection[];

  petDetail: PetDetailOneModel = new PetDetailOneModel();

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private petDetailService: PetDetailService,
    private modalService: NgbModal) {
    this.buildSelection();
    this.getNormalAgeSelection();
    this.getNormalColorSelection();
    this.getNormalSizeSelection();
    this.getNormalSexSelection();
    this.getNormalStatusDetailSelection();
    this.getCategoryNormalSelection();
    this.getNormalBrandSelection();
  }

  ngOnInit() {
    this.firstload = true;
    this.id = this.route.snapshot.params['id'];

    this.petDetailService.GetDetailPetDetail(this.id)
    .subscribe((x: any) => {
      this.petDetail = x.content.ProductDetail;
      this.f.Id.setValue(this.id);
      this.f.BreedId.setValue(this.petDetail.BreedId);
      this.f.SupplierId.setValue(this.petDetail.SupplierId);
      this.f.AgeId.setValue(this.petDetail.AgeId);
      this.f.ColorId.setValue(this.petDetail.ColorId);
      this.f.SizeId.setValue(this.petDetail.SizeId);
      this.f.SexId.setValue(this.petDetail.SexId);
      this.f.StatusDetailId.setValue(this.petDetail.StatusDetailId);
      this.f.Status.setValue(this.petDetail.Status);
      this.f.Price.setValue(this.petDetail.Price);
      this.f.Discount.setValue(this.petDetail.Discount);
      this.f.Quantity.setValue(this.petDetail.Quantity);
      this.f.CategoryId.setValue(this.petDetail.CategoryId);
      this.urls = this.petDetail.aProductProductImageForModels;

      for( var item of this.petDetail.brands){
        let brand = new productBrands();

        brand.BrandId = item.BrandId;
        brand.QuantityInBrand = item.QuantityInBrand;

        let brandGroup = this.formBuilder.group(brand);
        this.fBrands.push(brandGroup);
      }
      this.firstload = false;

      this.getNormalBreedPetDetailSelection();
      this.getNormalSupplierPetDetailSelection();
    });

    this.form = this.formBuilder.group({
      Id: [0],
      BreedId: 0,
      SupplierId: 0,
      AgeId: null,
      ColorId: null,
      SizeId: null,
      SexId:null,
      StatusDetailId: [1, Validators.required],
      Status: [10, Validators.required],
      Price: null,
      Discount: null,
      Quantity: [1, Validators.required],
      CategoryId: 0,
      brands: this.formBuilder.array([])
    });

    this.form.disable();
  }

  get f() { return this.form.controls; }

  get fBrands(): FormArray { return this.form.get('brands') as FormArray;}

  ngAfterViewInit() {

  }

  buildSelection() {
    ChangeEnumToList(this.petDetailStatusText, this.petDetailStatusOptions);
  }

  getNormalAgeSelection() {
    this.loading = true;
    this.petDetailService.GetNormalAgeSelection().subscribe((res: any) => {
      this.ageSelection = res.content.AgeSelection;
      this.loading = false;
    });
  }

  getCategoryNormalSelection(){
    this.loading = true;

    this.petDetailService.GetNormalCategory().subscribe( (res: any) => {
      this.categorySelection = res.content.Selection;

      this.loading = false;
    })
  }

  getNormalBrandSelection(){
    this.loading = true;

    this.petDetailService.GetNormalBrandSelection().subscribe( (res : any) => {
      this.brandSelection = res.content.Selection;

      this.loading = false;
    })
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
    this.petDetailService.GetNormalBreedPetDetailSelection(this.form.controls['SupplierId'].value).subscribe((res: any) => {
      this.breedSelection = res.content.BreedSelection;
      this.loading = false;
    });
  }

  getNormalSupplierPetDetailSelection(){
    this.loading = true;
    this.petDetailService.GetNormalSupplierPetDetailSelection(this.form.controls['BreedId'].value).subscribe((res: any) => {
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

}
