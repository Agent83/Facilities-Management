import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PropAccountant } from '../_models/propAccountant';

@Injectable({
  providedIn: 'root'
})
export class PropAccountantService {
  baseUrl = environment.apiUrl;
  propAccountant: PropAccountant[] = [];
  constructor(private http: HttpClient) { }

  getAccountants(){
    return this.http.get<PropAccountant[]>(this.baseUrl + 'propaccountant').pipe(
      map(propAccountant => {
        this.propAccountant = propAccountant;
        return propAccountant;
      })
    );
  }

  getAccount(id: string){
    const accountant = this.propAccountant.find(x => x.id === id);
    if(accountant !== undefined) return of(accountant);
    return this.http.get<PropAccountant>(this.baseUrl + 'propaccountant/' + id);
  }

  createAccountant(model: any){
    return this.http.post(this.baseUrl + 'propaccountant/accountant', model);
  }

  updateAccountant(propAcc: PropAccountant){
    let url = this.baseUrl + 'propaccountant';
    return this.http.put<PropAccountant>(url, propAcc).pipe(
      map(() => {
        const index = this.propAccountant.indexOf(propAcc);
        this.propAccountant[index] = propAcc
      })
    )
  }
  deleteAccountant(accId: string){ 
    return this.http.delete(this.baseUrl + 'propaccountant/delAccountant/' + accId);
 }

  
}
