import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private employeeSubject = new BehaviorSubject([
    {firstName: "Nikita", lastName: "Vozhegov"},
    {firstName: "Oleg", lastName: "Kozhechko"}
  ])

  employee$ = this.employeeSubject.asObservable();

  addEmployee(emp: {firstName: string, lastName: string}) {
    const current = this.employeeSubject.value;
    this.employeeSubject.next([...current, emp])
  }

  remove(index: number) {
    const current = this.employeeSubject.value;
    current.splice(index, 1);
  }
}
