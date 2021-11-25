import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { first } from 'rxjs/operators';
import { Contractor } from 'src/app/_models/contractor';
import { ContractorService } from 'src/app/_services/contractor.service';

@Component({
  selector: 'app-contractor-deatials',
  templateUrl: './contractor-deatials.component.html',
  styleUrls: ['./contractor-deatials.component.css']
})
export class ContractorDeatialsComponent implements OnInit {
 contractor: Contractor;

  constructor(private contractorService: ContractorService, private router: ActivatedRoute,) { }

  ngOnInit(): void {
    this.loadContractor();
  }
  loadContractor(){
    this.contractorService.getContractor(this.router.snapshot.paramMap.get('id'))
    .pipe(first()).subscribe(con => {
      this.contractor = con;
      console.log(this.contractor);
    });
  }
}
