import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/User/user.service';
import { Router } from "@angular/router"; 
import { User } from '../../../User/user';
import { Select2OptionData } from 'ng-select2';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/delay';
import { TestBed } from '@angular/core/testing';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  users: User[];
  searchUsers: Array<Select2OptionData>;
  public startValue: Observable<string>;  
   
  constructor(private userService: UserService, private router: Router, ) { }  
  
  ngOnInit() {  
      localStorage.removeItem('editUserID');    
      this.getUsers();
      this.getUserDynamicList();  
      // this.startValue = Observable.create(obs => {
      // obs.next('dyn3');
      // obs.complete();
      // }).delay(6000);
  } 
  
  getUsers()
  {
    this.userService.getUsers()  
    .subscribe((data: User[]) => {
      this.users = data;      
      if(data.length == 0)  
      {
        alert("No users found");         
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
  
  deleteUser(user: User): void {  
    this.userService.deleteUser(user.userID)  
    .subscribe((data: any) => {
      if(data)
      {  
        alert("User deleted successfully");        
        this.getUsers();  
      }
      else
      {
        alert("User deletion failed due to server error, kindly try again");     
      }
    },  
    error => {  
      alert(error);  
    });   
  }
  
  editUser(user: User): void {  
    localStorage.removeItem('editUserID');  
    localStorage.setItem('editUserID', user.userID.toString());
    location.reload();
  }

  onSortF(){
    this.users = this.users.sort((a,b)=>a.firstName.localeCompare(b.firstName));
}

onSortL(){
  this.users = this.users.sort((a,b)=>a.lastName.localeCompare(b.lastName));
}

onSortID(){
  this.users = this.users.sort((a,b)=>a.userID.toString().localeCompare(b.userID.toString()));
}

onUserSelect(userSelected){
  if (userSelected != null)
  {
    this.userService.getUsers()  
    .subscribe((data: User[]) => {
      this.users = data;
      if(userSelected.value != null)
      {
      this.users = this.users.filter(x=> x.userID.toString() == userSelected.value); 
      }
      else
      {
      this.users = this.users.filter(x=> x.userID.toString() == userSelected);
      }      
      if(data.length == 0)  
      {
        alert("No users found");         
      }         
    });            
  }
}
}
