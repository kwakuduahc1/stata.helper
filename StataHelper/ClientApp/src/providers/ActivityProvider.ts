import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })
export class ActivityProvider {
  isProcessing = false;
  isError = false;
  isDismissed = false;
  message = "";

  constructor() {
  }


  beginProc(): void {
    this.isProcessing = true;
    this.isDismissed = true;
    this.isError = false;
  }


  endProc(): void {
    this.isProcessing = false;
    this.isDismissed = this.isError ? true : false;
  }
}
