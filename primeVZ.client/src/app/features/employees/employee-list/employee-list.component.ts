import { Component } from '@angular/core';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.scss'
})
export class EmployeeListComponent {
  constructor(private employeeService: EmployeeService) {

  }
  title: string = "Список сотрудников";

  firstName: string = "";
  lastName: string = "";

  employee$ = this.employeeService.employee$;

  onAdd() {
    if (!this.firstName || !this.lastName) return
    this.employeeService.addEmployee({
      firstName: this.firstName,
      lastName: this.lastName
    });

    this.firstName = "";
    this.lastName = "";
  }

  remove(index: number) {
    this.employeeService.remove(index);
  }


}
