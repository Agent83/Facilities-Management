import { Component, OnInit } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd/modal';
import { ToastrService } from 'ngx-toastr';
import { first } from 'rxjs';
import { PropAccountant } from 'src/app/_models/propAccountant';
import { PropAccountantService } from 'src/app/_services/prop-accountant.service';

@Component({
  selector: 'app-accountant-management',
  templateUrl: './accountant-management.component.html',
  styleUrls: ['./accountant-management.component.css']
})
export class AccountantManagementComponent implements OnInit {

  accountant: PropAccountant[] = [];
  constructor(private accountantService: PropAccountantService, private toastr: ToastrService,
    private modal: NzModalService,) { }

  ngOnInit(): void {
    this.loadAccountant();
  }
  DelAccountantConfirm(id): void {
    this.modal.confirm({
      nzTitle: 'Delete Note?',
      nzContent: '<b style="color: red;">Click "Yes" to delete note.</b>',
      nzOkText: 'Yes',
      nzOkType: 'primary',
      nzOkDanger: true,
      nzOnOk: () => this.accountantService.deleteAccountant(id).pipe(first()).subscribe(() => {
        this.accountant = this.accountant.filter(x => x.id !== id);
        this.toastr.success('Accontant Has been deleted');
      }),
      nzCancelText: 'No',
      nzOnCancel: () => console.log('Cancel')
    });
  }
  loadAccountant(){
    this.accountantService.getAccountants().subscribe((acc) =>{
      this.accountant = acc;
    })
  }
}
