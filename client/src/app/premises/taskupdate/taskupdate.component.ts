import { Component, Injectable, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';
import { first } from 'rxjs/operators';
import { PremisesTask } from 'src/app/_models/premisesTask';
import { PremTasksService } from 'src/app/_services/prem-tasks.service';


@Component({
  selector: 'app-taskupdate',
  templateUrl: './taskupdate.component.html',
  styleUrls: ['./taskupdate.component.css']
})
export class TaskupdateComponent implements OnInit {
  // @ViewChild('editTaskForm')
  editTaskForm: NgForm;
  // @Injectable({
  //   providedIn: 'root'
  // })
  premTask: PremisesTask;
  bsConfig: Partial<BsDatepickerConfig>;

  validationErrors: string[] = [];

  constructor(private premTaskService: PremTasksService, private route: ActivatedRoute, 
    private location: Location,private toastr: ToastrService,) { 
    this.bsConfig = {
      containerClass: 'theme-dark-blue',
      dateInputFormat: 'DD/MM/YYYY'
    }
    }

  ngOnInit(): void {
    this.loadTask();
  }


  loadTask(){
    this.premTaskService.getTask(this.premTask.id).pipe(first())
    .subscribe(task => {
      this.premTask = task;
    });
  }

  updateTask(){
    this.premTaskService.updateTask(this.premTask).subscribe(() => {
      this.toastr.success("task has be updated");
    })
  }
}
