import { StatusNormal } from './../../../models/status';
import { CategoryRootSelection, TypeProductSelection } from './../../../models/category';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryService } from '../../../services/category.service';
import { ChangeEnumToList } from '../../../heplers/utils';

@Component({
  selector: 'app-create-category',
  templateUrl: './create-category.component.html',
  styleUrls: ['./create-category.component.scss']
})
export class CreateCategoryComponent implements OnInit {

  form: FormGroup;
  loading = false;
  submitted = false;

  categoryRootSelection: CategoryRootSelection[];
  typeProductSelection : TypeProductSelection[];

  categoryStatusText = StatusNormal;
  categoryStatusOption = [];
  
  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private categoryService: CategoryService) { 
        this.buildSelection();
        this.getCategoryRootSelection();
        this.getTypeProductSelection();
    }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      Title: ['', Validators.required],
      CategoryRootId: [0],
      Status: [10, Validators.required],
      TypeProductId : [20, Validators.required]
    });
  }

  get f() { return this.form.controls; }

  ngAfterViewInit() {

  }

  onSubmit(){
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }

    this.loading = true;
    this.categoryService.CreateCategory({...this.form.value})
      .subscribe((response: any) => {
        
          this.router.navigate(["admin/list-breed"]);
      }, error => {
        this.loading = false;
      });
  }

  buildSelection() {
    ChangeEnumToList(this.categoryStatusText, this.categoryStatusOption);
  }

  getCategoryRootSelection(){
    this.loading = true;
    this.categoryService.GetNormalCategoryRootSelection().subscribe((res: any) => {
      this.categoryRootSelection = res.content.Selection;
      this.loading = false;
    })
  }

  getTypeProductSelection(){
    this.loading = true;
    this.categoryService.GetNormalTypeProductSelection().subscribe((res: any) => {
      this.typeProductSelection = res.content.Selection;
      this.loading = false;
    })
  }
}
