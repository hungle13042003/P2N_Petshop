import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ChangeEnumToList } from '../../../heplers/utils';
import { BreedDefaultSelection } from '../../../models/breed';
import { StatusNormal } from '../../../models/status';
import { BreedService } from '../../../services/breed.service';

@Component({
  selector: 'app-update-breed',
  templateUrl: './update-breed.component.html',
  styleUrls: ['./update-breed.component.scss']
})
export class UpdateBreedComponent implements OnInit {

  id: string;
  form: FormGroup;
  loading = false;
  submitted = false;
  firstload = false;

  breedDefaultSelection: BreedDefaultSelection[];

  breedStatusText = StatusNormal;
  breedStatusOptions = []

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private breedService: BreedService,
    private modalService: NgbModal) {
    this.buildSelection();
    this.getBreedDefaultSelection();
  }

  ngOnInit() {
    this.firstload = true;
    this.id = this.route.snapshot.params['id'];

    this.breedService.GetDetailBreed(this.id)
    .subscribe((x: any) => {
      var breed = x.content.Breed;
      this.f.Name.setValue(breed.Name);
      this.f.BreedId.setValue(breed.BreedId);
      this.f.Status.setValue(breed.Status);
      this.firstload = false;
    });

    this.form = this.formBuilder.group({
      Name: ['', Validators.required],
      BreedId: [1, Validators.required],
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
    this.breedService.UpdateBreed({ Id: this.id, ...this.form.value })
    .subscribe(() => {
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
