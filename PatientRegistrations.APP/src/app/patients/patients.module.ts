import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedMaterialModule } from '../shared-material/shared-material.module';
import { PatientsRoutingModule } from './patients-routing.module';
import { AddPatientsComponent } from './add-patients/add-patients.component';
import { AgeCalculatorDirective } from '../age-calculator.directive';
import { PatientsListComponent } from './patients-list/patients-list.component';
import { PopupComponent } from '../popup/popup.component';
import { PopupService } from '../popup.service';
import { EditpatientComponent } from './editpatient/editpatient.component';
import { minAgeValidator } from '../validators/minAgeValidator';




@NgModule({
  declarations:
   [
  AddPatientsComponent,
  AgeCalculatorDirective,

  PatientsListComponent,
  PopupComponent,
  EditpatientComponent
  ],
  imports: [
    SharedMaterialModule,
    PatientsRoutingModule,
    CommonModule,
    
    FormsModule, 
    ReactiveFormsModule,
    
    
   
    
  ],
  
  exports:[  ]
})
export class PatientsModule { }
