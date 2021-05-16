import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let currUser: User = JSON.parse(localStorage.getItem('user'));
    if (currUser) {
      request = request.clone({
        setHeaders:{
          Authorization: `Bearer ${currUser.token}`
        }
      })
    }
    return next.handle(request);
  }
}