import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ContractorService } from 'src/app/_services/contractor.service';

@Component({
  selector: 'app-contractor-create',
  templateUrl: './contractor-create.component.html',
  styleUrls: ['./contractor-create.component.css']
})
export class ContractorCreateComponent implements OnInit {
  createConForm: FormGroup;
  validationErrors: string[] = [];
  constructor(private location: Location, private fb: FormBuilder, private toastr: ToastrService,
    private router: Router, private contractorService: ContractorService) { }

  ngOnInit(): void {
    this.intitializeConForm();
  }
  
  backNav(){
    this.createConForm.reset();
    this.location.back();
  }

  intitializeConForm(){
    this.createConForm = this.fb.group({
      businessName:[''],
      firstName:['', Validators.required],
      lastName: [''],
      rating: [''],
      contractorTypeId: [''],
      phoneNumber1: [''],
      email: ['',Validators.email],
      phoneNumber2: ['']
    })
  }

  conCreate()
  {
   this.contractorService.createContractor(this.createConForm.value).subscribe(response =>{
     this.router.navigateByUrl('lists-contractor');
     this.toastr.success("Contractor Created");
   }, error =>{
     this.validationErrors = error;
   });
  }
}
