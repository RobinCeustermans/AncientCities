import { Routes } from '@angular/router';
import { CityFormComponent } from './components/city-form/city-form.component';
import { CityListComponent } from './components/city-list/city-list.component';

const routes: Routes = [
  { path: '', component: CityListComponent },
  { path: 'create-city', component: CityFormComponent },
  { path: 'edit-city/:id', component: CityFormComponent },
];

export default routes;

