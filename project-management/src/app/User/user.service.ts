import { User } from './user';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { AppHttpService } from 'src/app/app-http.service';
import { Select2OptionData } from 'ng-select2';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private appHttpService : AppHttpService) { }  
  baseUrl: string = 'http://localhost:61012/api/user/';  
  
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'get')
      .pipe(
        tap(_ => this.appHttpService.log('fetched users')),
        catchError(this.appHttpService.handleError)
      );
  } 
  
  getUserList(): Observable<Array<Select2OptionData>> {
    return this.http.get<Array<Select2OptionData>>(this.baseUrl + 'getUsers')
      .pipe(
        tap(_ => this.appHttpService.log('fetched user List')),
        catchError(this.appHttpService.handleError)
      );
  } 
  
  deleteUser(userID: number) {  
    return this.http.delete(this.baseUrl + 'delete/' + userID)
    .pipe(
      tap(_ => this.appHttpService.log('deleted User')),
      catchError(this.appHttpService.handleError)
    );
  }  

  createUser(user: User) {  
    return this.http.post(this.baseUrl + 'add', user)
    .pipe(
      tap(_ => this.appHttpService.log('created User')),
      catchError(this.appHttpService.handleError)
    );
  }

  searchUser(userID: string) {  
    return this.http.get<User>(this.baseUrl + 'search/' + userID)
    .pipe(
      tap(_ => this.appHttpService.log('searched User')),
      catchError(this.appHttpService.handleError)
    );  
  }

  updateSupplier(user: User) {  
    return this.http.put(this.baseUrl + 'update', user)
    .pipe(
      tap(_ => this.appHttpService.log('updated User')),
      catchError(this.appHttpService.handleError)
    ); 
  }
}