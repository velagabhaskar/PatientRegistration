import { Component, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { PatientService } from '../../patient.service';
import { response } from 'express';
import { Router } from '@angular/router';
import { AgeCalculatorDirective } from '../../age-calculator.directive';
import { minAgeValidator } from '../../validators/minAgeValidator';


@Component({
  selector: 'app-add-patients',
  templateUrl: './add-patients.component.html',
  styleUrl: './add-patients.component.css'

})
export class AddPatientsComponent {
@Input()
minAge:number=0;
  patientForm: FormGroup;
  message:string="";

  constructor(private fb: FormBuilder,private service:PatientService,private router:Router) {
    this.patientForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      dateofBirth: ['', [Validators.required,minAgeValidator(15)]],    
      emailId: ['', [Validators.required, Validators.email, Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')]],

    });
  }

  onSubmit() {
    
    // Handle form submission here
    if (this.patientForm.valid)
     {
    
this.service.addPatient(this.patientForm.value).subscribe(async response=>{
if (response)
{
  this.message='Patient Added';
}
else
{
  this.message='Patient already exits';

}
},(error) => {
  // Handle error
  console.error('Error in component:', error);
})
      console.log('Form submitted:', this.patientForm.value);
    } else {
      console.log('Form is invalid. Please fix the errors.');
    }
  }

  onCancel() {
    this.router.navigateByUrl("/patientslist");
    }
}
