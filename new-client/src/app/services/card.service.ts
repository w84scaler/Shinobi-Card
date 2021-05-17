import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment'
import { Card } from '../models/card'
import { HttpClient } from '@angular/common/http'
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CardService {

  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCards() {
    return this.http.get<Card[]>(this.apiUrl + 'card');
  }
  
  getUserCards() {
    return this.http.get<Card[]>(this.apiUrl + 'card/user');
  }
}
