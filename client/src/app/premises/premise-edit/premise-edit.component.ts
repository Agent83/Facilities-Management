import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Property } from 'src/app/_models/property';
import { PropertyService } from 'src/app/_services/property.service';
import { Location } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-premise-edit',
  templateUrl: './premise-edit.component.html',
  styleUrls: ['./premise-edit.component.css']
})
export class PremiseEditComponent implements OnInit {
  property: Property
  constructor(private propertyService: PropertyService, private route: ActivatedRoute, 
    private location: Location,private toastr: ToastrService ) { }

  ngOnInit(): void {
    this.loadProperty();
  }

  loadProperty(){
    this.propertyService.getProperty(+this.route.snapshot.paramMap.get('id'))
    .subscribe(prop => {
      this.property = prop;    
      console.log(this.property);
    })
  }
  
  updateProperty() {
    // this.propertyService.updateMember(this.member).subscribe(() => {
    //   this.toastr.success('Profile updated successfully');
    //   this.editForm.reset(this.member);
    // })
  }

  backNav() {
    this.location.back();
  }
}
