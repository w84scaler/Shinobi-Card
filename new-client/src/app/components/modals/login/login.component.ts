import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/services/account.service';
import { BsModalRef } from 'ngx-bootstrap/modal'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model: any = {}

  constructor(private accountService: AccountService, public bsModalRef: BsModalRef) { }

  ngOnInit(): void {

  }

  login(): void {
    this.accountService.login(this.model).subscribe(() => {
      this.model = {};
      this.bsModalRef.hide();
    })
  }

  cancel(): void{
    this.model = {};
    this.bsModalRef.hide();
  }
}
