import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Property } from 'src/app/_models/property';
import { PropertyService } from 'src/app/_services/property.service';

@Component({
  selector: 'app-premise-list',
  templateUrl: './premise-list.component.html',
  styleUrls: ['./premise-list.component.css']
})
export class PremiseListComponent implements OnInit {
 properties: any[];
  constructor(private propertyService: PropertyService) { }

  ngOnInit(): void {
    this.loadProperties();
  }
 loadProperties(){
   this.propertyService.getProperties().subscribe(props => {
     this.properties = props;
     console.log(this.properties);
   })
 }
}
