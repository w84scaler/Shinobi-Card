import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import {map} from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
//import { PresenceService } from './presence.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient/*, private presence: PresenceService*/) { }

  login(model:any){
    return this.http.post(this.apiUrl + 'account/login', model).pipe(
      map((user: User) =>{
        if (user) {
          this.setCurrentUser(user);
          //this.presence.createHubConnection(user);
        }
      })
    );
  }

  register(model: any){
    return this.http.post(this.apiUrl + "account/register", model).pipe(
      map( (user : User) => {
        if (user) {
          this.setCurrentUser(user);
          //this.presence.createHubConnection(user);
        }
        return user;
      })
    )
  }

  setCurrentUser(user: User){
    user.roles = [];
    const roles = this.getDecodedToken(user.token).role;
    Array.isArray(roles) ? user.roles = roles : user.roles.push(roles);
    localStorage.setItem('user', JSON.stringify(user));
    console.log(localStorage.getItem('user'));
  }

  logout(){
    localStorage.removeItem('user');
    //this.presence.stopHubConnection();
  }

  getDecodedToken(token){
    return JSON.parse(atob(token.split('.')[1]))
  }
}