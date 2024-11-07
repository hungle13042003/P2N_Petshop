import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilderConvertData } from 'src/app/heplers/utils';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  id: string;
  name: any;
  phone: any;
  email: any;
  form: FormGroup;
  loading = false;
  submitted = false;
  firstload = false;
  image: any;

  address: any;
  message: string;
  isDisabled = true;

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private modalService: NgbModal) {
      this.message = '';
  }

  ngOnInit() {
    this.firstload = true;
    this.id = this.route.snapshot.params['id'];

    this.userService.getProfile()
    .subscribe((x: any) => {
      var account = x.content.user;

      this.name = account.Name;
      this.email = account.Email;
      this.phone = account.Phone;
      this.address = account.Address;

      this.f.Id.setValue(account.Id);
      this.f.Name.setValue(account.Name);
      this.f.Email.setValue(account.Email);
      this.f.Phone.setValue(account.Phone);
      this.f.Address.setValue(account.Address);
      // this.f.AccountImage.setValue(account.Avatar);

      this.firstload = false;
    });

    this.form = this.formBuilder.group({
      Id: [0],
      Name: ['', Validators.required],
      Email: ['', Validators.required],
      Phone: ['', Validators.required],
      Address: null,
      Avatar: null
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
    formData.append('Avatar', this.image);

    this.userService.EditProfile(formData).subscribe((res: any) => {
      if(res.result == 0){
        this.message = res.message;
        this.loading = false;
      }
      else{
        this.message = '';
        let currentUrl = this.router.url;
        this.router.routeReuseStrategy.shouldReuseRoute = () => false;
        this.router.onSameUrlNavigation = 'reload';
        this.router.navigate([currentUrl]);
      }
    }, error => {
      this.loading = false;
    });
  }

  enable(){
    this.isDisabled = false;
  }

}
