import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddProjectComponent } from './components/projects/add-project/add-project.component';
import { HomeComponent } from './components/home/home.component';
import { AddLabColsComponent } from './components/labcols/add-lab-cols/add-lab-cols.component';
import { LabColsResolver, FindLabColResolver } from 'src/resolvers/lab-cols-resolvers';
import { AddLabelsComponent } from './components/labels/add-labels/add-labels.component';
import { LabelsResolver } from 'src/resolvers/labels-resolvers';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'projects', component: AddProjectComponent },
  { path: 'collections', component: AddLabColsComponent, resolve: { colls: LabColsResolver } },
  { path: 'labels/:id', component: AddLabelsComponent, resolve: { coll: FindLabColResolver, labels: LabelsResolver } }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
