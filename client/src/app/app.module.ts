import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
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
import { SharedModule } from './_modules/shared.module';
import { TestErrorComponent } from './errors/test-error/test-error.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';

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
    TestErrorComponent,
    NotFoundComponent,
    ServerErrorComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    SharedModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
