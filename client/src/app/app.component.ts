import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Facilities Management';
  users: any;

  constructor( private accounntService: AccountService){}
  ngOnInit() {
  this.setCurrentUser();
  }

  setCurrentUser(){
    const storedUser = localStorage.getItem('user');
    if (!storedUser) {
      return;
    }

    const user: User = JSON.parse(storedUser);
    this.accounntService.setCurrentUser(user);
  }

}
