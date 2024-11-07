import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ChangeEnumToList } from '../../../heplers/utils';
import { StatusNormal } from '../../../models/status';
import { SizeService } from '../../../services/size.service';

@Component({
  selector: 'app-update-size',
  templateUrl: './update-size.component.html',
  styleUrls: ['./update-size.component.scss']
})
export class UpdateSizeComponent implements OnInit {
  id: string;
  form: FormGroup;
  loading = false;
  submitted = false;
  firstload = false;

  sizeStatusText = StatusNormal;
  sizeStatusOptions = []

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private sizeService: SizeService,
    private modalService: NgbModal) {
    this.buildSelection();
  }

  ngOnInit() {
    this.firstload = true;
    this.id = this.route.snapshot.params['id'];

    this.sizeService.GetDetailSize(this.id)
    .subscribe((x: any) => {
      var size = x.content.Size;
      this.f.Title.setValue(size.Title);
      this.f.OrderView.setValue(size.OrderView);
      this.f.Status.setValue(size.Status);
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
    this.sizeService.UpdateSize({ Id: this.id, ...this.form.value })
    .subscribe(() => {
      this.router.navigate(["admin/list-size"]);
    }, error => {
      this.loading = false;
    });
  }

  buildSelection() {
    ChangeEnumToList(this.sizeStatusText, this.sizeStatusOptions);
  }
}
