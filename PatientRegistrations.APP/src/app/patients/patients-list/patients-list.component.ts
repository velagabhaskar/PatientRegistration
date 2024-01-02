import { AfterViewInit, Component, OnChanges, SimpleChanges, ViewChild } from '@angular/core';
import { PatientService } from '../../patient.service';
import { Patient } from '../../models/patient';
import { MatSort, Sort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { PopupService } from '../../popup.service';
import { ConfirmationpopupComponent } from '../../confirmationpopup/confirmationpopup.component';
import { MatDialog } from '@angular/material/dialog';
import { error } from 'console';
import { Observable, Observer, retry } from 'rxjs';
import { EditpatientComponent } from '../editpatient/editpatient.component';
@Component({
  selector: 'app-patients-list',
  templateUrl: './patients-list.component.html',
  styleUrl: './patients-list.component.css'
})
export class PatientsListComponent implements OnChanges
{

onButtonClick(_t60: any) {
throw new Error('Method not implemented.');
}
  data:Patient[]=[];
  dataSource: MatTableDataSource<Patient>;
displayedColumns: string[] = ['firstName', 'lastName', 'dateofBirth', 'emailId','actions'];


 
  constructor(private patientService:PatientService,private popupService: PopupService,public dialog: MatDialog) 
  {
   
    console.log("hello");
   this. dataSource=new  MatTableDataSource<Patient>();
  }
  ngOnChanges(changes: SimpleChanges): void {
  if (changes["rowList"]?.currentValue.lastName)
  {
    this.dataSource.sort=this.MatPatientSort;
  }
  }
  @ViewChild("MatPatientSort") MatPatientSort=new  MatSort();
  ngAfterViewInit() 
  {
    this.dataSource.sort = this.MatPatientSort;
  }
  async ngOnInit()   {
   
   await this. getPatientsList();

  }

  async getPatientsList()
  {

    await this.patientService.getallpatients().subscribe(
      async x=>{
       this.data=await x;
       this.dataSource=new MatTableDataSource<Patient>(this.data);
     
       console.log(this.data);
      }
     );
     console.log(await this.data);
  }

  openPopup(): void {
    // this.popupService.openPopup();
  }
  async editpatient(patient: any) {
    
   const patientInfo= await this.getPatient(patient.patientID);
    
    }
  
 async openDialog(item:any) {
    console.log(item);
    const dialogRef = this.dialog.open(ConfirmationpopupComponent,
       {
        width: '250px',
      data: {id: item.patientID, name: item.firstName +" "+item.lastName}
    });

    dialogRef.afterClosed().subscribe(result =>
       {
      console.log('The dialog was closed');
      
      this.deletePatient(result);
      console.log( result);
    });
  }
  
  async deletePatient(patientID: string) {
    
  await  this.patientService.DelePatient(patientID).subscribe(async response=>{
        if (response)
        { this.getPatientsList();}
    },
    error=>{
console.log(error);

    });
   
  }
  async getPatient(patientID: string) {
    
    this.patientService.getPatientbyId(patientID).
    subscribe(async (response) => 
    {
      const dialogRef = this.dialog.open(EditpatientComponent,
        {
          width: '600px',
        data:response
      });
      dialogRef.afterClosed().subscribe(result =>
        {
  this.patientService.updatePatient(result).subscribe(

    response=>{


    }
  );

          
        });
  
    return await response;
    }, error => {
      console.log(error);
return false;
    });
     
    }
 sortData(sort: Sort) {
   
    if (!sort.active || sort.direction === '') {
      this.dataSource.sort=this.MatPatientSort;
      return;
    }
  }
  
}
