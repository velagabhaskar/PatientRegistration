import { AbstractControl, ValidatorFn, ValidationErrors, AsyncValidatorFn } from '@angular/forms';

export function minAgeValidator(minAge: number): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
   
     
        if (control.value) {
          const birthDate = new Date(control.value);
          const today = new Date();
          const age = today.getFullYear() - birthDate.getFullYear();

          if (age < minAge) {
          return {minAge:true}  // Validation failed
          } else {
return {  }
          }
        } else {
        
        return {}  // If there is no value, consider it as valid
        }
    
   
  };
}
