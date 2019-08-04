import { Component, OnInit } from '@angular/core';
import { ILabColls, ILabels } from 'src/model/dto';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { LabColsHttpService } from 'src/http/lab-cols-http-provider';
import { ToastrService } from 'ngx-toastr';
import { ActivityProvider } from 'src/providers/ActivityProvider';

@Component({
  selector: 'app-add-labels',
  templateUrl: './add-labels.component.html',
  styleUrls: ['./add-labels.component.css']
})
export class AddLabelsComponent implements OnInit {
  coll: ILabColls;
  forms: FormGroup[] = [];
  labs: ILabels[];
  form: FormGroup;
  constructor(tit: Title, private fb: FormBuilder, route: ActivatedRoute, private http: LabColsHttpService, private toast: ToastrService, private act: ActivityProvider) {
    tit.setTitle("Labels");
    this.coll = route.snapshot.data.coll;
    this.labs = route.snapshot.data.labels;
    this.form = this.fb.group({
      number: ['', Validators.compose([Validators.required, Validators.min(1), Validators.max(20)])]
    })
  }

  ngOnInit() { }

  getForms(ix: number) {
    for (var i = 0; i < ix; i++) {
      this.forms.push(this.fb.group({
        key: [i, Validators.compose([Validators.required, Validators.min(0), Validators.max(20)])],
        label: ['', Validators.compose([Validators.minLength(2), Validators.maxLength(15)])]
      }));
    }
  }

  removeForm(ix) {
    if (confirm('Removing this is not reversible')) {
      this.forms.splice(ix, 1);
      this.toast.success("Removed");
    }
  }
  gen() {
    let arr: string[] = [];
    this.labs.forEach(x => arr.unshift(`${x.key} "${x.label}"`));
    console.log(`label define ${this.coll.labelName} ${arr.join(' ')}`);
  }
}
