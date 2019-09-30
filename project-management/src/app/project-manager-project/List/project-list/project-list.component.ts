import { Component, OnInit } from '@angular/core';
import { ProjectService } from 'src/app/Project/project.service';
import { Router } from "@angular/router"; 
import { Project } from '../../../Project/project';
import { Select2OptionData } from 'ng-select2';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css']
})
export class ProjectListComponent implements OnInit {

  projects: any; 
  searchProjects: Array<Select2OptionData>; 
  
  constructor(private projectService: ProjectService, private router: Router, ) { }  
  
  ngOnInit() { 
      localStorage.removeItem('editProjectID')    
      this.getProjects();  
      this.getProjectDynamicList();  
  } 

  getProjects()
  {
      this.projectService.getProjects()  
      .subscribe((data: Project[]) => {
        this.projects = data;  
        if(data.length == 0)  
        {
          alert("No projects found");          
        }         
      });
  }

  getProjectDynamicList(){
    this.projectService.getProjectList()  
    .subscribe((data: Array<Select2OptionData>) => {
      this.searchProjects = data;      
      if(data.length == 0)  
      {
        alert("No user List found");         
      }         
    }); 
}

updateProject(project: Project): void {  
  localStorage.removeItem('editProjectID');  
  localStorage.setItem('editProjectID', project.projectID.toString());
  location.reload();
}

suspendProject(project: Project): void {  
  this.projectService.deleteProject(project.projectID)  
    .subscribe((data: any) => {
      if(data)
      {  
        alert("Project deleted successfully");        
        this.getProjects();  
      }
      else
      {
        alert("Project deletion failed due to server error, kindly try again");     
      }
    },  
    error => {  
      alert(error);  
    }); 
}
  
  editProject(project: Project): void {  
    localStorage.removeItem('editProjectID');  
    localStorage.setItem('editProjectID', project.projectID.toString());  
    this.router.navigate(['projectmanagerproject']);  
  }
}
