import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContractorCreateComponent } from './contractor/contractor-create/contractor-create.component';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MemberDetailsComponent } from './members/member-details/member-details.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { NotesComponent } from './notes/notes.component';
import { PremiseJobCreateComponent } from './premiseJobs/premise-job-create/premise-job-create.component';
import { PremiseCreateComponent } from './premises/premise-create/premise-create.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'members', component: MemberListComponent },
      { path: 'members/:id', component: MemberDetailsComponent },
      { path: 'lists', component: ListsComponent },
      { path: 'notes', component: NotesComponent },
      { path: 'create-premise', component: PremiseCreateComponent },
      { path: 'create-contractor', component: ContractorCreateComponent },
      { path: 'create-job', component: PremiseJobCreateComponent }
    ]
  },

  { path: '**', component: HomeComponent, pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
