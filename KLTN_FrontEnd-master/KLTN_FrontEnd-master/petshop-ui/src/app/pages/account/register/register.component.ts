import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilderConvertData } from 'src/app/heplers/utils';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  form: FormGroup;
  loading = false;
  submitted = false;
  avatar : any;
  message = "";

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      Name: ['', Validators.required],
      Email: ['', [Validators.required, Validators.email,Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$')]],
      Phone: ['', Validators.required],
      Password: ['', Validators.required],
      RepeatPassword: ['', Validators.required],
      Address: ['', Validators.required],
      Avatar : null,
    });
  }

  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }
    
    this.loading = true;

    let formData = FormBuilderConvertData(this.form.value);
    formData.append('Avatar', this.avatar);
    
    this.accountService.register(formData)
        .subscribe((res: any) => {
          if(res.result == 0){
            this.message = res.message;
            this.loading = false;
          }
          else{
            this.message = '';
            this.router.navigate(["login"]);
          }
          
        }, error => {
            this.loading = false;
        });
  }

}
