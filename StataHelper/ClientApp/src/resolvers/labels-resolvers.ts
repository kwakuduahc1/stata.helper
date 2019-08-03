import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { ILabels } from 'src/model/dto';
import { LabelsHttpService } from 'src/http/labels-http-provider';

@Injectable({ providedIn: 'root' })
export class LabelsResolver implements Resolve<Observable<ILabels[]>>{

  constructor(private http: LabelsHttpService) { }

  resolve(route: ActivatedRouteSnapshot): Observable<ILabels[]> {
    return this.http.list(parseInt(route.paramMap.get('id')));
  }
}


@Injectable({ providedIn: 'root' })
export class FindLabelResolver implements Resolve<Observable<ILabels>>{

  constructor(private http: LabelsHttpService) { }

  resolve(route: ActivatedRouteSnapshot): Observable<ILabels> {
    return this.http.find(parseInt(route.paramMap.get('id')));
  }
}
