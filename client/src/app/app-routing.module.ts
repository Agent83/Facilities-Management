import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { ContractorCreateComponent } from './contractor/contractor-create/contractor-create.component';
import { ContractorDeatialsComponent } from './contractor/contractor-deatials/contractor-deatials.component';
import { ContractorEditComponent } from './contractor/contractor-edit/contractor-edit.component';
import { ContractorListComponent } from './contractor/contractor-list/contractor-list.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorComponent } from './errors/test-error/test-error.component';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MemberDetailsComponent } from './members/member-details/member-details.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { NotesComponent } from './notes/notes.component';
import { PremiseCreateComponent } from './premises/premise-create/premise-create.component';
import { PremiseDetailComponent } from './premises/premise-detail/premise-detail.component';
import { PremiseEditComponent } from './premises/premise-edit/premise-edit.component';
import { PremiseListComponent } from './premises/premise-list/premise-list.component';
import { AdminGuard } from './_guards/admin.guard';
import { AuthGuard } from './_guards/auth.guard';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';

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
      { path: 'premises/:id', component: PremiseDetailComponent },
      { path: 'premises/edit/:id', component: PremiseEditComponent, canDeactivate: [PreventUnsavedChangesGuard] },
      { path: 'create-contractor', component: ContractorCreateComponent },
      { path: 'premises', component: PremiseListComponent},
      { path: 'lists-contractor', component: ContractorListComponent},
      { path: 'contractor/:id', component:ContractorDeatialsComponent},
      { path: 'contractor/edit/:id', component: ContractorEditComponent},
      { path: 'admin', component: AdminPanelComponent, canActivate: [AdminGuard]},
    ]
  },
  {path: 'errors', component:TestErrorComponent},
  {path: 'not-found', component:NotFoundComponent},
  {path: 'server-error', component:ServerErrorComponent},
  {path: '**', component: NotFoundComponent, pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
