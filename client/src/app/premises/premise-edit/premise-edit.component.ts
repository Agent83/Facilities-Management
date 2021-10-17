import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Property } from 'src/app/_models/property';
import { PropertyService } from 'src/app/_services/property.service';
import { Location } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder,  NgForm,  } from '@angular/forms';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-premise-edit',
  templateUrl: './premise-edit.component.html',
  styleUrls: ['./premise-edit.component.css']
})
export class PremiseEditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  property: Property
  @HostListener('window:beforeunload', ['$event']) unloadNotifiaction($event: any){
    if (this.editForm.dirty){
     return false;
    }
  }
  validationErrors: string[] = [];

  constructor(private propertyService: PropertyService, private route: ActivatedRoute, 
    private location: Location,private toastr: ToastrService, private fb: FormBuilder ) { }

  ngOnInit(): void {
    this.loadProperty();
  }

  loadProperty(){
    this.propertyService.getProperty(this.route.snapshot.paramMap.get('id')).pipe(first())
    .subscribe(prop => {
      this.property = prop;    
      console.log(this.property);
    })
  }

  updateProperty() {
     this.propertyService.updateProperty(this.property).subscribe(() => {
      this.editForm.reset(this.property);
      this.loadProperty();
      this.toastr.success('Property has been updated');
     });
  }

  backNav() {
    this.location.back();
  }
}
