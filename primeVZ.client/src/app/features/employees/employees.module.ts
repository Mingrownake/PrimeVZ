import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { FormsModule } from '@angular/forms';
import { EmployeeCardComponent } from './employee-card/employee-card.component';



@NgModule({
  declarations: [
    EmployeeListComponent,
    EmployeeCardComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    EmployeeListComponent
  ]
})
export class EmployeesModule { }
