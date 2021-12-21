import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Note } from '../_models/note';

@Injectable({
  providedIn: 'root'
})
export class NotesService {
  baseUrl = environment.apiUrl;
  note: Note[] = [];
  constructor(private http: HttpClient) { }

  getNotes(){
    return this.http.get<Note[]>(this.baseUrl + 'note').pipe(
      map(note => {
        this.note = note;
        return note;
      })
    )
  }

  getNote(id: string){
    const note = this.note.find(x => x.id === id);
    if(note !== undefined) return of(note);
    return this.http.get<Note>(this.baseUrl + 'note/' + id);
  }

  createNote(model: any){
    return this.http.post(this.baseUrl + 'note/createNote', model);
  }

  updateNote(note: Note){
    let url = this.baseUrl + 'note';
    return this.http.put<Note>(url, note).pipe(
      map(() => {
        const index = this.note.indexOf(note);
        this.note[index] = note;
      })
    )
  }
}
