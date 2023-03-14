import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

// controls
import { ButtonComponent } from './button/button.component';
import { CardComponent } from './card/card.component';
import { CheckboxComponent } from './checkbox/checkbox.component';
import { TextComponent } from './text/text.component';
import { ToastComponent } from './toast/toast.component';

@NgModule({
  declarations: [ButtonComponent, CardComponent, CheckboxComponent, TextComponent, ToastComponent],
  imports: [CommonModule, FormsModule],
  exports: [ButtonComponent, CardComponent, CheckboxComponent, TextComponent, ToastComponent],
})
export class ControlsModule {}
