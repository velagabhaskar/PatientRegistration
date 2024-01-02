
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule, matFormFieldAnimations} from '@angular/material/form-field';
import {FormsModule} from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatNativeDateModule } from '@angular/material/core';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { AgeCalculatorDirective } from '../age-calculator.directive';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatSort, MatSortModule} from '@angular/material/sort';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';


@NgModule({
  declarations: [],
imports: [FormsModule,MatFormFieldModule, MatButtonModule, MatIconModule,MatInputModule,MatCardModule,MatNativeDateModule,MatDatepickerModule,MatTableModule ,MatSortModule, MatPaginatorModule],
  exports: [FormsModule,MatFormFieldModule,MatButtonModule, MatIconModule,MatInputModule,MatCardModule,MatNativeDateModule,MatDatepickerModule,MatTableModule ,MatSortModule, MatPaginatorModule]
})
export class SharedMaterialModule { }
