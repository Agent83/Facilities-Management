import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContractorCreateComponent } from './contractor/contractor-create/contractor-create.component';
import { ContractorListComponent } from './contractor/contractor-list/contractor-list.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorComponent } from './errors/test-error/test-error.component';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MemberDetailsComponent } from './members/member-details/member-details.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { NotesComponent } from './notes/notes.component';
import { PremiseJobCreateComponent } from './premiseJobs/premise-job-create/premise-job-create.component';
import { PremiseJobsListComponent } from './premiseJobs/premise-jobs-list/premise-jobs-list.component';
import { PremiseCreateComponent } from './premises/premise-create/premise-create.component';
import { PremiseListComponent } from './premises/premise-list/premise-list.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'members', component: MemberListComponent },
      { path: 'members/:userName', component: MemberDetailsComponent },
      { path: 'lists', component: ListsComponent },
      { path: 'notes', component: NotesComponent },
      { path: 'create-premise', component: PremiseCreateComponent },
      { path: 'create-contractor', component: ContractorCreateComponent },
      { path: 'create-job', component: PremiseJobCreateComponent },
      { path: 'lists-jobs', component: PremiseJobsListComponent},
      { path: 'lists-premises', component: PremiseListComponent},
      { path: 'lists-contractor', component: ContractorListComponent}
    ]
  },
  {path: 'errors', component:TestErrorComponent},
  {path: 'not-found', component:NotFoundComponent},
  {path: 'server-error', component:ServerErrorComponent},
  { path: '**', component: NotFoundComponent, pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
