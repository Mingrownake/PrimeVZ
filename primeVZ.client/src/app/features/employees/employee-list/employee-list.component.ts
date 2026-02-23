import { EmployeeStoreService } from './../employee-store.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Employee } from '../employee';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css'
})
export class EmployeeListComponent implements OnInit {
  constructor(private store: EmployeeStoreService) {}

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

  searchControll = new FormControl("");

  title: string = "Список сотрудников";

  employee$ = this.store.employee$;
  loading$ = this.store.loading$;
  error$ = this.store.error$;

  ngOnInit(): void {
    this.store.setSearch("");
    this.searchControll.valueChanges.subscribe(v => {
      this.store.setSearch(v ?? "")
    })
  }

  addEmployee() {
    const formData = this.form.value;
    if (!formData.firstName || !formData.lastName) return;
    const emp: Omit<Employee, "id"> = {
      firstName: formData.firstName,
      lastName: formData.lastName
    }
    this.store.createEmployee(emp)
    this.form.reset()
  }

  refresh() {
    this.store.reload();
  }

  remove(employeeId: string) {
    this.store.removeEmployee(employeeId)
  }
}
