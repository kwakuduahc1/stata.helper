import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddProjectComponent } from './components/projects/add-project/add-project.component';
import { HomeComponent } from './components/home/home.component';
import { AddLabColsComponent } from './components/labcols/add-lab-cols/add-lab-cols.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'projects', component: AddProjectComponent },
  { path: 'collections', component: AddLabColsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
