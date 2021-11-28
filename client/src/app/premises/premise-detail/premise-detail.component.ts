import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Property } from 'src/app/_models/property';
import { PropertyService } from 'src/app/_services/property.service';
import { formatDistance } from 'date-fns'
import { PremisesTask } from 'src/app/_models/premisesTask';
import { PremTasksService } from 'src/app/_services/prem-tasks.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { first } from 'rxjs/operators';
import { Contractor } from 'src/app/_models/contractor';
import { ContractorService } from 'src/app/_services/contractor.service';
import { PropAccountant } from 'src/app/_models/propAccountant';
import { PropAccountantService } from 'src/app/_services/prop-accountant.service';
import { pipe } from 'rxjs';
import { Note } from 'src/app/_models/note';
import { PremisesAddress } from 'src/app/_models/premisesAddress';

@Component({
  selector: 'app-premise-detail',
  templateUrl: './premise-detail.component.html',
  styleUrls: ['./premise-detail.component.css']
})
export class PremiseDetailComponent implements OnInit {
  visibleTasks = false;
  visibleContractor = false;
  permNotes: Note[] = [];
  tempNotes: Note[] = [];
  premiseTask: PremisesTask[] = [];
  contractorsList: Contractor[] = [];
  propAccountant: PropAccountant[] = [];
  propAccList: PropAccountant[] = [];
  property: Property;
  tasksCount: number;
  modalInfo: any;
  propId: string;

  propContractorList: Contractor[] = [];

  createTaskForm: FormGroup;
  contractorSelectForm: FormGroup;
  selectAccountantForm: FormGroup;
  propAccForm: FormGroup;

  validationErrors: string[] = [];

  selectedContractorValue: Contractor;
  propertyAddAccount: {
    id: string,
    premiseNumber: string,
    premisesAddress: PremisesAddress,
    phoneNumber1: string,
    phoneNumber2: string,
    email: string,
    notes: Note[],
    isDeleted: boolean,
    dateCreated: Date,
    contractors: Contractor[],
    premiseName: string,
    premisesTasks: PremisesTask[],
    accountantId: string,
  };

  createTask: {
    title: string,
    description: string,
    completionDate: Date,
    premisesId: string
  };

  noteData: {
    content: string,
    datetime: Date,
    displayTime: any,
  }[] = [];

  submitting = false;
  inputValue = '';

  constructor(private propertyService: PropertyService,
    private contractorService: ContractorService,
    private route: ActivatedRoute,
    private porpTaskService: PremTasksService,
    private propAccoutantService: PropAccountantService,
    private fb: FormBuilder,
    private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    this.loadProperty();
    this.loadContractors();
    this.initializeTaskForm();
    this.loadPropAccList();
    this.linkAccountantToProp();
    this.linkContractorToProp();
  }

  initializeTaskForm() {
    this.createTaskForm = this.fb.group({
      title: ['', Validators.required],
      description: [''],
      completionDate: ['']
    })
  }

  linkContractorToProp() {
    this.contractorSelectForm = this.fb.group({
      contractor: ['', Validators.required],
    });
  }

  linkAccountantToProp() {
    this.selectAccountantForm = this.fb.group({
      accountant: ['', Validators.required],
    });
  }

  log(event: string) {
    console.log(event);
  }

  propTaskCreate() {
    this.createTask =
    {
      title: this.createTaskForm.value.title,
      description: this.createTaskForm.value.description,
      completionDate: this.createTaskForm.value.completionDate,
      premisesId: this.propId
    };
    console.log(this.createTask);
    this.porpTaskService.createTask(this.createTask).subscribe(() => {
      this.createTaskForm.reset();
      this.premiseTask = [];
      this.loadProperty();
      this.toastr.success('Task has been added');
    }, error => {
      this.validationErrors = error;
    });
  }

  loadContractors() {
    this.contractorService.getContractors().pipe(first()).subscribe(contractors => {
      this.contractorsList = contractors;
    })
  }

  loadPropAccList() {
    this.propAccoutantService.getAccountants().pipe(first()).subscribe(propAcc => {
      this.propAccList = propAcc;
    });
  }

  loadProperty() {
    this.propertyService.getProperty(this.route.snapshot.paramMap.get('id')).pipe(first())
      .subscribe(prop => {
        this.property = prop
        this.propId = prop.id
        if (this.property.premisesTasks.length > 0 || !undefined) {
          this.tasksCount = this.property.premisesTasks.length;
          this.property.premisesTasks.forEach(task => {
            this.premiseTask.push(task);
          });
        }
        if (this.property.contractors.length > 0 || !undefined) {
          this.property.contractors.forEach(con => {
            this.propContractorList.push(con);
          });
        }
        if (this.property.notes.length > 0 || !undefined) {
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
    this.createTaskForm.reset();
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
    var tempModal = this.premiseTask.filter((info) => {
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

  // selected() {
  //   console.log(this.contractorSelectForm);
  // }

  updatePropertyAccountant() {
    this.propertyAddAccount = {
      id: this.property.id,
      premiseNumber: this.property.premiseNumber,
      premisesAddress: this.property.premisesAddress,
      phoneNumber1: this.property.phoneNumber1,
      phoneNumber2: this.property.phoneNumber2,
      email: this.property.email,
      notes: this.property.notes,
      isDeleted: this.property.isDeleted,
      dateCreated: this.property.dateCreated,
      contractors: this.property.contractors,
      premiseName: this.property.premiseName,
      premisesTasks: this.property.premisesTasks,
      accountantId: this.selectAccountantForm.value,
    };
    this.propertyService.updateProperty(this.propertyAddAccount).subscribe(() => {
     this.loadProperty();
     this.toastr.success('Property has been updated');
    });
 }

  conSelectSubmit() {
    console.log(this.contractorSelectForm.value);
  }
  accSelectSubmit() {
    this.propertyService.updateProperty(this.property).subscribe(() => { 
      this.loadProperty();
      this.toastr.success('Property has been updated');
     });
  }

}


