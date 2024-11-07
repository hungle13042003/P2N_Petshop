import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ChangeEnumToList } from '../../../heplers/utils';
import { RoleSelection } from '../../../models/account';
import { StatusNormal } from '../../../models/status';
import { AccountService } from '../../../services/account.service';

@Component({
  selector: 'app-view-account',
  templateUrl: './view-account.component.html',
  styleUrls: ['./view-account.component.scss']
})
export class ViewAccountComponent implements OnInit {

  id: string;
  form: FormGroup;
  loading = false;
  submitted = false;
  firstload = false;
  image: any;
  roleSelection: RoleSelection[];

  accountStatusText = StatusNormal;
  accountStatusOptions = []

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService,
    private modalService: NgbModal) {
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
      this.f.Address.setValue(account.Address);
      this.f.RoleId.setValue(account.RoleId);
      this.f.Status.setValue(account.Status);
      this.f.AccountImage.setValue(account.Avatar);
      this.firstload = false;
    });

    this.form = this.formBuilder.group({
      ManagerId: [0],
      Name: ['', Validators.required],
      Email: ['', Validators.required],
      Phone: ['', Validators.required],
      Address: ['', Validators.required],
      RoleId: [30, Validators.required],
      Status: [10, Validators.required],
      AccountImage: null
    });

    this.form.disable();
  }

  get f() { return this.form.controls; }

  ngAfterViewInit() {

  }

  buildSelection() {
   ChangeEnumToList(this.accountStatusText, this.accountStatusOptions);
  }

  getNormalRoleSelection(){
    this.loading = true;
    this.accountService.GetRoleSelection().subscribe((res: any) => {
      this.roleSelection = res.content.roles;

      let roleAdmin: RoleSelection =
        {
          RoleId: 10, 
          RoleName: 'Quản trị viên'
        };
      
      this.roleSelection.push(roleAdmin);
      
      this.loading = false;
    });
  }
}
