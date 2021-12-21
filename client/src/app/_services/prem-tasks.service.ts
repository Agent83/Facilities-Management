import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { PremisesTask } from 'src/app/_models/premisesTask';
import { HttpClient } from '@angular/common/http';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class PremTasksService {
  baseUrl = environment.apiUrl;
  premTask: PremisesTask[]=[]
  constructor(private http: HttpClient) { }

  getPremTasks(){
    return this.http.get<PremisesTask[]>(this.baseUrl + 'premisestasks').pipe(
      map(premTask => {
        this.premTask = premTask;
        return premTask;
      })
    );
  }

  getTask(id: string){
    const premTask = this.premTask.find(x => x.id === id);
    if(premTask !== undefined) return of(premTask);
    return this.http.get<PremisesTask>(this.baseUrl + 'premisestasks/' + id);
  }

  createTask(model: any){
    return this.http.post(this.baseUrl + 'premisestasks/createTask', model);
  }

  updateTask(premTask: PremisesTask){
    let url = this.baseUrl + 'premisestasks';
    return this.http.put<PremisesTask>(url, premTask).pipe(
      map(() => {
        const index = this.premTask.indexOf(premTask);
        this.premTask[index] = premTask;
      })
    )
  }
}
