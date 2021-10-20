import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Contractor } from 'src/app/_models/contractor';
import { ContractorService } from 'src/app/_services/contractor.service';

@Component({
  selector: 'app-contractor-list',
  templateUrl: './contractor-list.component.html',
  styleUrls: ['./contractor-list.component.css']
})
export class ContractorListComponent implements OnInit {
  contractors$: Observable<Contractor[]>;
  constructor(private contractorService: ContractorService) { }

  ngOnInit(): void {
     this.contractors$ = this.contractorService.getContractors();
  }

}
