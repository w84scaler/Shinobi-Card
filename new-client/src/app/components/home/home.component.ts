import { Component, OnInit } from '@angular/core';
import { Card } from 'src/app/models/card';
import { CardService } from 'src/app/services/card.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  cards: Card[] = [];

  constructor(private cardService: CardService) { }

  ngOnInit(): void {
    this.loadCards();
  }

  loadCards() {
    this.cardService.getCards()
      .subscribe((cards) => {
        this.cards = cards;
        console.log(this.cards);
      })
  }
}
