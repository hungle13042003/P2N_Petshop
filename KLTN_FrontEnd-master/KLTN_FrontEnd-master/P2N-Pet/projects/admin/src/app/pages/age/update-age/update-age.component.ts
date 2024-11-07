import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ChangeEnumToList } from '../../../heplers/utils';
import {StatusNormal } from '../../../models/status';
import { AgeService } from '../../../services/age.service';

@Component({
  selector: 'app-update-age',
  templateUrl: './update-age.component.html',
  styleUrls: ['./update-age.component.scss']
})
export class UpdateAgeComponent implements OnInit {

  id: string;
  form: FormGroup;
  loading = false;
  submitted = false;
  firstload = false;

  ageStatusText = StatusNormal;
  ageStatusOptions = []

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private ageService: AgeService,
    private modalService: NgbModal) {
    this.buildSelection();
  }

  ngOnInit() {
    this.firstload = true;
    this.id = this.route.snapshot.params['id'];

    this.ageService.GetDetailAge(this.id)
    .subscribe((x: any) => {
      var age = x.content.Age;
      this.f.Title.setValue(age.Title);
      this.f.OrderView.setValue(age.OrderView);
      this.f.Status.setValue(age.Status);
      this.firstload = false;
    });

    this.form = this.formBuilder.group({
      Title: ['', Validators.required],
      OrderView: [1, Validators.required],
      Status: [10, Validators.required],
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
    this.ageService.UpdateAge({ Id: this.id, ...this.form.value })
    .subscribe(() => {
      this.router.navigate(["admin/list-age"]);
    }, error => {
      this.loading = false;
    });
  }

  buildSelection() {
    ChangeEnumToList(this.ageStatusText, this.ageStatusOptions);
  }
}
