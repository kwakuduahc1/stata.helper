import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { finalize, tap } from 'rxjs/operators'
import { bsHandler } from '../model/bsHandler';
import { ActivityProvider } from '../providers/ActivityProvider';
import { TokenProvider } from '../providers/TokenProvider';

const headerName = 'Authorization';
@Injectable()
export class AuthInterceptorService implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let nreq = req.clone({ headers: req.headers.append(headerName, this.token.getHeader().get(headerName)) });
    return next.handle(nreq);
  }
  constructor(private token: TokenProvider) {
  }
}

@Injectable()
export class ErrorHandlerInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.act.beginProc();
    return next.handle(req).pipe(
      tap(() => { }, err => this.hand.onError(err)), finalize(() => this.act.endProc()));
  }
  constructor(private act: ActivityProvider, private hand: bsHandler) {
  }
}
