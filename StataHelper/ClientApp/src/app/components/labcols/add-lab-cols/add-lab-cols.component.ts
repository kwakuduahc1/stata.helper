import { Component, OnInit } from '@angular/core';
import { ILabColls } from 'src/model/dto';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { LabColsHttpService } from 'src/http/lab-cols-http-provider';
import { ToastrService } from 'ngx-toastr';
import { ActivityProvider } from 'src/providers/ActivityProvider';

@Component({
  selector: 'app-add-lab-cols',
  templateUrl: './add-lab-cols.component.html',
  styleUrls: ['./add-lab-cols.component.css']
})
export class AddLabColsComponent implements OnInit {

  colls: ILabColls[];
  form: FormGroup;
  constructor(tit: Title, fb: FormBuilder, route: ActivatedRoute, private http: LabColsHttpService, private toast:ToastrService, private act:ActivityProvider) {
    tit.setTitle("Labels Collections");
    this.colls = route.snapshot.data.colls;
    this.form = fb.group({
      labelName: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(20)])],
      description: ['', Validators.compose([Validators.minLength(5), Validators.maxLength(50)])]
    });
  }

  ngOnInit() {}

  add(col: ILabColls) {
    if (confirm('Do you want to add this label collection')) {
      this.http.add(col).subscribe(res => {
        this.colls.unshift(res);
        this.form.reset();
        this.toast.success("A collection was added");
      })
    }
  }

  del(ix: number) {
    if (confirm('Confirm you want to delete this collection and all related labels')) {
      this.http.del(this.colls[ix]).subscribe(res => {
        this.colls.splice(ix, 1);
        this.toast.success('The entry was deleted');
      })
    }
  }
}
