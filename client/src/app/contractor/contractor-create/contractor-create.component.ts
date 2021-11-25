import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
  }
  
  backNav(){
    this.location.back();
  }

  intitializeForm(){
    this.createConForm = this.fb.group({
      businessName:[''],
      firstName:['', Validators.required],
      lastName: [''],
      rating: [''],
      contractorTypeId: [''],
      greenLightEnum: [''],
      phoneNumber1: [''],
      email: [''],
      phoneNumber2: ['']
    })
  }

  propCreate()
  {
   this.contractorService.createContractor(this.createConForm.value).subscribe(response =>{
     this.router.navigateByUrl('contractor');
   }, error =>{
     this.validationErrors = error;
   });
  }
}
