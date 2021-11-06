import { Component, Input, OnInit, Self } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';

@Component({
  selector: 'app-texarea-input',
  templateUrl: './texarea-input.component.html',
  styleUrls: ['./texarea-input.component.css']
})
export class TexareaInputComponent implements ControlValueAccessor {
 @Input() label: string;

  constructor(@Self() public ngControl: NgControl) {
    this.ngControl.valueAccessor = this;
   }

  writeValue(obj: any): void {
  }
  registerOnChange(fn: any): void {
  }
  registerOnTouched(fn: any): void {
  }


}
