import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.scss'
})
export class EmployeeListComponent implements OnInit {
  constructor(private employeeService: EmployeeService) {}

  form = new FormGroup({
    firstName: new FormControl("", [
      Validators.required,
      Validators.minLength(3)
    ]),
    lastName: new FormControl("", [
      Validators.required,
      Validators.minLength(3)
    ])
  });

  title: string = "Список сотрудников";

  employee$ = this.employeeService.employee$;
  loading$ = this.employeeService.loading$;
  error$ = this.employeeService.error$;
  toastState: boolean = false;

  ngOnInit(): void {
    this.employeeService.loadingEmployee();
  }

  addEmployee() {
    const formData = this.form.value;
    if (!formData.firstName || !formData.lastName) return;

    this.employeeService.addEmployee({
      firstName: formData.firstName,
      lastName: formData.lastName
    }).subscribe(() => {
      this.employeeService.loadingEmployee();
      this.form.reset();
      this.toastEffect();
    })
  }

  addTestEmployee() {
    console.log("Clicked");
    this.employeeService.addEmployee({
      firstName: "Test",
      lastName: "User"
    }).subscribe(() => {
      this.employeeService.loadingEmployee();
      this.toastEffect();
    })
  }

  toastEffect() {
    this.toastState = true;
    setTimeout(() => {
      this.toastState = false;
    }, 2000);
  }

  remove(index: number) {
    this.employeeService.remove(index);
  }
}
