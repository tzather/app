import { Component } from '@angular/core';

@Component({
  selector: 'nc-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss'],
})
export class UserComponent {
  async save() {
    alert(1);
  }
}
