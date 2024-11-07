import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilderConvertData } from '../../../heplers/utils';
import { AccountService } from '../../../services/account.service';

@Component({
  selector: 'app-profile-user',
  templateUrl: './profile-user.component.html',
  styleUrls: ['./profile-user.component.scss']
})
export class ProfileUserComponent implements OnInit {

  id: string;
  name: string;
  rolename: string;
  phone: string;
  email: string;
  imageaccount: string;
  form: FormGroup;
  loading = false;
  submitted = false;
  firstload = false;
  image: any;

  message: string;

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService,
    private modalService: NgbModal) {
      this.message = '';
  }

  ngOnInit() {
    this.firstload = true;
    this.id = this.route.snapshot.params['id'];

    this.accountService.getProfile()
    .subscribe((x: any) => {
      var account = x.content.user;
      this.f.Id.setValue(account.Id);
      this.f.Name.setValue(account.Name);
      this.f.Email.setValue(account.Email);
      this.f.Phone.setValue(account.Phone);
      this.f.Address.setValue(account.Address);
      this.f.AccountImage.setValue(account.Avatar);

      this.name = account.Name;
      this.email = account.Email;
      this.phone = account.Phone;
      this.rolename = account.RoleName;
      this.imageaccount = account.Avatar;
 //     this.f.Status.setValue(account.Status);
      this.firstload = false;
    });

    this.form = this.formBuilder.group({
      Id: [0],
      Name: ['', Validators.required],
      Email: ['', Validators.required],
      Phone: ['', Validators.required],
      Address: null,
      AccountImage: null
//      Status: [10, Validators.required]
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
    this.accountService.EditProfile(formData)
    .subscribe((res: any) => {
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

  onFileChange(event) {
    if (event.target.files && event.target.files.length) {
      let thatForm = this.f;
      const [file] = event.target.files;

      var reader = new FileReader();
      reader.onload = function (e) {
        thatForm.AccountImage.setValue(e.target.result);
      }

      this.image = file;
      reader.readAsDataURL(file);
    }
  }

}
