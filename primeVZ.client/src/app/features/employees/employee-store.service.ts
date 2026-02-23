import { Injectable } from '@angular/core';
import { Employee } from './employee';
import { fa } from 'zod/v4/locales';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { BehaviorSubject, catchError, concatMap, debounceTime, distinctUntilChanged, EMPTY, map, Observable, of, Subject, switchMap, tap } from 'rxjs';

export interface EmployeeStore {
  employee: Employee[],
  loading: boolean,
  error: string | null,
  search: string
}

const initialEmployeeStore: EmployeeStore = {
  employee: [],
  loading: false,
  error:  null,
  search: ""
}

@Injectable({
  providedIn: 'root'
})
export class EmployeeStoreService {

  constructor(private httpClient: HttpClient) {
    this.connectSearchToLoad();
    this.connectCreate();
    this.connectRemove();
  }

  private stateSubject = new BehaviorSubject<EmployeeStore>(initialEmployeeStore);
  private state$ = this.stateSubject.asObservable();

  private create$ = new Subject<Omit<Employee, "id">>();
  private delete$ = new Subject<string>();
  
  employee$ = this.state$.pipe(map(v => v.employee))
  loading$ = this.state$.pipe(map(v => v.loading))
  error$ = this.state$.pipe(map(v => v.error))
  search$ = this.state$.pipe(map(v => v.search))

  private patch(state: Partial<EmployeeStore>) {
    this.stateSubject.next({...this.stateSubject.value, ...state})
  }

  setSearch(term: string) {
    this.patch({search: term})
  }

  createEmployee(emp: Omit<Employee, "id">) {
    this.create$.next(emp);
  }

  removeEmployee(id: string) {
    this.delete$.next(id);
  }

  reload() {
    this.load(this.stateSubject.value.search);
  }

  private connectSearchToLoad() {
    this.search$.pipe(
      debounceTime(400),
      distinctUntilChanged(),
      switchMap(value => 
         this.apiSearch(value)
      ),
      tap(() => this.patch({loading: false}))
    ).subscribe(value => {
      this.patch({employee: value})
    })
  }

  private connectCreate() {
    this.create$.pipe(
      tap(() => this.patch({loading: true, error: null})),
      concatMap(emp => {
        return this.httpClient.post<Omit<Employee, "id">>("/api/Employees", emp).pipe(
          catchError(() => {
            this.patch({error: "Ошибка добавления сотрудника"});
            return EMPTY
          })
        )
      }),
    ).subscribe(() => {
      this.reload()
    });
  }

  private connectRemove() {
    this.delete$.pipe(
      tap(() => this.patch({loading: true, error: null})),
      concatMap(value => {
        return this.httpClient.delete(`/api/Employees/${value}`).pipe(
          catchError(() => {
            this.patch({error: "Ошибка при удалении сотрудника"});
            return EMPTY
          })
        )
      })
    ).subscribe(() => {
      this.reload()
    })
  }

  private load(term: string) {
    this.patch({loading: true, error: null});
    this.apiSearch(term).subscribe(list => {
      this.patch({employee: list, loading: false})
    })
  }

  private apiSearch(term: string): Observable<Employee[]> {
    if (!term || term.trim().length < 3) {
      return this.httpClient.get<Employee[]>(`/api/Employees`).pipe(
        catchError((err: unknown) => {
          if (err instanceof HttpErrorResponse) {
            if (err.status === 404) {
              return of([] as Employee[])
            }
          }
          this.patch({error: "Неизвестная ошибка"});
          return of([] as Employee[])
        })
      );
    }
    let params = new HttpParams();
    params = params.set("term", term.trim());
    return this.httpClient.get<Employee[]>("/api/Employees", {params: params}).pipe(
      catchError((err: unknown) => {
        if (err instanceof HttpErrorResponse) {
            if (err.status === 404) {
              return of([] as Employee[])
            }
          }
          this.patch({error: "Неизвестная ошибка"});
          return of([] as Employee[])
      })
    );
  }
}
