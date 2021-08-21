import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailsComponent } from './members/member-details/member-details.component';
import { ListsComponent } from './lists/lists.component';
import { NotesComponent } from './notes/notes.component';
import { ToastrModule } from 'ngx-toastr';
import { ContractorListComponent } from './contractor/contractor-list/contractor-list.component';
import { ContractorDeatialsComponent } from './contractor/contractor-deatials/contractor-deatials.component';
import { PremiseJobsListComponent } from './premiseJobs/premise-jobs-list/premise-jobs-list.component';
import { PremsiseJobDetailsComponent } from './premiseJobs/premsise-job-details/premsise-job-details.component';
import { PremiseJobCreateComponent } from './premiseJobs/premise-job-create/premise-job-create.component';
import { ContractorCreateComponent } from './contractor/contractor-create/contractor-create.component';
import { PremiseCreateComponent } from './premises/premise-create/premise-create.component';
import { PremiseDetailComponent } from './premises/premise-detail/premise-detail.component';
import { PremiseListComponent } from './premises/premise-list/premise-list.component';
import { CreateJobComponent } from './premisesJob/create-job/create-job.component';
import { JobListComponent } from './premisesJob/job-list/job-list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    MemberListComponent,
    MemberDetailsComponent,
    ListsComponent,
    NotesComponent,
    ContractorListComponent,
    ContractorDeatialsComponent,
    PremiseJobsListComponent,
    PremsiseJobDetailsComponent,
    PremiseJobCreateComponent,
    ContractorCreateComponent,
    PremiseCreateComponent,
    PremiseDetailComponent,
    PremiseListComponent,
    CreateJobComponent,
    JobListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
