import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Property } from 'src/app/_models/property';
import { PropertyService } from 'src/app/_services/property.service';
import { formatDistance } from 'date-fns'
import { PremisesTask } from 'src/app/_models/premisesTask';
import { PremTasksService } from 'src/app/_services/prem-tasks.service';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { first } from 'rxjs/operators';
import { Contractor } from 'src/app/_models/contractor';
import { ContractorService } from 'src/app/_services/contractor.service';
import { PropAccountant } from 'src/app/_models/propAccountant';
import { PropAccountantService } from 'src/app/_services/prop-accountant.service';
import { Note } from 'src/app/_models/note';
import { PremisesAddress } from 'src/app/_models/premisesAddress';
import { NotesService } from 'src/app/_services/notes.service';
import { PropContractorLink } from 'src/app/_models/propContractorLink';
import { NzModalService } from 'ng-zorro-antd/modal';
import { BsDatepickerConfig, BsLocaleService } from 'ngx-bootstrap/datepicker';


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

  createNote: {
    noteContent: string;
    isPerm: boolean;
    premisesId: string;
  }

  updateTask: PremisesTask; 
  editTaskForm: NgForm;
  locale = 'en';
  
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
  bsConfig: Partial<BsDatepickerConfig>;
  bsValue: Date;
  submitting = false;
  inputValue = '';

  constructor(private propertyService: PropertyService,
    private contractorService: ContractorService,
    private route: ActivatedRoute,
    private propTaskService: PremTasksService,
    private propAccoutantService: PropAccountantService,
    private fb: FormBuilder,
    private toastr: ToastrService,
    private noteService: NotesService,
    private modal: NzModalService,
    private localeService: BsLocaleService,
    private routerRoute: Router
  ) {
    this.bsConfig = {
      containerClass: 'theme-dark-blue',
      dateInputFormat: 'YYYY/MM/DD',
    }
   }

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


  applyLocale(pop: any) {
    this.localeService.use(this.locale);
    pop.hide();
    pop.show();
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

  initialPermNoteForm() {
    this.permNoteForm = this.fb.group({
      noteContent: ['', Validators.required],
    })
  }

  initialTempNoteForm() {
    this.tempNoteForm = this.fb.group({
      noteContent: ['', Validators.required],
    })
  }


  createTempNote() {
    this.createNote = {
      noteContent: this.tempNoteForm.value.noteContent,
      isPerm: false,
      premisesId: this.propId,
    }
    this.noteService.createNote(this.createNote).subscribe(() => {
      this.tempNoteForm.reset();
      this.loadProperty();
      this.toastr.success('Note Created');
    }, error => {
      this.validationErrors = error;
    })
  }

  createPermNote() {
    this.createNote = {
      noteContent: this.permNoteForm.value.noteContent,
      isPerm: true,
      premisesId: this.propId,
    }
    this.noteService.createNote(this.createNote).subscribe(() => {
      this.permNoteForm.reset();
      this.loadProperty();
      this.toastr.success('Note Created');
    }, error => {
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

    this.propTaskService.createTask(this.createTask).subscribe(() => {
      this.createTaskForm.reset();
      this.loadProperty();
      this.toastr.success('Task has been added');
    }, error => {
      this.validationErrors = error;
    });
  }

  loadContractors() {
    this.contractorService.getContractorList().subscribe(contractors => {
      this.contractorsList = contractors;
    })
  }

  loadPropAccList() {
    this.propAccoutantService.getAccountants().subscribe(propAcc => {
      this.propAccList = propAcc;
    });
  }

  loadProperty() {
    this.clearLists();
    this.propertyService.getProperty(this.route.snapshot.paramMap.get('id'))
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
        if (this.property.notes.length > 0) {
          this.permNotes = this.property.notes.filter(p => p.isPerm === true);
          this.tempNotesList = this.property.notes.filter(p => p.isPerm === false);
        }
      })
  }
  showRemoveConfirm(id): void {
    this.modal.confirm({
      nzTitle: 'Remove contractor?',
      nzContent: '<b style="color: red;">Click "Yes" to remove contractor from this property.</b>',
      nzOkText: 'Yes',
      nzOkType: 'primary',
      nzOkDanger: true,
      nzOnOk: () => this.contractorService.removeLink(this.propId, id).pipe(first()).subscribe(() => {
        this.propContractorList = this.propContractorList.filter(x => x.id !== id);
        this.toastr.success('Contractor has been removed');
      }),
      nzCancelText: 'No',
      nzOnCancel: () => console.log('Cancel')
    });
  }
  DelTempNoteConfirm(id): void {
    this.modal.confirm({
      nzTitle: 'Delete Note?',
      nzContent: '<b style="color: red;">Click "Yes" to delete note.</b>',
      nzOkText: 'Yes',
      nzOkType: 'primary',
      nzOkDanger: true,
      nzOnOk: () => this.propertyService.deleteNote(this.propId, id).pipe(first()).subscribe(() => {
        this.tempNotesList = this.tempNotesList.filter(x => x.id !== id);
        this.toastr.success('Note Has been deleted');
      }),
      nzCancelText: 'No',
      nzOnCancel: () => console.log('Cancel')
    });
  }

  
  DelPropertyConfirm(): void {
    this.modal.confirm({
      nzTitle: 'Delete Property?',
      nzContent: '<b style="color: red;">Click "Yes" to delete <strong>Property</strong> .</b>',
      nzOkText: 'Yes',
      nzOkType: 'primary',
      nzOkDanger: true,
      nzOnOk: () => this.propertyService.deletePremise(this.propId ).pipe(first()).subscribe(() => {
        this.routerRoute.navigateByUrl('/', {skipLocationChange: true}).then(()=>{
          this.routerRoute.navigate(['premises'])
        });
      }),
      nzCancelText: 'No',
      nzOnCancel: () => console.log('Cancel')
    });
  }


  RemoveAccountantConfirm(): void {
    this.modal.confirm({
      nzTitle: 'Remove accountant?',
      nzContent: '<b style="color: red;">Click "Yes" to remove accountant from this property.</b>',
      nzOkText: 'Yes',
      nzOkType: 'primary',
      nzOkDanger: true,
      nzOnOk: () => this.propertyService.removeAcc(this.propId).pipe(first()).subscribe(() => {
        this.property.accountant = this.property.accountant = null;
        this.toastr.success('Accountant Has been removed');
      }),
      nzCancelText: 'No',
      nzOnCancel: () => console.log('Cancel')
    });
  }
  DelTaskConfirm(id): void {
    this.modal.confirm({
      nzTitle: 'Delete task?',
      nzContent: '<b style="color: red;">Click "Yes" to delete task.</b>',
      nzOkText: 'Yes',
      nzOkType: 'primary',
      nzOkDanger: true,
      nzOnOk: () => this.propertyService.removeTask(this.propId, id).pipe(first()).subscribe(() => {
        this.premiseTask = this.premiseTask.filter(x => x.id !== id);
        this.toastr.success('Task has been removed');
      }),
      nzCancelText: 'No',
      nzOnCancel: () => console.log('Cancel')
    });
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
  modalEditTaskVisible = false;
  isOkLoading = false;

  showModal(id): void {
    this.modalVisible = true;
    var tempModal = this.premiseTask.filter((info) => {
      return info.id == id;
    });
    this.modalInfo = tempModal;
  }

  showEditTaskModal(id): void {
    this.modalEditTaskVisible = true;
    var tempModal = this.premiseTask.filter((info) => {
      return info.id == id;
    });
    this.updateTask = tempModal[0];
  //  this.bsValue = this.updateTask.completionDate;
    console.log("open edit", this.updateTask)
  }

  taskUpdate(){
    this.propTaskService.updateTask(this.updateTask).subscribe(() => {
      this.toastr.success("task has be updated");
    });
  }

handleUpdateTaskCancel(){
  this. modalEditTaskVisible = false;
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

  getContractorMatch(id) {
    return this.propContractorList.filter(x => x.id === id);
  }

  conSelectSubmit() {
    this.contractorSelectForm.value.contractor;
    let contractLinked = this.getContractorMatch(this.contractorSelectForm.value.contractor);

    if (contractLinked.length > 0) {
      this.toastr.error("Contractor is already linked with property!");
      this.contractorSelectForm.reset();
    } else {
      let selectContractor = this.contractorSelectForm.value;
      this.conPremiseLink = {
        premisesId: this.property.id,
        contractorId: selectContractor.contractor
      }
      this.contractorService.createPremConLink(this.conPremiseLink).subscribe(() => {
        this.contractorSelectForm.reset();
        this.loadProperty();
        this.toastr.success('Contractor added');
      }, error => {
        this.validationErrors = error;
      });
    }

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
  private clearLists() {
    this.tempNotesList = [];
    this.permNotes = [];
    this.premiseTask = [];
    this.propContractorList = [];
  }
}


