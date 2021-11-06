import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { first } from 'rxjs/operators';
import { Property } from 'src/app/_models/property';
import { PropertyService } from 'src/app/_services/property.service';

@Component({
  selector: 'app-premise-list',
  templateUrl: './premise-list.component.html',
  styleUrls: ['./premise-list.component.css']
})
export class PremiseListComponent implements OnInit {
 properties$: Observable<Property[]>;
 taskCount: number;
  constructor(private propertyService: PropertyService) { }

  ngOnInit(): void {
    this.properties$ = this.propertyService.getProperties()
  }
  
  getTaskCount(){
  
  }
}
