import { Breed } from './../../../models/breed';
import { CategorySelection } from './../../../models/pet';
import { TypeProductSelection } from './../../../models/category';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ChangeEnumToList } from '../../../heplers/utils';
import { BreedSelection, SupplierSelection } from '../../../models/pet';
import { StatusNormal } from '../../../models/status';
import { PetService } from '../../../services/pet.service';
import { ToastService } from '../../../services/toast.service';

@Component({
  selector: 'app-create-pet',
  templateUrl: './create-pet.component.html',
  styleUrls: ['./create-pet.component.scss']
})
export class CreatePetComponent implements OnInit {

  form: FormGroup;
  loading = false;
  submitted = false;

  breedSelection: BreedSelection[];
  supplierSelection: SupplierSelection[];
  typeProductSelection: TypeProductSelection[];
  categorySelection: CategorySelection[];

  petStatusText = StatusNormal;
  petStatusOptions = [];

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private petService: PetService,
    private toastService: ToastService,) {
    this.buildSelection();
    this.getBreedSelection();
    this.getSupplierSelection();
    this.getTypeProductSelection();
    this.getCategoryNormalSelection();
  }

  ngOnInit() {
    this.form = this.formBuilder.group({
      BreedId: null,
      SupplierId: null,
      Content: ['', Validators.required],
      Status: [10, Validators.required],
      TypeProductId: [10, Validators.required],
      CategoryId: 0,
    });
  }

  get f() { return this.form.controls; }

  ngAfterViewInit() {

  }

  onSubmit() {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }

    if(this.f.BreedId.value == "" && this.f.CategoryId.value == ""){
      window.alert('Nhập đầy đủ thông tin');
      return;
    }

    this.loading = true;
    this.petService.CreatePet({...this.form.value})
      .subscribe((response: any) => {
        
          this.router.navigate(["admin/list-pet"]);
      }, error => {
        this.loading = false;
      });
  }

  buildSelection() {
    ChangeEnumToList(this.petStatusText, this.petStatusOptions);
  }

  getBreedSelection() {
    this.loading = true;
    this.petService.GetNormalBreed().subscribe((res: any) => {
      this.breedSelection = res.content.BreedSelection;
      this.loading = false;
    });
  }

  getTypeProductSelection() {
    this.loading = true;
    this.petService.GetNormalTypeProductSelection().subscribe((res: any) => {
      this.typeProductSelection = res.content.Selection;
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
      this.categorySelection = res.content.Selection;

      this.loading = false;
    })
  }
}
