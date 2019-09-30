import { Component, OnInit } from '@angular/core';
import { User } from '../User/user';
import { UserService } from '../User/user.service';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";  

@Component({
  selector: 'app-project-manager-user',
  templateUrl: './project-manager-user.component.html',
  styleUrls: ['./project-manager-user.component.css']
})
export class ProjectManagerUserComponent implements OnInit {

  supplierformlabel: string = 'Add User';   
  constructor(private formBuilder: FormBuilder, private router: Router, private userService: UserService) {  
  }  
  
  addForm: FormGroup;  
  btnvisibility: boolean = true;  
  ngOnInit() {  
  
    this.addForm = this.formBuilder.group({      
      firstName: ['', [Validators.required]],  
      lastName: ['', Validators.required],  
      employeeID: ['', Validators.required]
    });  
  
    let userID = localStorage.getItem('editUserID');  
    if (userID != undefined && userID != '') {      
      this.userService.searchUser(userID).subscribe(data => {  
        this.addForm.patchValue(data);        
      })  
      this.btnvisibility = false;      
    }   
  }  
  onSubmit() {
    this.userService.createUser(this.addForm.value)  
    .subscribe((data: any) => {
      if(data)
      {  
        alert("User added successfully");
        location.reload();        
      }
      else
      {
        alert("User add failed due to server error, kindly check for duplicate record and try again");     
      }
    },  
    error => {  
      alert(error);  
    });  
  }  
  onUpdate() {      
    this.userService.updateSupplier(this.addForm.value).subscribe((data: any) => {
      if(data)
      {  
        alert("User updated successfully");        
        localStorage.removeItem('editSupplierNo');   
        location.reload();     
      }
      else
      {
        alert("User update failed due to server error, kindly try again");     
      }
    },  
    error => {  
      alert(error);  
    });
  }

  onReset() {      
    this.addForm = this.formBuilder.group({      
      firstName: ['', [Validators.required]],  
      lastName: ['', Validators.required],  
      employeeID: ['', Validators.required]
    });
  }
}
