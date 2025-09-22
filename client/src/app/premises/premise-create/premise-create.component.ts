import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PropertyService } from 'src/app/_services/property.service';

@Component({
  selector: 'app-premise-create',
  templateUrl: './premise-create.component.html',
  styleUrls: ['./premise-create.component.css']
})
export class PremiseCreateComponent implements OnInit {
  createPropForm: UntypedFormGroup;
  validationErrors: string[] = [];

  constructor(private location: Location, private fb: UntypedFormBuilder, private toastr: ToastrService,
    private router: Router, private propertyService: PropertyService) { }

  ngOnInit(): void {
    this.intitializeForm()
  }
 
  intitializeForm(){
    this.createPropForm = this.fb.group({
    premiseNumber:[''],
    premiseName:['', Validators.required],
    phoneNumber1: [''],
    phoneNumber2: [''],
    email: [''],
    addressLine1: [''],
    addressLine2: [''],
    city: [''],
    postCode: ['']
    })
  }

  propCreate()
  {
   this.propertyService.createProperty(this.createPropForm.value).subscribe(response =>{
     this.router.navigateByUrl('premises');
     this.toastr.success("Property Created")
   }, error =>{
     this.validationErrors = error;
   });
  }

  backNav() {
    this.createPropForm.reset();
    this.location.back();
  }
}
