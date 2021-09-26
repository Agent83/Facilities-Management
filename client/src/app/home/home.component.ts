import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  model: any = {}
  registerMode = false;
  constructor(public accountService: AccountService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  login (){
    this.accountService.login(this.model).subscribe(resopnse => {
      this.router.navigateByUrl('/members');
       });
   }
  
   logout(){
     this.accountService.logout();
     this.router.navigateByUrl('/');
   }
   
  registerToggle(){
    this.registerMode = true;
  }
  
  cancelRegisterMode(event: boolean){
    this.registerMode = event;
  }
}
