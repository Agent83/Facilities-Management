import { Component, OnInit } from '@angular/core';
import {Location} from '@angular/common';


@Component({
  selector: 'app-premise-job-create',
  templateUrl: './premise-job-create.component.html',
  styleUrls: ['./premise-job-create.component.css']
})
export class PremiseJobCreateComponent implements OnInit {

  constructor(private location: Location) { }

  ngOnInit(): void {
  }
 
  backNav() {
    this.location.back();
  }
}
