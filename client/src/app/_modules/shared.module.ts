import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';
import { NzDrawerModule } from 'ng-zorro-antd/drawer';
import { NzButtonModule } from 'ng-zorro-antd/button'; 
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzListModule } from 'ng-zorro-antd/list';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerModule } from 'ngx-spinner';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { PaginationModule } from 'ngx-bootstrap/pagination';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    NzDrawerModule,
    NzButtonModule,
    NzFormModule,
    NzListModule,
    NzModalModule,
    BsDatepickerModule.forRoot(),
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    TabsModule.forRoot(),
    NgxGalleryModule,
    NgxSpinnerModule,
    NzSelectModule,
    ScrollingModule,
    PaginationModule.forRoot(),
  ], 
exports: [
  BsDropdownModule,
  ToastrModule, 
  TabsModule,
  NgxGalleryModule,
  NzDrawerModule,
  NzButtonModule,
  NzFormModule,
  NzListModule,
  NzModalModule,
  BsDatepickerModule,
  NgxSpinnerModule,
  NzSelectModule,
  ScrollingModule,
  PaginationModule,
]
})
export class SharedModule { }
