import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";  
import { ProjectService } from 'src/app/Project/project.service';
import { UserService } from 'src/app/User/user.service';
import { DatePipe } from '@angular/common';
import { Select2OptionData } from 'ng-select2';
import * as $ from 'jquery';
import { formatDate } from '@angular/common';

interface Post {
  startDate: Date;
  endDate: Date;
}

@Component({
  selector: 'app-project-manager-project',
  templateUrl: './project-manager-project.component.html',
  styleUrls: ['./project-manager-project.component.css'],
  providers:[DatePipe]
})
export class ProjectManagerProjectComponent implements OnInit {

  searchProjects: Array<Select2OptionData>; 
  searchUsers: Array<Select2OptionData>;
  
  post: Post = {
    startDate: new Date(Date.now()),
    endDate: new Date(new Date(Date.now()).getTime() + 1000 * 60 * 60 * 24)
  }

  constructor(private formBuilder: FormBuilder, private router: Router, private projectService: ProjectService, private userService: UserService, private datePipe: DatePipe) {  
  }  
  
  addForm: FormGroup;
  btnvisibility: boolean = true;  
  ngOnInit() {  
  
    this.addForm = this.formBuilder.group({      
      projectName: ['', [Validators.required]],   
      startDate: [formatDate(this.post.startDate, 'yyyy-MM-dd', 'en'), [Validators.required]],
      endDate: [formatDate(this.post.endDate, 'yyyy-MM-dd', 'en'), [Validators.required]],
      setStartDateEndDate: [], 
      priority: [], 
      managerName: []      
    });  
  
    let projectID = localStorage.getItem('editProjectID');
    if (projectID != undefined && projectID != '') {      
      this.projectService.searchProject(projectID).subscribe(data => {  
        this.addForm.patchValue(data);        
      })  
      this.btnvisibility = false;          
    } 

    this.getProjectDynamicList();
    this.getUserDynamicList();
  }
  changeValue(e){
    var isChecked = e.target.checked;
if(isChecked){
  $("#setStartDateEndDate").parent().next().show();
  $("#setStartDateEndDate").parent().next().next().show();
}else{
  $("#setStartDateEndDate").parent().next().hide();
  $("#setStartDateEndDate").parent().next().next().hide();
}

}
  getProjectDynamicList(){
    this.projectService.getProjectList()  
    .subscribe((data: Array<Select2OptionData>) => {
      this.searchProjects = data;      
      if(data.length == 0)  
      {
        alert("No project List found");         
      }         
    }); 
}

getUserDynamicList(){
  this.userService.getUserList()  
  .subscribe((data: Array<Select2OptionData>) => {
    this.searchUsers = data;      
    if(data.length == 0)  
    {
      alert("No user List found");         
    }         
  }); 
}

  onSubmit() {
    this.projectService.createProject(this.addForm.value)  
      .subscribe((data: any) => {
        if(data)
        {  
          alert("Project added successfully");        
          location.reload();
        }
        else
        {
          alert("Project add failed due to server error, kindly check whether Supplier No and Item Code exists and try again");     
        }
      },  
      error => {  
        alert(error);  
      });  
  }  
  onUpdate() {      
    this.projectService.updateProject(this.addForm.value).subscribe((data: any) => {
      if(data)
      {  
        alert("Project updated successfully");        
        localStorage.removeItem('editProjectID') 
        this.ngOnInit(); 
      }
      else
      {
        alert("Project update failed due to server error, kindly try again");     
      }
    },  
    error => {  
      alert(error);  
    });
  }

  onReset() {      
    this.addForm = this.formBuilder.group({      
      projectName: ['', [Validators.required]],   
      startDate: [],  
      endDate: [],  
      priority: [], 
      managerName: []      
    });
  }
}
