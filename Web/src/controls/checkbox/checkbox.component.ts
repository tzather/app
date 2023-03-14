import { Component, forwardRef, Input } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { BaseControlComponent } from '../baseControl';

@Component({
  selector: 'zc-checkbox',
  templateUrl: './checkbox.component.html',
  providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: forwardRef(() => CheckboxComponent), multi: true }],
})
export class CheckboxComponent extends BaseControlComponent implements ControlValueAccessor {
  @Input() field!: string; // the field of the model bound to this control
  @Input() label!: string; // label for the field
  @Input() forTable: boolean = false; // render control to be displayed inside table

  // get/set value
  private _checked = '';
  get checked(): string {
    return this._checked;
  }
  set checked(v: string) {
    if (this._checked !== v) {
      this._checked = v;
      this.onChangeCallback(v);
    }
  }

  writeValue(v: string) {
    if (this._checked !== v) {
      this._checked = v;
    }
  }
}
