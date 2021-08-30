import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-contractor-create',
  templateUrl: './contractor-create.component.html',
  styleUrls: ['./contractor-create.component.css']
})
export class ContractorCreateComponent implements OnInit {

  constructor(private location: Location) { }

  ngOnInit(): void {
  }
  
  backNav(){
    this.location.back();
  }
}
