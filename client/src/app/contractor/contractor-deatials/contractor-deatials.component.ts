import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NzModalService } from 'ng-zorro-antd/modal';
import { ToastrService } from 'ngx-toastr';
import { first } from 'rxjs/operators';
import { Contractor } from 'src/app/_models/contractor';
import { ContractorService } from 'src/app/_services/contractor.service';

@Component({
  selector: 'app-contractor-deatials',
  templateUrl: './contractor-deatials.component.html',
  styleUrls: ['./contractor-deatials.component.css']
})
export class ContractorDeatialsComponent implements OnInit {
 contractor: Contractor;
 conId: string;
  constructor(private contractorService: ContractorService, private router: ActivatedRoute,private toastr: ToastrService,
    private modal: NzModalService,private routerRoute: Router) { }

  ngOnInit(): void {
    this.loadContractor();
  }
  loadContractor(){
    this.contractorService.getContractor(this.router.snapshot.paramMap.get('id'))
    .pipe(first()).subscribe(con => {
      this.contractor = con;
      this.conId = con.id;
    });
  }

  DelContractorConfirm(): void {
    console.log(this.conId);
    this.modal.confirm({
      nzTitle: 'Delete Note?',
      nzContent: '<b style="color: red;">Click "Yes" to delete note.</b>',
      nzOkText: 'Yes',
      nzOkType: 'primary',
      nzOkDanger: true,
      nzOnOk: () => this.contractorService.deleteContractor(this.conId).subscribe(() => {
        this.routerRoute.navigateByUrl('/', {skipLocationChange: true}).then(()=>{
          this.routerRoute.navigate(['lists-contractor'])
        });
        this.toastr.success("Contractor Has been deleted");
      }),
      nzCancelText: 'No',
      nzOnCancel: () => console.log('Cancel')
    });
  }
}
