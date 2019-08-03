import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { ILabColls } from 'src/model/dto';
import { LabColsHttpService } from 'src/http/lab-cols-http-provider';

@Injectable({ providedIn: 'root' })
export class LabColsResolver implements Resolve<Observable<ILabColls[]>>{

  constructor(private http: LabColsHttpService) { }

  resolve(): Observable<ILabColls[]> {
    return this.http.list();
  }
}


@Injectable({ providedIn: 'root' })
export class FindLabColResolver implements Resolve<Observable<ILabColls>>{

  constructor(private http: LabColsHttpService) { }

  resolve(route: ActivatedRouteSnapshot): Observable<ILabColls> {
    return this.http.find(parseInt(route.paramMap.get('id')));
  }
}
