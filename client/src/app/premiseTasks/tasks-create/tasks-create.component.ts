import { Component, Input, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Property } from 'src/app/_models/property';
import { PremTasksService } from 'src/app/_services/prem-tasks.service';

@Component({
  selector: 'app-tasks-create',
  templateUrl: './tasks-create.component.html',
  styleUrls: ['./tasks-create.component.css']
})
export class TasksCreateComponent implements OnInit {
  property: Property;
  createTaskForm: UntypedFormGroup;
  validationErrors: string[] = [];
  constructor(private location: Location, private fb: UntypedFormBuilder,private toastr: ToastrService,
    private router: Router, private porpTaskService: PremTasksService) { }

  ngOnInit(): void {
    this.initializeForm();
  }

   initializeForm(){
     this.createTaskForm = this.fb.group({
       title:[''],
       description: [''],
       completionDate: [Date],
       premisesId: this.property.id,
     })
   }

   propTaskCreate(){
     this.porpTaskService.createTask(this.createTaskForm.value).subscribe(()=>{
       this.createTaskForm.reset();
       this.toastr.success('Task has been added');
     }, error =>{
      this.validationErrors = error;
    });
   }
}

