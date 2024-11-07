import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ChangeEnumToList } from '../../../heplers/utils';
import { BreedSelection, CategorySelection, SupplierSelection } from '../../../models/pet';
import { StatusNormal } from '../../../models/status';
import { PetService } from '../../../services/pet.service';

@Component({
  selector: 'app-update-pet',
  templateUrl: './update-pet.component.html',
  styleUrls: ['./update-pet.component.scss']
})
export class UpdatePetComponent implements OnInit {

  id: string;
  form: FormGroup;
  loading = false;
  submitted = false;
  firstload = false;

  breedSelection: BreedSelection[];
  supplierSelection: SupplierSelection[];
  categorySelection: CategorySelection[];

  petStatusText = StatusNormal;
  petStatusOptions = []

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private petService: PetService,
    private modalService: NgbModal) {
    this.buildSelection();
    this.getBreedSelection();
    this.getSupplierSelection();
    this.getCategoryNormalSelection();
  }

  ngOnInit() {
    this.firstload = true;
    this.id = this.route.snapshot.params['id'];

    this.petService.GetDetailPet(this.id)
    .subscribe((x: any) => {
      var pet = x.content.Product;
      this.f.BreedId.setValue(pet.BreedId);
      this.f.SupplierId.setValue(pet.SupplierId);
      this.f.Content.setValue(pet.Content);
      this.f.Status.setValue(pet.Status);
      this.f.CategoryId.setValue(pet.CategoryId);
      this.firstload = false;
    });

    this.form = this.formBuilder.group({
      BreedId: null,
      SupplierId: null,
      Content: ['', Validators.required],
      Status: [10, Validators.required],
      CategoryId: 0
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

    this.loading = true;
    this.petService.UpdatePet({ Id: this.id, ...this.form.value })
    .subscribe(() => {
      this.router.navigate(["admin/list-pet"]);
    }, error => {
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

  getSupplierSelection() {
    this.loading = true;
    this.petService.GetNormalSupplier().subscribe((res: any) => {
      this.supplierSelection = res.content.SupplierSelection;
      this.loading = false;
    });
  }

}
