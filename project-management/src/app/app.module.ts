import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProjectManagerUserComponent } from './project-manager-user/project-manager-user.component';
import { ProjectManagerTaskComponent } from './project-manager-task/project-manager-task.component';
import { ProjectManagerProjectComponent } from './project-manager-project/project-manager-project.component';
import { TaskListComponent } from './project-manager-task/List/task-list/task-list.component';
import { ProjectListComponent } from './project-manager-project/List/project-list/project-list.component';
import { UserListComponent } from './project-manager-user/List/user-list/user-list.component';
import { NgSelect2Module   } from 'ng-select2';
@NgModule({
  declarations: [
    AppComponent,   
    ProjectManagerUserComponent, ProjectManagerTaskComponent, ProjectManagerProjectComponent, TaskListComponent, ProjectListComponent, UserListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgSelect2Module      
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
