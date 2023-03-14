import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'zc-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss'],
})
export class ButtonComponent {
  @Input() id!: string; // the id of the button
  @Input() text!: string; // the text of teh button
  @Output() onclick = new EventEmitter();
}
