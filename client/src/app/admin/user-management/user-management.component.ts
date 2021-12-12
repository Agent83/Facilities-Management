import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { RolesModalComponent } from 'src/app/modal/roles-modal/roles-modal.component';
import { User } from 'src/app/_models/user';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.css']
})
export class UserManagementComponent implements OnInit {
  users: Partial<User[]>;
  nzModalRef: BsModalRef;
  constructor(private adminService: AdminService, private modalService: BsModalService) { }

  ngOnInit(): void {
    this.getUsersWithRoles();
  }


  getUsersWithRoles(){
    this.adminService.getUserWithRoles().subscribe(users => {
      this.users = users;
    })
  }

  openRolesModal(){
   const initialState = {
     list:[
      'open a model with a component',
      'pass your data',
      'Do something else'
     ],
     title: 'modal with component'
   }
    this.nzModalRef = this.modalService.show(RolesModalComponent, {initialState});
    this.nzModalRef.content.closeBtnName = 'Close';
  }


}
