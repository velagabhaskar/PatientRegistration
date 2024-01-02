import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-confirmationpopup',
  templateUrl: './confirmationpopup.component.html',
  styleUrl: './confirmationpopup.component.css'
})
export class ConfirmationpopupComponent {
  Data:any;
  constructor(
    public dialogRef: MatDialogRef<ConfirmationpopupComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { name: string,id:string}
  ) { 
this.Data=data;

  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onYesClick(id:string): void {
    this.dialogRef.close(id);
  }
}
