import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: '[zc=card]',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss'],
})
export class CardComponent {
  @Input() header = '';
  @Input() submit!: string;
  @Output() submitClick = new EventEmitter();

  cardId = () => 'card-' + this.header.replace(' ', '');
}
