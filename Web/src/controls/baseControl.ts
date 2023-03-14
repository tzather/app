export class BaseControlComponent {
  protected noop = () => {};
  protected onTouchedCallback: () => void = this.noop;
  protected onChangeCallback: (_: any) => void = this.noop;
  registerOnChange(fn: any): void {
    this.onChangeCallback = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouchedCallback = fn;
  }
}
