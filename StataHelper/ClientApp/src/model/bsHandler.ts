import { HttpErrorResponse } from "@angular/common/http";
import { Router } from '@angular/router';
import { ToastrService } from "ngx-toastr";
import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })
export class bsHandler {

  constructor(private router: Router, private toast: ToastrService) {
  }

  onError(err: HttpErrorResponse) {
    let message = "";
    if (err.error.message) {
      message = err.error.message;
    }
    else if (err.status >= 500)
      message = "A server level occurred. Please try again or contact support";
    else if (!err.error) {
      switch (err.status) {
        case 500:
          message = "A server error occurred. Contact support";
          break;
        case 400:
          message = "A bad request was made to the server.\nCheck the request and try again.\n A log has been created";
          break;
        case 401:
          message = 'Login and try again';
          this.router.navigate(['/login']);
          break;
        case 403:
          message = "Authorization failure";
          this.router.navigate(['/login']);
          break;
        default:
          message = "An unexpected error occurred. Contact support";
          break;
      }
    }
    else
      message = err.statusText
    this.toast.error(message);
  }
}
