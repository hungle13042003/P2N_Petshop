import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ChangeEnumToList, FormBuilderConvertData } from '../../../heplers/utils';
import { StatusNormal } from '../../../models/status';
import { PromotionService } from '../../../services/promotion.service';

@Component({
  selector: 'app-update-promotion',
  templateUrl: './update-promotion.component.html',
  styleUrls: ['./update-promotion.component.scss']
})
export class UpdatePromotionComponent implements OnInit {

  id: string;
  form: FormGroup;
  loading = false;
  submitted = false;
  firstload = false;
  image: any;

  promotionStatusText = StatusNormal;
  promotionStatusOptions = []

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private promotionService: PromotionService,
    private modalService: NgbModal,
    private datePipe: DatePipe) {
    this.buildSelection();
  }

  ngOnInit() {
    this.firstload = true;
    this.id = this.route.snapshot.params['id'];

    this.promotionService.GetDetailPromotion(this.id)
    .subscribe((x: any) => {
      var promotion = x.content.Promotion;
      var fromdate = this.datePipe.transform(promotion.FromDate, 'yyyy-MM-dd');
      var todate = this.datePipe.transform(promotion.ToDate, 'yyyy-MM-dd');
      this.f.Id.setValue(this.id);
      this.f.Title.setValue(promotion.Title);
      this.f.PromotionImage.setValue(promotion.Image);
      this.f.FromDate.setValue(fromdate);
      this.f.ToDate.setValue(todate);
      this.f.Status.setValue(promotion.Status);
      this.firstload = false;
    });

    this.form = this.formBuilder.group({
      Id: [0],
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
    this.promotionService.UpdatePromotion(formData)
    .subscribe(() => {
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
