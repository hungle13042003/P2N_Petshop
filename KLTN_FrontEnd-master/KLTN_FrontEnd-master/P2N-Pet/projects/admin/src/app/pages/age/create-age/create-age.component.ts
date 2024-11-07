import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ChangeEnumToList } from '../../../heplers/utils';
import { StatusCareerKind, StatusExamSituation, StatusNormal } from '../../../models/status';
import { AgeService } from '../../../services/age.service';
import { ToastService } from '../../../services/toast.service';

@Component({
  selector: 'app-create-age',
  templateUrl: './create-age.component.html',
  styleUrls: ['./create-age.component.scss']
})
export class CreateAgeComponent implements OnInit {

  form: FormGroup;
  loading = false;
  submitted = false;

  ageStatusText = StatusNormal;
  ageStatusOptions = [];

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private ageService: AgeService,
    private toastService: ToastService,) {
    this.buildSelection();
  }

  ngOnInit() {
    this.form = this.formBuilder.group({
      Title: ['', Validators.required],
      OrderView: [1, Validators.required],
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
    this.ageService.CreateAge({...this.form.value})
      .subscribe((response: any) => {
        
          this.router.navigate(["admin/list-age"]);
      }, error => {
        this.loading = false;
      });
  }

  buildSelection() {
    ChangeEnumToList(this.ageStatusText, this.ageStatusOptions);
  }
}