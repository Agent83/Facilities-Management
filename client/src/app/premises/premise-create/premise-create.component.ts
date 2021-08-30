import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-premise-create',
  templateUrl: './premise-create.component.html',
  styleUrls: ['./premise-create.component.css']
})
export class PremiseCreateComponent implements OnInit {

  constructor(private location: Location) { }

  ngOnInit(): void {
  }
 
  backNav() {
    this.location.back();
  }
}
