import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Property } from 'src/app/_models/property';
import { PropertyService } from 'src/app/_services/property.service';
import { formatDistance } from 'date-fns'
import { PremisesTask } from 'src/app/_models/premisesTask';
import { StringMap } from '@angular/compiler/src/compiler_facade_interface';

@Component({
  selector: 'app-premise-detail',
  templateUrl: './premise-detail.component.html',
  styleUrls: ['./premise-detail.component.css']
})
export class PremiseDetailComponent implements OnInit {
  visibleTasks = false;
  visibleContractor = false;
  premiseTask: PremisesTask[] =[];
  tasksCount: number;
  modalInfo:any;
  property: Property;
  noteData: {
    content: string,
    datetime: Date,
    displayTime: any,
  }[] = [];
  submitting = false;
  inputValue = '';
  constructor(private propertyService: PropertyService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadProperty();
  }
  
  loadProperty(){
    this.propertyService.getProperty(this.route.snapshot.paramMap.get('id'))
    .subscribe(prop => {
      this.property = prop
      if ( this.property.premisesTasks.length > 0){
        this.tasksCount = this.property.premisesTasks.length;
        this.property.premisesTasks.forEach(task => {
          this.premiseTask.push(task);
        });
      }

      if (this.property.notes.length > 0){
        this.property.notes.forEach(note => {
          return this.noteData.push(
            {
              content: note.noteContent,
              datetime: note.dateCreated,
              displayTime: note.dateCreated,
            });
        });
      }
      console.log(this.noteData);
    })
  }

  openTasks(): void {
    this.visibleTasks = true;
  }
  openContractor(): void {
    this.visibleContractor = true;
  }

  closeTasks(): void {
    this.visibleTasks = false;
  }
  closeContractor(): void {
    this.visibleContractor = false;
  }

  handleSubmit(): void {
    this.submitting = true;
    const content = this.inputValue;
    this.inputValue = '';
    setTimeout(() => {
      this.submitting = false;
      this.noteData.push(
        {
          content,
          datetime: new Date(),
          displayTime: formatDistance(new Date(), new Date())
        }
      )
      // .map(e => ({
      //   ...e,
      //   displayTime: formatDistance(new Date(), e.datetime).toString()
      // }));
    }, 1800);
  }

// Modal
modalVisible = false;
isOkLoading = false;

showModal(id): void {
  this.modalVisible = true;
  var tempModal = this.premiseTask.filter((info) =>{
    return info.id == id;
  });
  this.modalInfo = tempModal;
  console.log(this.modalInfo);
}

handleOk(): void {
  this.isOkLoading = true;
  setTimeout(() => {
    this.modalVisible = false;
    this.isOkLoading = false;
  }, 3000);
}

handleCancel(): void {
  this.modalVisible = false;
}
// Modal

}


