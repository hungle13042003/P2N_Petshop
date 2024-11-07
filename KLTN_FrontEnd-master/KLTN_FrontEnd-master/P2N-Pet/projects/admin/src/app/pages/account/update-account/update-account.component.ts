import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ChangeEnumToList, FormBuilderConvertData } from '../../../heplers/utils';
import { RoleSelection } from '../../../models/account';
import { StatusNormal } from '../../../models/status';
import { AccountService } from '../../../services/account.service';

@Component({
  selector: 'app-update-account',
  templateUrl: './update-account.component.html',
  styleUrls: ['./update-account.component.scss']
})
export class UpdateAccountComponent implements OnInit {

  id: string;
  form: FormGroup;
  loading = false;
  submitted = false;
  firstload = false;
  image: any;
  roleSelection: RoleSelection[];

  accountStatusText = StatusNormal;
  accountStatusOptions = [];

  message: string;

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService,
    private modalService: NgbModal) {
      this.message = '';
    this.buildSelection();
    this.getNormalRoleSelection();
  }

  ngOnInit() {
    this.firstload = true;
    this.id = this.route.snapshot.params['id'];

    this.accountService.GetDetailAccount(this.id)
    .subscribe((x: any) => {
      var account = x.content.user;
      this.f.ManagerId.setValue(this.id);
      this.f.Name.setValue(account.Name);
      this.f.Email.setValue(account.Email);
      this.f.Phone.setValue(account.Phone);
 //     this.f.Password.setValue(account.Password);
      this.f.Address.setValue(account.Address);
      this.f.RoleId.setValue(account.RoleId);
      this.f.Status.setValue(account.Status);
      this.f.AccountImage.setValue(account.Avatar);
      this.f.Password.setValue('');
      this.f.RepeatPassword.setValue('');
      this.firstload = false;
    });

    this.form = this.formBuilder.group({
      ManagerId: [0],
      Name: ['', Validators.required],
      Email: ['', Validators.required],
      Phone: ['', Validators.required],
      Password: null,
      RepeatPassword: null,
      Address: ['', Validators.required],
      RoleId: [30, Validators.required],
      Status: [10, Validators.required],
      AccountImage: null
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
    this.accountService.UpdateAccount(formData)
    .subscribe((res: any) => {
      if(res.result == 0){
        this.message = res.message;
        this.loading = false;
      }
      else{
        this.message = '';
        this.router.navigate(["admin/list-account"]);
      }
    }, error => {
      this.loading = false;
    });
  }

  buildSelection() {
   ChangeEnumToList(this.accountStatusText, this.accountStatusOptions);
  }

  getNormalRoleSelection(){
    this.loading = true;
    this.accountService.GetRoleSelection().subscribe((res: any) => {
      this.roleSelection = res.content.roles;
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
