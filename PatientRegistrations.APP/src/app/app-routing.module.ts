import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PatientsListComponent } from './patients/patients-list/patients-list.component';

const routes: Routes = [
  {path:"",component:PatientsListComponent},
  { path: 'newpatient', loadChildren: () => import('./patients/patients.module').then(m => m.PatientsModule),
 },

{ path: '', loadChildren: () => import('./patients/patients.module').then(m => m.PatientsModule),
},

];



@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
