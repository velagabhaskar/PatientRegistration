import { Directive, ElementRef, Input, HostListener, OnChanges, SimpleChanges } from '@angular/core';
import { AbstractControl, FormControl, NG_VALIDATORS, ValidationErrors, Validator } from '@angular/forms';

import { minAgeValidator } from './validators/minAgeValidator'; // Import the validator function

@Directive({
  selector: 'AgeValidation',
  providers: [{ provide: NG_VALIDATORS, useExisting: AgeCalculatorDirective, multi: true }]
})
export class AgeCalculatorDirective implements Validator
 {
  @Input('AgeValidation') minAge: number=10;





  constructor(private el: ElementRef) 
  {
   
    
   }

   validate(control: AbstractControl): ValidationErrors | null {
    return minAgeValidator(this.minAge)(control);
  }
   
  }
  
  

