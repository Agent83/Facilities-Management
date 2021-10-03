import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Property } from 'src/app/_models/property';
import { PropertyService } from 'src/app/_services/property.service';
import { NzDrawerModule } from 'ng-zorro-antd/drawer';

@Component({
  selector: 'app-premise-detail',
  templateUrl: './premise-detail.component.html',
  styleUrls: ['./premise-detail.component.css']
})
export class PremiseDetailComponent implements OnInit {
  visible = false;
  property: Property
  constructor(private propertyService: PropertyService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadProperty();
  }
  
  loadProperty(){
    this.propertyService.getProperty(+this.route.snapshot.paramMap.get('id'))
    .subscribe(prop => {
      this.property = prop
    })
  }
 

  open(): void {
    this.visible = true;
  }

  close(): void {
    this.visible = false;
  }
}
