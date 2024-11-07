import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ChangeEnumToList, FormBuilderConvertData } from '../../../heplers/utils';
import { StatusNormal } from '../../../models/status';
import { PromotionService } from '../../../services/promotion.service';
import { ToastService } from '../../../services/toast.service';

@Component({
  selector: 'app-create-promotion',
  templateUrl: './create-promotion.component.html',
  styleUrls: ['./create-promotion.component.scss']
})
export class CreatePromotionComponent implements OnInit {

  form: FormGroup;
  loading = false;
  submitted = false;
  image: any;

  promotionStatusText = StatusNormal;
  promotionStatusOptions = [];

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private promotionService: PromotionService,
    private toastService: ToastService) {
    this.buildSelection();
  }

  ngOnInit() {
    this.form = this.formBuilder.group({
      Title: ['', Validators.required],
      PromotionImage: null,
      FromDate: null,
      ToDate: null,
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
    let formData = FormBuilderConvertData(this.form.value);
    formData.append('Image', this.image);
    this.promotionService.CreatePromotion(formData)
      .subscribe((response: any) => {
        
          this.router.navigate(["admin/list-promotion"]);
      }, error => {
        this.loading = false;
      });
  }

  buildSelection() {
    ChangeEnumToList(this.promotionStatusText, this.promotionStatusOptions);
  }

  onFileChange(event) {
    if (event.target.files && event.target.files.length) {
      let thatForm = this.f;
      const [file] = event.target.files;

      var reader = new FileReader();
      reader.onload = function (e) {
        thatForm.PromotionImage.setValue(e.target.result);
      }

      this.image = file;
      reader.readAsDataURL(file);
    }
  }
}
