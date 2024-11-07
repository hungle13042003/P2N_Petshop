import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ChangeEnumToList } from '../../../heplers/utils';
import { StatusNormal } from '../../../models/status';
import { ColorService } from '../../../services/color.service';

@Component({
  selector: 'app-update-color',
  templateUrl: './update-color.component.html',
  styleUrls: ['./update-color.component.scss']
})
export class UpdateColorComponent implements OnInit {

  id: string;
  form: FormGroup;
  loading = false;
  submitted = false;
  firstload = false;

  colorStatusText = StatusNormal;
  colorStatusOptions = []

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private colorService: ColorService,
    private modalService: NgbModal) {
    this.buildSelection();
  }

  ngOnInit() {
    this.firstload = true;
    this.id = this.route.snapshot.params['id'];

    this.colorService.GetDetailColor(this.id)
    .subscribe((x: any) => {
      var color = x.content.Color;
      this.f.Title.setValue(color.Title);
      this.f.Status.setValue(color.Status);
      this.firstload = false;
    });

    this.form = this.formBuilder.group({
      Title: ['', Validators.required],
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
    this.colorService.UpdateColor({ Id: this.id, ...this.form.value })
    .subscribe(() => {
      this.router.navigate(["admin/list-color"]);
    }, error => {
      this.loading = false;
    });
  }

  buildSelection() {
    ChangeEnumToList(this.colorStatusText, this.colorStatusOptions);
  }

}
