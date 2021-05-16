import { Component } from '@angular/core';
import { User } from './models/user';
import { AccountService } from './services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Shinobi-Card';

  constructor(/*private presence: PresenceService, */private accountService: AccountService){

  }

  ngOnInit(){
    this.setCurrentUser(); 
  }

  setCurrentUser(){
    const user: User = JSON.parse(localStorage.getItem('user'));
    if (user) {
      this.accountService.setCurrentUser(user);
      //this.presence.createHubConnection(user);
    }
  }
}