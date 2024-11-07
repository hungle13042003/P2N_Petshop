import { Component, OnInit, ElementRef } from '@angular/core';
import { PETDETAILS, PETEXTRAS, ROUTES } from '../sidebar/sidebar.component';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { Router } from '@angular/router';
import { AccountService } from '../../services/account.service';
import { User } from '../../models/account';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  public focus;
  public listTitles: any[];
  public location: Location;
  user: User;


  constructor(location: Location,  private element: ElementRef, private router: Router, private accountService: AccountService) {
    this.location = location;

    this.accountService.getProfile().subscribe((output: any) => {
        if(output.content.user){
          this.user = output.content.user;
        }
       else {
          this.user = new User();
          this.user.Name = '';
          this.user.Role = 30;
        }
      });
    }

  ngOnInit() {
    this.listTitles = ROUTES.filter(listTitle => listTitle);

    PETDETAILS.filter(listTitle => listTitle).forEach(a =>{
      this.listTitles.push(a);
    });

    PETEXTRAS.filter(listTitle => listTitle).forEach(a =>{
      this.listTitles.push(a);
    });
  }
  getTitle(){
    var titlee = this.location.prepareExternalUrl(this.location.path());
    if(titlee.charAt(0) === '#'){
        titlee = titlee.slice( 1 );
    }

    for(var item = 0; item < this.listTitles.length; item++){
        if(this.listTitles[item].path === titlee){
            return this.listTitles[item].title;
        }
    }
    return 'Thú cưng P2N';
  }

  logout() {
    this.accountService.logout();
  }
}
