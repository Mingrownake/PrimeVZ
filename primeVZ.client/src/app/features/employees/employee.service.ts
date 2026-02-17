import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, finalize, Observable, of } from 'rxjs';
import { Employee } from './employee';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private employeeSubject = new BehaviorSubject<Employee[]>([]);
  employee$ = this.employeeSubject.asObservable();

  private loadingSubject = new BehaviorSubject<boolean>(false);
  loading$ = this.loadingSubject.asObservable();

  private errorSubject = new BehaviorSubject<string | null>(null);
  error$ = this.errorSubject.asObservable();

  constructor(private httpClient: HttpClient) {

  }

  loadingEmployee() {
    this.loadingSubject.next(true);
    this.errorSubject.next(null);

    this.httpClient
      .get<Employee[]>("/api/Employees")
      .pipe(
        catchError(() => {
          this.errorSubject.next("Ошибка при получении сотрудников");
          return of([] as Employee[])
        }),
        finalize(() => {
          this.loadingSubject.next(false);
        })
      )
      .subscribe(employees => {
        this.employeeSubject.next(employees);
      })
  }

  addEmployee(emp: {firstName: string, lastName: string}): Observable<Employee> {
    return this.httpClient.post<Employee>("/api/employees", emp);
  }

  remove(index: number) {
    const current = this.employeeSubject.value;
    current.splice(index, 1);
  }
}
