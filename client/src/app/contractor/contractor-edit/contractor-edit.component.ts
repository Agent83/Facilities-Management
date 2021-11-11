import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { first } from 'rxjs/operators';
import { Contractor } from 'src/app/_models/contractor';
import { ContractorService } from 'src/app/_services/contractor.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-contractor-edit',
  templateUrl: './contractor-edit.component.html',
  styleUrls: ['./contractor-edit.component.css']
})
export class ContractorEditComponent implements OnInit {
 @ViewChild('editForm') editForm: NgForm;
 contractor: Contractor;

 @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any){
   if(this.editForm.dirty){
     return false;
   }
 }

 validationErrors: string[] = [];

  constructor(private contractorService: ContractorService, private route: ActivatedRoute,
    private location: Location, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadContractor();
  }

  loadContractor(){
    this.contractorService.getContractor(this.route.snapshot.paramMap.get('id')).pipe(first())
    .subscribe(con => {
      this.contractor = con;
    })
  }

  updateContractor(){
    this.contractorService.updateContractor(this.contractor).subscribe(() => {
     this.editForm.reset(this.contractor);
     this.toastr.success('Contractor has been updated');  
    });
  }
  backNav(){
    this.location.back();
  }
}
