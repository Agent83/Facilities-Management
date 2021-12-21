import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Contractor } from 'src/app/_models/contractor';
import { Pagination } from 'src/app/_models/pagination';
import { ContractorService } from 'src/app/_services/contractor.service';

@Component({
  selector: 'app-contractor-list',
  templateUrl: './contractor-list.component.html',
  styleUrls: ['./contractor-list.component.css']
})
export class ContractorListComponent implements OnInit {
  contractors: Contractor[];
  pagination: Pagination;
  pageNumber = 1;
  pageSize = 25;
  constructor(private contractorService: ContractorService) { }

  ngOnInit(): void {
   this.loadContractor();
  }

  loadContractor(){
    this.contractorService.getContractors(this.pageNumber, this.pageSize).subscribe(response => {
      this.contractors = response.result;
      this.pagination = response.pagination;
    });
  }
  
  pageChanged(event: any){
    this.pageNumber = event.page;
    this.loadContractor();
  }
  
}
