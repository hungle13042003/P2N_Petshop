import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ChangeEnumToList } from '../../../heplers/utils';
import { BreedDefaultSelection } from '../../../models/breed';
import { StatusNormal } from '../../../models/status';
import { BreedService } from '../../../services/breed.service';
import { ToastService } from '../../../services/toast.service';

@Component({
  selector: 'app-create-breed',
  templateUrl: './create-breed.component.html',
  styleUrls: ['./create-breed.component.scss']
})
export class CreateBreedComponent implements OnInit {

  form: FormGroup;
  loading = false;
  submitted = false;

  breedDefaultSelection: BreedDefaultSelection[];

  breedStatusText = StatusNormal;
  breedStatusOptions = [];

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private breedService: BreedService,
    private toastService: ToastService,) {
    this.buildSelection();
    this.getBreedDefaultSelection();
  }

  ngOnInit() {
    this.form = this.formBuilder.group({
      Name: ['', Validators.required],
      BreedId: [1, Validators.required],
      Status: [10, Validators.required]
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
    this.breedService.CreateBreed({...this.form.value})
      .subscribe((response: any) => {
        
          this.router.navigate(["admin/list-breed"]);
      }, error => {
        this.loading = false;
      });
  }

  buildSelection() {
    ChangeEnumToList(this.breedStatusText, this.breedStatusOptions);
  }

  getBreedDefaultSelection() {
    this.loading = true;
    this.breedService.GetNormalBreedDefault().subscribe((res: any) => {
      this.breedDefaultSelection = res.content.BreedDefaultSelection;
      this.loading = false;
    });
  }
}
