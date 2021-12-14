import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailsComponent } from './members/member-details/member-details.component';
import { ListsComponent } from './lists/lists.component';
import { NotesComponent } from './notes/notes.component';
import { ContractorListComponent } from './contractor/contractor-list/contractor-list.component';
import { ContractorDeatialsComponent } from './contractor/contractor-deatials/contractor-deatials.component';
import { ContractorCreateComponent } from './contractor/contractor-create/contractor-create.component';
import { PremiseCreateComponent } from './premises/premise-create/premise-create.component';
import { PremiseDetailComponent } from './premises/premise-detail/premise-detail.component';
import { PremiseListComponent } from './premises/premise-list/premise-list.component';
import { SharedModule } from './_modules/shared.module';
import { TestErrorComponent } from './errors/test-error/test-error.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { MemberCardComponent } from './members/member-card/member-card.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { en_US } from 'ng-zorro-antd/i18n';
import { CommonModule, registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NzCommentModule } from 'ng-zorro-antd/comment';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { DateInputComponent } from './_forms/date-input/date-input.component';
import { PremiseEditComponent } from './premises/premise-edit/premise-edit.component';
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
import { PremiseTasksComponent } from './premiseTasks/premise-tasks/premise-tasks.component';
import { TasksCreateComponent } from './premiseTasks/tasks-create/tasks-create.component';
import { RouterModule } from '@angular/router';
import { TexareaInputComponent } from './_forms/texarea-input/texarea-input.component';
import { ContractorEditComponent } from './contractor/contractor-edit/contractor-edit.component';
import { PropAccountantListComponent } from './propAccountant/prop-accountant-list/prop-accountant-list.component';
import { PropAccountantCreateComponent } from './propAccountant/prop-accountant-create/prop-accountant-create.component';
import { TaskupdateComponent } from './premises/taskupdate/taskupdate.component';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { HasRoleDirective } from './_directives/has-role.directive';
import { UserManagementComponent } from './admin/user-management/user-management.component';
import { RolesModalComponent } from './modal/roles-modal/roles-modal.component';


registerLocaleData(en);

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
    ContractorCreateComponent,
    PremiseCreateComponent,
    PremiseDetailComponent,
    PremiseListComponent,
    TestErrorComponent,
    NotFoundComponent,
    ServerErrorComponent,
    MemberCardComponent,
    TextInputComponent,
    DateInputComponent,
    PremiseEditComponent,
    PremiseTasksComponent,
    TasksCreateComponent,
    TexareaInputComponent,
    ContractorEditComponent,
    PropAccountantListComponent,
    PropAccountantCreateComponent,
    TaskupdateComponent,
    AdminPanelComponent,
    HasRoleDirective,
    UserManagementComponent,
    RolesModalComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    SharedModule,
    NzCommentModule,
    NgbModule,
    ReactiveFormsModule,
    RouterModule.forRoot([]),
    FormsModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true},
    { provide: NZ_I18N, useValue: en_US }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
