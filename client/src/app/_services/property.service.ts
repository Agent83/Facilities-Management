import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Property } from '../_models/property';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getProperties(){
    return this.http.get<Property[]>(this.baseUrl + 'premise');
  }

  getProperty(id: number){
    return this.http.get<Property>(this.baseUrl + 'premise/' + id);
  }

  createProperty(model: any){
    return this.http.post(this.baseUrl + 'premise/property', model);
  }
}
