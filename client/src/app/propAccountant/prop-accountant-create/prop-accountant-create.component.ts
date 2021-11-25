import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { PropAccountantService } from 'src/app/_services/prop-accountant.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-prop-accountant-create',
  templateUrl: './prop-accountant-create.component.html',
  styleUrls: ['./prop-accountant-create.component.css']
})
export class PropAccountantCreateComponent implements OnInit {
  propAccForm: FormGroup;
  validationErrors: string[] = [];
  constructor(private location: Location, private fb: FormBuilder,
    private router: Router, private propAccService: PropAccountantService) { }

  ngOnInit(): void {
    this.initializForm();
  }
   
  initializForm(){
    this.propAccForm = this.fb.group({
      name: [''],
      email: [''],
    });
  }

  propAccCreate(){
    this.propAccService.createAccountant(this.propAccForm.value).subscribe(response => {
      this.router.navigateByUrl('propAccountant');
      console.log(this.propAccForm.value)
    }, error => {
      this.validationErrors = error;
    })
  }
 
 backNav(){
   this.location.back();
 }

}
