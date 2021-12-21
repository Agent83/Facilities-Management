import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ContractorType } from '../_models/contractorType';

@Injectable({
  providedIn: 'root'
})
export class ContractTypeService {
  baseUrl = environment.apiUrl;
  conType: ContractorType[] = [];

  constructor(private http: HttpClient) { }
  
  getConTypes(){
    return this.http.get<ContractorType[]>(this.baseUrl + 'contractortype').pipe(
      map(con => {
        this.conType = con;
        return con;
      })
    )
  }
 
  getConType(id: number){
    const con = this.conType.find(x => x.id === id);
    if(con !== undefined) return of(con);
    return this.http.get<ContractorType>(this.baseUrl + 'contractortype/' + id);
  }
  
  createConType(model: any){
    return this.http.post(this.baseUrl + 'contractortype/createConType', model);
  }

  updateConType(con: ContractorType){
    let url = this.baseUrl + 'contractortype';
    return this.http.put<ContractorType>(url, con).pipe(
      map(() => {
        const index = this.conType.indexOf(con);
        this.conType[index] = con;
      })
    )
  }


}
