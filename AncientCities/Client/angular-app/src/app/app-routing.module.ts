import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CityFormComponent } from './components/city-form/city-form.component';
import { CityListComponent } from './components/city-list/city-list.component';

const routes: Routes = [
  { path: '', component: CityListComponent },
  { path: 'create-city', component: CityFormComponent },
  { path: 'edit-city/:id', component: CityFormComponent },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
