import { Injectable } from "@angular/core";
import { HttpHeaders } from '@angular/common/http';

@Injectable({ providedIn: 'root'})
export class TokenProvider {
  private getAsyncToken() {
    return localStorage.getItem("jwt");
  }

  getHeader(): HttpHeaders {
    return new HttpHeaders({
      "Authorization": "Bearer " + this.getAsyncToken(),

    })
  }

  constructor() {
  }
}
