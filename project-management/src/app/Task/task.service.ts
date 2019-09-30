import { Task } from './task';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { AppHttpService } from 'src/app/app-http.service';
import { Select2OptionData } from 'ng-select2';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor(private http: HttpClient, private appHttpService : AppHttpService) { }  
  baseUrl: string = 'http://localhost:61012/api/task/';  
  
  getTasks(): Observable<Task[]> {
    return this.http.get<Task[]>(this.baseUrl + 'get')
      .pipe(
        tap(_ => this.appHttpService.log('fetched tasks')),
        catchError(this.appHttpService.handleError)
      );
  }

  getParentTaskList(): Observable<Array<Select2OptionData>> {
    return this.http.get<Array<Select2OptionData>>(this.baseUrl + 'getParentTasks')
      .pipe(
        tap(_ => this.appHttpService.log('fetched parent task List')),
        catchError(this.appHttpService.handleError)
      );
  } 
  
  deleteTask(taskID: number) {  
    return this.http.delete(this.baseUrl + 'delete/' + taskID)
    .pipe(
      tap(_ => this.appHttpService.log('deleted Task')),
      catchError(this.appHttpService.handleError)
    );
  }  

  createTask(task: Task) {  
    return this.http.post(this.baseUrl + 'add', task)
    .pipe(
      tap(_ => this.appHttpService.log('created Task')),
      catchError(this.appHttpService.handleError)
    );
  }

  searchTask(taskID: string) {  
    return this.http.get<Task>(this.baseUrl + 'search/' + taskID)
    .pipe(
      tap(_ => this.appHttpService.log('searched Task')),
      catchError(this.appHttpService.handleError)
    );  
  }

  updateTask(task: Task) {  
    return this.http.put(this.baseUrl + 'update', task)
    .pipe(
      tap(_ => this.appHttpService.log('updated Task')),
      catchError(this.appHttpService.handleError)
    ); 
  }
}