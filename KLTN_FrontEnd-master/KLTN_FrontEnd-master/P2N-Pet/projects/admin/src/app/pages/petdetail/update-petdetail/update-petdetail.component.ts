import { DatePipe } from '@angular/common';
import { Component, forwardRef, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ChangeEnumToList, FormBuilderConvertData } from '../../../heplers/utils';
import { CategorySelection } from '../../../models/pet';
import { AgeSelection, BrandSelection, BreedSelection, ColorSelection, PetDetailOneModel, productBrands, SexSelection, SizeSelection, StatusDetailSelection, SupplierSelection } from '../../../models/petdetail';
import { StatusNormal } from '../../../models/status';
import { PetDetailService } from '../../../services/petdetail.service';

@Component({
  selector: 'app-update-petdetail',
  templateUrl: './update-petdetail.component.html',
  styleUrls: ['./update-petdetail.component.scss']
})
export class UpdatePetdetailComponent implements OnInit {

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
    private modalService: NgbModal,
    private datePipe: DatePipe) {
    this.buildSelection();
    this.getNormalAgeSelection();
    this.getNormalColorSelection();
    this.getNormalSizeSelection();
    this.getNormalSexSelection();
    this.getNormalStatusDetailSelection();
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
      this.urls = this.petDetail.aProductProductImageForModels;
      this.f.CategoryId.setValue(this.petDetail.CategoryId);

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
      this.getNormalCategoryProductDetailSelection();
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
  }

  get f() { return this.form.controls; }
  get fBrands(): FormArray { return this.form.get('brands') as FormArray;}

  ngAfterViewInit() {

  }

  onSubmit() {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }

    this.loading = true;

    for(var i = 0; i< this.petimagedeletes.length; i++){
      this.petDetailService.DeletePetDetailImage(this.petimagedeletes[i])
      .subscribe(() => {});
    }

    let formData = FormBuilderConvertData(this.form.value);
    for (var i = 0; i < this.FileData.length; i++) {
      formData.append("FileData", this.FileData[i]);
    }

    formData.delete('brands');
    formData.append('ProductBrands',JSON.stringify(this.fBrands.value));

    this.petDetailService.UpdatePetDetail(formData)
    .subscribe(() => {
      this.router.navigate(["admin/list-petdetail"]);
    }, error => {
      this.loading = false;
    });
  }

  createRow(){
    let row = this.formBuilder.group( new productBrands());
    this.fBrands.push(row);  //fBrands

    //console.log("Add row nhe");
  }

  deleteRow(ix: any){
    this.fBrands.removeAt(ix);
  }

  getNormalBrandSelection(){
    this.loading = true;

    this.petDetailService.GetNormalBrandSelection().subscribe( (res : any) => {
      this.brandSelection = res.content.Selection;

      this.loading = false;
    })
  }

  getNormalCategoryProductDetailSelection(){
    this.loading = true;
    this.petDetailService.GetNormalCategoryProductDetailSelection(this.form.controls['SupplierId'].value).subscribe((res: any) => {
      this.categorySelection = res.content.Selection;
      this.loading = false;
    });
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

    if(this.f.BreedId.value != 0){
      this.petDetailService.GetNormalSupplierPetDetailSelection(this.form.controls['BreedId'].value).subscribe((res: any) => {
        this.supplierSelection = res.content.SupplierSelection;
        this.loading = false;
      });
    }
    else if ( this.f.CategoryId.value != 0){
      this.petDetailService.GetSupplierPetDetailSelection(this.form.controls['CategoryId'].value).subscribe((res: any) => {
        this.supplierSelection = res.content.SupplierSelection;
        this.loading = false;
      });
    }
  }

  getNormalStatusDetailSelection(){
    this.loading = true;
    this.petDetailService.GetNormalStatusDetailSelection().subscribe((res: any) => {
      this.statusDetailSelection = res.content.StatusDetailSelection;
      this.loading = false;
    });
  }

  onFileChange(event) {
    if (event.target.files && event.target.files.length) {

      for (var i = 0; i < event.target.files.length; i++) {
        this.FileData.push(event.target.files[i]);
      }

      let files = event.target.files;
      if (files) {
        for (let file of files) {
          let reader = new FileReader();
          reader.onload = (e: any) => {
            this.urlnews.push(e.target.result);
          }
          reader.readAsDataURL(file);
        }
      }
    }
  }

  deleteItemImageOld(petimageid){
    this.urls.forEach((value,index)=>{
      if(value.ProductImageId == petimageid){
        this.urls.splice(index,1);
      }
    });

    this.petimagedeletes.push(petimageid);
  }

  deleteItemImageNew(index){
    this.urlnews.splice(index, 1);
    this.FileData.splice(index, 1);
  }
}
