import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { first } from 'rxjs/operators';
import { Pagination } from 'src/app/_models/pagination';
import { Property } from 'src/app/_models/property';
import { PropertyService } from 'src/app/_services/property.service';

@Component({
  selector: 'app-premise-list',
  templateUrl: './premise-list.component.html',
  styleUrls: ['./premise-list.component.css']
})
export class PremiseListComponent implements OnInit {
 properties: Property[];
 pagination: Pagination;
 pageNumber = 1;
 pageSize = 25;

  constructor(private propertyService: PropertyService) { }

  ngOnInit(): void {
    this.loadProperty();
  }
  
  loadProperty(){
    this.propertyService.getProperties(this.pageNumber, this.pageSize).subscribe(response => {
      this.properties = response.result;
      this.pagination = response.pagination;
    })
  }
  searchPremise(search: string){
    this.propertyService.searchProperties(this.pageNumber, this.pageSize, search).subscribe(response => {
      this.properties = response.result;
      this.pagination = response.pagination;
    });
  }

  reload(){
    this.loadProperty();
  }
  pageChanged(event: any){
    this.pageNumber = event.page;
    this.loadProperty();
  }
  modalAccVisible= false;
  showCreateAccModal(){
    this.modalAccVisible = true;
  }
  handleAccCancel(){
    this.modalAccVisible = false
  }

}
