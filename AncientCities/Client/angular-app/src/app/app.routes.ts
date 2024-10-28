import { Routes } from '@angular/router';
import { CityFormComponent } from './components/city-form/city-form.component';
import { CityListComponent } from './components/city-list/city-list.component';
import { CityTypeListComponent } from './components/city-type-list/city-type-list.component';
import { CityTypeFormComponent } from './components/city-type-form/city-type-form.component';

const routes: Routes = [
  { path: '', component: CityListComponent },
  { path: 'citytypes', component: CityTypeListComponent },
  { path: 'create-city', component: CityFormComponent },
  { path: 'edit-city/:id', component: CityFormComponent },
  { path: 'create-citytype', component: CityTypeFormComponent },
  { path: 'edit-citytype/:id', component: CityTypeFormComponent },
];

export default routes;

