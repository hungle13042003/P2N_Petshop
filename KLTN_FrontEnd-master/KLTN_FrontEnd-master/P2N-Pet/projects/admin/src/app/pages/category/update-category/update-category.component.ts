import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ChangeEnumToList } from '../../../heplers/utils';
import { CategoryRootSelection, TypeProductSelection } from '../../../models/category';
import { StatusNormal } from '../../../models/status';
import { CategoryService } from '../../../services/category.service';

@Component({
  selector: 'app-update-category',
  templateUrl: './update-category.component.html',
  styleUrls: ['./update-category.component.scss']
})
export class UpdateCategoryComponent implements OnInit {

  id: string;
  form: FormGroup;
  loading = false;
  submitted = false;
  firstload = false;

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

    this.firstload = true;
    this.id = this.route.snapshot.params['id'];

    this.categoryService.GetDetailCategory(this.id)
      .subscribe((res:any) =>{
        var category = res.content.Category;

        this.f.Title.setValue(category.Name);
        this.f.CategoryRootId.setValue(category.CategoryRootId);
        this.f.Status.setValue(category.Status);
        this.f.TypeProductId.setValue(category.TypeProductId);

        this.firstload = false;
      });

    this.form = this.formBuilder.group({
      Title: ['', Validators.required],
      CategoryRootId: [1, Validators.required],
      Status: [10, Validators.required],
      TypeProductId: [20, Validators.required]
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
    this.categoryService.UpdateCategory({ Id: this.id, ...this.form.value })
    .subscribe(() => {
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
