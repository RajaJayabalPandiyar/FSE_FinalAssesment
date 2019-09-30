import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProjectManagerUserComponent } from './project-manager-user/project-manager-user.component';
import { ProjectManagerTaskComponent } from './project-manager-task/project-manager-task.component';
import { ProjectManagerProjectComponent } from './project-manager-project/project-manager-project.component';
import { TaskListComponent } from './project-manager-task/List/task-list/task-list.component';

const routes: Routes = [
  { path: 'projectmanageruser', component: ProjectManagerUserComponent },
  { path: 'projectmanagertask', component: ProjectManagerTaskComponent },
  { path: 'projectmanagerproject', component: ProjectManagerProjectComponent },
  { path: 'task-list', component: TaskListComponent }  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
