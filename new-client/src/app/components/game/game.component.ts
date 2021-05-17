import { Component, OnInit } from '@angular/core';
import { Card } from 'src/app/models/card';
import { CardService } from 'src/app/services/card.service';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {

  cards: Card[] = [];
  gamerCards: Card[] = [];

  emptyCard = {
    id: 0,
    name: 'Secret',
    genjutsu: '?',
    ninjutsu: '?',
    taijutsu: '?',
    iconURL: 'https://res.cloudinary.com/shinobi-card/image/upload/v1620775173/fzih33aksqxuuatjcbsc.png'
  }

  randomCard: any = this.emptyCard;

  

  constructor(private cardService: CardService) { }

  ngOnInit(): void {
    this.loadGamerCards();
    this.loadCards();
  }

  getRandomCard() {
    let min = 0;
    let max = this.cards.length - 1;
    let rand = min + Math.random() * (max + 1 - min);
    this.randomCard = this.cards[Math.floor(rand)];
  }

  loadGamerCards() {
    this.cardService.getUserCards()
      .subscribe((cards) => {
        this.gamerCards = cards;
        this.getRandomCard();
      })
  }

  loadCards() {
    this.cardService.getCards()
      .subscribe((cards) => {
        this.cards = cards;
      })
  }
}
