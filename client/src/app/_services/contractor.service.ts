import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Contractor } from '../_models/contractor';

@Injectable({
  providedIn: 'root'
})
export class ContractorService {
baseUrl = environment.apiUrl;
contractor: Contractor[] = [];
  constructor(private http: HttpClient) { }

  getContractors(){
    if (this.contractor.length > 0) return of(this.contractor);
    return this.http.get<Contractor[]>(this.baseUrl + 'contractor').pipe(
      map(contractor => {
        this.contractor = contractor;
        return contractor;
      })
    );
  }

  getContractor(id: string){
    const contractor = this.contractor.find(x => x.id === id);
    if(contractor !== undefined) return of(contractor);
    return this.http.get<Contractor>(this.baseUrl + 'contractor/' + id);
  }

  createContractor(model:any){
    return this.http.post(this.baseUrl + 'contractor/createcon', model);
  }
 
  createPremConLink(model:any){
    return this.http.post(this.baseUrl + 'premisecontractor/conprem', model);
  }

  updateContractor(contractor: Contractor){
    let url = this.baseUrl + 'contractor';
    return this.http.put<Contractor>(url, contractor).pipe(
      map(() => {
        const index = this.contractor.indexOf(contractor);
        this.contractor[index] = contractor
      })
    );
  }
}
