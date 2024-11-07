import { brandModel } from './../../../models/brand';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ChangeEnumToList } from '../../../heplers/utils';
import { brandProducts, ProductDetailSelection } from '../../../models/brand';
import { StatusNormal } from '../../../models/status';
import { BrandService } from '../../../services/brand.service';
import { ToastService } from '../../../services/toast.service';

@Component({
  selector: 'app-update-brand',
  templateUrl: './update-brand.component.html',
  styleUrls: ['./update-brand.component.scss']
})
export class UpdateBrandComponent implements OnInit {

  formMain: FormGroup;
  loading = false;
  submitted = false;
  firstload = false;
  id: string;

  brand : brandModel = new brandModel();

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
    this.firstload = true;    

    this.id = this.route.snapshot.params['id'];

    this.brandService.GetDetailBrand(this.id).subscribe((res: any) =>  {
      this.brand = res.content.Brand;      

      this.fMain.Email.setValue(this.brand.Email);
      this.fMain.Phone.setValue(this.brand.Phone);
      this.fMain.Address.setValue(this.brand.Address);
      this.fMain.Status.setValue(this.brand.Status);

      for( var item of this.brand.products){
        let product = new brandProducts();
        product.ProductDetailId = item.ProductDetailId;
        product.QuantityInBrand =  item.QuantityInBrand;
  
        let prodGroup = this.formBuilder.group(product);
  
        this.fProduct.push(prodGroup);
      };

      this.firstload = false;
    });
    
    this.formMain = this.formBuilder.group({
      Email: ['', Validators.required],
      Phone: ['', Validators.required],
      Address: ['', Validators.required],
      Status: [10, Validators.required],
      aBrandProducts: this.formBuilder.array([])
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

    this.loading = true;
    this.brandService.UpdateBrand({Id: this.id, ...this.formMain.value})
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
      
  }

  deleteRow(ix: any){
    this.fProduct.removeAt(ix);
  }
}
