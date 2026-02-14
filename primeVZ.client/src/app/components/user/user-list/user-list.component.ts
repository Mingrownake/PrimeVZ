import { Component, OnDestroy, OnInit } from '@angular/core';
import { NewUserRequest, User, UserSchemaResponse } from '../../../models/user.model';
import { debounceTime, Subject, Subscription, takeUntil } from 'rxjs';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.scss'
})
export class UserListComponent implements OnInit, OnDestroy {
  public users: User[] = [];

  private destroy$ = new Subject<void>();
  private clickStream$ = new Subject<string>();
  private addUserStream$ = new Subject<any>();

  ngOnInit(): void {
    this.dataInit();

    this.clickStream$.pipe(
      debounceTime(500),
      takeUntil(this.destroy$)
    ).subscribe(value => {
      console.log("User name: ", value)
    })

    this.addUserStream$.pipe(
      debounceTime(500),
      takeUntil(this.destroy$)
    ).subscribe(data => {
      const result = NewUserRequest.safeParse(data);
      if (result.success) {
        this.users.push(data)
      } else {
        console.error("Inalid data: ", result.error);
      }
    })
  }

  private dataInit() {
    const rowData: User[] = [
      {
        id: "b3ada964-32f1-4a32-bbb5-3d33f20c6218",
        firstName: "Oleg",
        secondName: "Opus"
      },
      {
        id: "ce7148ec-b523-487b-833b-8ea032c8f86f",
        firstName: "Victor",
        secondName: "Izumin"
      }
    ];

    rowData.forEach(item => {
      const result = UserSchemaResponse.safeParse(item);
      if (result.success) {
        this.users.push(item)
      } else {
        console.error("Ошибка в данных: ", result.error);
      }
    });
  }

  public onUserClick(userName: string) {
    this.clickStream$.next(userName);
  }

  public removeUser(id: string)
  {
    this.users = this.users.filter(user => user.id != id);
  }

  public addUser(user: any) {
    this.addUserStream$.next(user);
  }

  public clearUsers() {
    this.users = [];
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.unsubscribe();
  }
}
