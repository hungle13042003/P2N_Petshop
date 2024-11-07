import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ChangeEnumToList } from '../../../heplers/utils';
import { StatusNormal } from '../../../models/status';
import { ColorService } from '../../../services/color.service';
import { ToastService } from '../../../services/toast.service';

@Component({
  selector: 'app-create-color',
  templateUrl: './create-color.component.html',
  styleUrls: ['./create-color.component.scss']
})
export class CreateColorComponent implements OnInit {

  form: FormGroup;
  loading = false;
  submitted = false;

  colorStatusText = StatusNormal;
  colorStatusOptions = [];

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private colorService: ColorService,
    private toastService: ToastService,) {
    this.buildSelection();
  }

  ngOnInit() {
    this.form = this.formBuilder.group({
      Title: ['', Validators.required],
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
    this.colorService.CreateColor({...this.form.value})
      .subscribe((response: any) => {
        
          this.router.navigate(["admin/list-color"]);
      }, error => {
        this.loading = false;
      });
  }

  buildSelection() {
    ChangeEnumToList(this.colorStatusText, this.colorStatusOptions);
  }

}
