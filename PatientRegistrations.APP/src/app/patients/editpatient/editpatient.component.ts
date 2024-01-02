import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Init } from 'v8';
import { minAgeValidator } from '../../validators/minAgeValidator';

@Component({
  selector: 'app-editpatient',
  templateUrl: './editpatient.component.html',
  styleUrl: './editpatient.component.css'
})
export class EditpatientComponent implements OnInit {



  patientData:any;
  patientForm: FormGroup;
  constructor(private fb: FormBuilder,
    public dialogRef: MatDialogRef<EditpatientComponent>,
    @Inject(MAT_DIALOG_DATA) public data:any
  ) { 

    this.patientForm = this.fb.group({
      patientID:'',
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
    dateofBirth: ['', Validators.required],
   
      emailId: ['', [Validators.required, Validators.email, Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')]],

    });
    this.patientData=data;
  }
  ngOnInit(): void {

    console.log(this.patientData);
    this.patientForm.patchValue(this.patientData);
     
    
  }
  save()
  {
   if (this.patientForm.valid) {
     // Save the data
     // Close the dialog
     this.dialogRef.close(this.patientForm.value);
   }
 }
 Cancel() {
  this.dialogRef.close();
  }
}
