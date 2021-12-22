import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Contractor } from '../_models/contractor';
import { PaginatedResult } from '../_models/pagination';

@Injectable({
  providedIn: 'root'
})
export class ContractorService {
baseUrl = environment.apiUrl;
contractor: Contractor[] = [];
paginatedResult: PaginatedResult<Contractor[]> = new PaginatedResult<Contractor[]>();
  constructor(private http: HttpClient) { }

  getContractors(page?: number, itemsPerPage?: number){
    let params = new HttpParams();

    if(page != null && itemsPerPage !== null){
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', itemsPerPage.toString());
    }
    return this.http.get<Contractor[]>(this.baseUrl + 'contractor',{observe: 'response', params}).pipe(
      map(respone => {
        this.paginatedResult.result = respone.body;
        if(respone.headers.get('Pagination') !== null){
          this.paginatedResult.pagination = JSON.parse(respone.headers.get('Pagination'));
        }
        return this.paginatedResult;
      })
    )
  }
  getContractorsearch(page?: number, itemsPerPage?: number, search?: string){
    let params = new HttpParams();
    if(page != null && itemsPerPage !== null && search != null){
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', itemsPerPage.toString());
      params = params.append('search', search);
    }
    return this.http.get<Contractor[]>(this.baseUrl + 'contractor',{observe: 'response', params}).pipe(
      map(respone => {
        this.paginatedResult.result = respone.body;
        if(respone.headers.get('Pagination') !== null){
          this.paginatedResult.pagination = JSON.parse(respone.headers.get('Pagination'));
        }
        return this.paginatedResult;
      })
    )
  }
  getContractorList(){
    return this.http.get<Contractor[]>(this.baseUrl + 'contractor/list').pipe(
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
  removeLink(propId: string, conId: string){
    return this.http.delete(this.baseUrl + 'premisecontractor/removelink/' + propId +','+ conId);
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

    deleteContractor(conId: string){ 
    return this.http.delete(this.baseUrl + 'contractor/delContractor/' + conId);
 }
}
