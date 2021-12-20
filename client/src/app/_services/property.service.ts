import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PaginatedResult } from '../_models/pagination';
import { PropContractorLink } from '../_models/propContractorLink';
import { Property } from '../_models/property';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {
  baseUrl = environment.apiUrl;
  property: Property[] = [];
  propertyContractor: PropContractorLink;
  paginatedResult: PaginatedResult<Property[]> = new PaginatedResult<Property[]>();
  constructor(private http: HttpClient) { }

  getProperties(page?: number, itemsPerPage?: number){
    let params = new HttpParams();

    if(page != null && itemsPerPage !== null){
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', itemsPerPage.toString());
    }
    return this.http.get<Property[]>(this.baseUrl + 'premise',{observe: 'response', params}).pipe(
      map(respone => {
        this.paginatedResult.result = respone.body;
        if(respone.headers.get('Pagination') !== null){
          this.paginatedResult.pagination = JSON.parse(respone.headers.get('Pagination'));
        }
        return this.paginatedResult;
      })
    )
  }

  getProperty(id: string){
    const property = this.property.find(x => x.id === id);
    if(property !== undefined) return of(property);
    return this.http.get<Property>(this.baseUrl + 'premise/' + id);
  }

  createProperty(model: any){
    return this.http.post(this.baseUrl + 'premise/property', model);
  }

  updateProperty(property: Property){
    let url = this.baseUrl + 'premise';
    return this.http.put<Property>(url, property).pipe(
      map(() => {
        const index = this.property.indexOf(property);
        this.property[index] = property;
      })
    );
  }

  removeTask(propId: string, taskId: string){ 
     return this.http.delete(this.baseUrl + 'premise/deltasks/' + propId +','+ taskId);
  }

  removeAcc(propId: string){
    return this.http.get(this.baseUrl + 'premise/removeaccountant/'+ propId);
  }

  deleteNote(propId: string, noteId: string){ 
    return this.http.delete(this.baseUrl + 'premise/delnote/' + propId +','+ noteId);
 }

 deletePremise(propId: string){ 
  return this.http.delete(this.baseUrl + 'premise/delpremise/' + propId );
}

}
