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
import { NotesService } from 'src/app/_services/notes.service';
import { Guid } from 'guid-typescript';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { PropContractorLink } from 'src/app/_models/propContractorLink';

@Component({
  selector: 'app-premise-detail',
  templateUrl: './premise-detail.component.html',
  styleUrls: ['./premise-detail.component.css']
})
export class PremiseDetailComponent implements OnInit {
  visibleTasks = false;
  visibleContractor = false;
  permNotes: Note[] = [];
  tempNotes: string[] = [];
  tempNotesList: Note[] = [];
  premiseTask: PremisesTask[] = [];
  contractorsList: Contractor[] = [];
  propAccountant: PropAccountant[] = [];
  propAccList: PropAccountant[] = [];
  property: Property;
  conPremiseLink: PropContractorLink;
  tasksCount: number;
  modalInfo: any;
  propId: string;

  propContractorList: Contractor[] = [];

  createTaskForm: FormGroup;
  contractorSelectForm: FormGroup;
  selectAccountantForm: FormGroup;
  propAccForm: FormGroup;
  permNoteForm: FormGroup;
  tempNoteForm: FormGroup;

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
    isActive: boolean,
    isDeleted: boolean,
    dateCreated: Date,
    contractors: Contractor[],
    premiseName: string,
    premisesTasks: PremisesTask[],
    accountantId: string,
    accountant: PropAccountant,
  };
  
  createNote:{
    noteContent: string;
    isPerm: boolean;
    premisesId:string;
  }

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
    private noteService: NotesService,
  ) { }

  ngOnInit(): void {
    this.loadProperty();
    this.loadContractors();
    this.initializeTaskForm();
    this.loadPropAccList();
    this.linkAccountantToProp();
    this.linkContractorToProp();
    this.initialPermNoteForm();
    this.initialTempNoteForm();
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
      accountantId: ['', Validators.required],
    });
  }

  initialPermNoteForm(){
   this.permNoteForm = this.fb.group({
    noteContent: ['',Validators.required],
    isPerm: [true],
   })
  }
  
  initialTempNoteForm(){
    this.tempNoteForm = this.fb.group({
     noteContent: ['',Validators.required],
     isPerm: [false],
    })
   }
   

   createTempNote(){
     this.createNote ={
      noteContent: this.tempNoteForm.value.noteContent,
      isPerm: this.tempNoteForm.value.isPerm,
      premisesId:this.propId,
    }
    this.noteService.createNote(this.createNote).subscribe(() =>{
      this.tempNoteForm.reset();
      this.loadProperty();
      this.toastr.success('Note Created');
    }, error =>{
      this.validationErrors = error;
    })
    }

   createPermNote(){
    this.createNote ={
      noteContent: this.permNoteForm.value.noteContent,
      isPerm: this.permNoteForm.value.isPerm,
      premisesId:this.propId,
    }
   this.noteService.createNote(this.createNote).subscribe(() =>{
     this.permNoteForm.reset();
     this.loadProperty();
     this.toastr.success('Note Created');
   }, error =>{
     this.validationErrors = error;
   })
   }

  propTaskCreate() {
    this.createTask =
    {
      title: this.createTaskForm.value.title,
      description: this.createTaskForm.value.description,
      completionDate: this.createTaskForm.value.completionDate,
      premisesId: this.propId
    };

    this.porpTaskService.createTask(this.createTask).subscribe(() => {
      this.createTaskForm.reset();
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
    this.clearLists();
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
        if(this.property.notes.length > 0){
          
            this.permNotes = this.property.notes.filter(p => p.isPerm === true);
            this.tempNotesList = this.property.notes.filter(p => p.isPerm === false);
            this.tempNotesList.forEach(note =>{
              this.tempNotes.push(note.noteContent);
                     });
          
          console.log("perm",this.permNotes)
          console.log(this.tempNotesList)
        }

        // if (this.property.notes.length > 0 || !undefined) {
        //   this.property.notes.forEach(note => {
        //     return this.noteData.push(
        //       {
        //         content: note.noteContent,
        //         datetime: note.dateCreated,
        //         displayTime: note.dateCreated,
        //       });
        //   });
        // }
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

  conSelectSubmit() {
    let selectContractor = this.contractorSelectForm.value;
    this.conPremiseLink = {
      premisesId: this.property.id,
      contractorId: selectContractor.contractor
    }
    this.contractorService.createPremConLink(this.conPremiseLink).subscribe(() =>{
      this.contractorSelectForm.reset();
      this.loadProperty();
      this.toastr.success('Contractor added');
    }, error =>{
      this.validationErrors = error;
    });
  }
  accSelectSubmit() {  
    let premAccountantId = this.selectAccountantForm.value; 
    this.propertyAddAccount = {
    id: this.property.id,
    premiseNumber: this.property.premiseNumber,
    premisesAddress: this.property.premisesAddress,
    phoneNumber1: this.property.phoneNumber1,
    phoneNumber2: this.property.phoneNumber2,
    email: this.property.email,
    notes: this.property.notes,
    isActive: this.property.isActive,
    isDeleted: this.property.isDeleted,
    dateCreated: this.property.dateCreated,
    contractors: this.property.contractors,
    premiseName: this.property.premiseName,
    premisesTasks: this.property.premisesTasks,
    accountantId: premAccountantId.accountantId,
    accountant: this.property.accountant,
  };
  this.propertyService.updateProperty(this.propertyAddAccount).subscribe(() => {
   this.selectAccountantForm.reset();
   this.loadProperty();
   this.toastr.success('Property has been updated');
  });
  }
 private clearLists(){
  this.tempNotes = [];
  this.permNotes = [];
  this.premiseTask = [];
  this.propContractorList =[];
 }
}


