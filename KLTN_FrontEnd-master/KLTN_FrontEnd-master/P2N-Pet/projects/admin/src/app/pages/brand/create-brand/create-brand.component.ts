import { ProductDetailSelection, brandProducts } from './../../../models/brand';
import { BrandService } from './../../../services/brand.service';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { StatusNormal } from '../../../models/status';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from '../../../services/toast.service';
import { ChangeEnumToList } from '../../../heplers/utils';

@Component({
  selector: 'app-create-brand',
  templateUrl: './create-brand.component.html',
  styleUrls: ['./create-brand.component.scss']
})

export class CreateBrandComponent implements OnInit {

  formMain: FormGroup;
  loading = false;
  submitted = false;

  productDetailSelection : ProductDetailSelection[];

  brandStatusText = StatusNormal;
  brandStatusOptions = [];
  
  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private brandService: BrandService,
    private toastService: ToastService) {
      this.buildSelection();
      this.getBrandDefaultSelection();
     }

  ngOnInit(): void {

    this.formMain = this.formBuilder.group({
      Email: ['', Validators.required],
      Phone: ['', Validators.required],
      Address: ['', Validators.required],
      Status: [10, Validators.required],
      aBrandProducts: this.formBuilder.array([
        this.formBuilder.group({
          Id: [0],
          ProductDetailId : [0, Validators.required],
          QuantityInBrand : [0, Validators.required]
        })
      ])
    });
  }

  get fMain(){return this.formMain.controls;}
  get fProduct(): FormArray { return this.formMain.get('aBrandProducts') as FormArray;}

  ngAfterViewInit() {

  }

  onSubmit(){
    this.submitted = true;

    if (this.formMain.invalid) {
      return;
    }

    // this.fMain.aBrandProducts = this.fProduct.value;

    this.loading = true;
    this.brandService.CreateBrand({...this.formMain.value})
      .subscribe((response: any) => {
        
          this.router.navigate(["admin/brand/list-brand"]);
      }, error => {
        this.loading = false;
      });
  }

  buildSelection() {
    ChangeEnumToList(this.brandStatusText, this.brandStatusOptions);
  }

  getBrandDefaultSelection() {
    this.loading = true;
    this.brandService.GetListProductDetailSelection().subscribe((res: any) => {
      this.productDetailSelection = res.content.Selection;
      this.loading = false;
    });
  }

  createRow(){
    let row = this.formBuilder.group( new brandProducts());
    this.fProduct.push(row);  

    // console.log("Add row nhe");
      
  }

  deleteRow(ix: any){
    this.fProduct.removeAt(ix);
  }

}
