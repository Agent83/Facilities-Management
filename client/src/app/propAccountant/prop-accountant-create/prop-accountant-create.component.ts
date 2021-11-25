import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PropAccountantService } from 'src/app/_services/prop-accountant.service';
import { Location } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-prop-accountant-create',
  templateUrl: './prop-accountant-create.component.html',
  styleUrls: ['./prop-accountant-create.component.css']
})
export class PropAccountantCreateComponent implements OnInit {
  propAccForm: FormGroup;
  validationErrors: string[] = [];
  constructor(private location: Location, private fb: FormBuilder,
    private router: Router, private propAccService: PropAccountantService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.initializForm();
  }
   
  initializForm(){
    this.propAccForm = this.fb.group({
      name: ['',Validators.required],
      email: ['', Validators.email],
    });
  }

  propAccCreate(){
    this.propAccService.createAccountant(this.propAccForm.value).subscribe(response => {
      this.toastr.success("Accountant created");
      this.propAccForm.reset();
    }, error => {
      this.validationErrors = error;
      this.toastr.error("Something went wrong!");
    })
  }

 backNav(){
   this.location.back();
 }

}
