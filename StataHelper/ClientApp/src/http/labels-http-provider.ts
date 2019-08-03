import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ILabels } from 'src/model/dto';

@Injectable({ providedIn: 'root' })
export class LabelsHttpService {


  constructor(private http: HttpClient) { }

  list(id: number): Observable<ILabels[]> {
    return this.http.get<ILabels[]>(`/Labels/List?id=${id}`);
  }

  find(id: number): Observable<ILabels> {
    return this.http.get<ILabels>(`/Labels/Find?id=${id}`)
  }

  add(labcol: ILabels): Observable<ILabels> {
    return this.http.post<ILabels>("/Labels/Create", labcol);
  }

  edit(labcol: ILabels): Observable<ILabels> {
    return this.http.post<ILabels>("/Labels/Edit", labcol);
  }

  del(labcol: ILabels): Observable<ILabels> {
    return this.http.post<ILabels>("/Labels/Delete", labcol);
  }
}
