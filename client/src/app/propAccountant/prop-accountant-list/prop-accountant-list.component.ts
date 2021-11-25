import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { PropAccountant } from 'src/app/_models/propAccountant';
import { PropAccountantService } from 'src/app/_services/prop-accountant.service';

@Component({
  selector: 'app-prop-accountant-list',
  templateUrl: './prop-accountant-list.component.html',
  styleUrls: ['./prop-accountant-list.component.css']
})
export class PropAccountantListComponent implements OnInit {
  propAccountant: PropAccountant[] =[];
  constructor(private propAccService: PropAccountantService) { }

  ngOnInit(): void {
    this.loadPropAccountants();
  }
  
  loadPropAccountants(){
    this.propAccService.getAccountants().pipe(first()).subscribe(propAcc =>{
     this.propAccountant = propAcc;
    })
  }
}
