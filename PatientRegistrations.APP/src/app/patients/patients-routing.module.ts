import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddPatientsComponent } from './add-patients/add-patients.component';
import { PatientsListComponent } from './patients-list/patients-list.component';

const routes: Routes = [

{ path: '', component: AddPatientsComponent },
{ path: 'patientslist', component: PatientsListComponent }];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PatientsRoutingModule { }
