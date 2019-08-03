import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ILabColls } from 'src/model/dto';

@Injectable({ providedIn: 'root' })
export class LabColsHttpService {


  constructor(private http: HttpClient) { }

  list(): Observable<ILabColls[]> {
    return this.http.get<ILabColls[]>("/Colls/List");
  }

  find(id: number): Observable<ILabColls> {
    return this.http.get<ILabColls>(`/Colls/Find?id=${id}`)
  }

  add(labcol: ILabColls): Observable<ILabColls> {
    return this.http.post<ILabColls>("/Colls/Create", labcol);
  }

  edit(labcol: ILabColls): Observable<ILabColls> {
    return this.http.post<ILabColls>("/Colls/Edit", labcol);
  }

  del(labcol: ILabColls): Observable<ILabColls> {
    return this.http.post<ILabColls>("/Colls/Delete", labcol);
  }
}
