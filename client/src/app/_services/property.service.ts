import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PropContractorLink } from '../_models/propContractorLink';
import { Property } from '../_models/property';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {
  baseUrl = environment.apiUrl;
  property: Property[] = [];
  propertyContractor: PropContractorLink;

  constructor(private http: HttpClient) { }

  getProperties(){
    if (this.property.length > 0 ) return of(this.property);
    return this.http.get<Property[]>(this.baseUrl + 'premise').pipe(
      map(property => {
        this.property = property;
        return property;
      })
    );
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
     return this.http.delete(this.baseUrl + 'premise/removeaccountant/' + propId +','+ taskId);
  }

  removeAcc(propId: string){
    return this.http.get(this.baseUrl + 'premise/removeaccountant/'+ propId);
  }

  deleteNote(propId: string, noteId: string){ 
    return this.http.delete(this.baseUrl + 'premise/delnote/' + propId +','+ noteId);
 }
}
