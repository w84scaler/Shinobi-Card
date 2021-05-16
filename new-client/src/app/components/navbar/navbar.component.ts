import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AccountService } from 'src/app/services/account.service';
import { LoginComponent } from '../modals/login/login.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  bsModalRef: BsModalRef;

  constructor(private accountService : AccountService, private router: Router, private bsModalService: BsModalService) { }

  ngOnInit(): void {
  }

  openLoginModal(){

    const config = {
      class: 'modal-dialog-centered',
      initialState: {

      }
    }

    this.bsModalRef = this.bsModalService.show(LoginComponent, config);
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}