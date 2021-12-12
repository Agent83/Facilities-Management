import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import {  CanActivate, } from '@angular/router';
import { Observable } from 'rxjs';
import { AccountService } from '../_services/account.service';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  constructor(private accountService: AccountService, private toastr: ToastrService) {}
  canActivate(): Observable<boolean>  {
    return this.accountService.currentUser$.pipe(
      map(user => {
        if (user.roles.includes('Admin') || user.roles.includes('SuperUser')){
          return true;
        }
        this.toastr.error('You cannot enter this area');
        
      })
    );
  }
  
}
