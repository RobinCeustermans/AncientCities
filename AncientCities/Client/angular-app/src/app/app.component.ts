import { Component, ViewEncapsulation } from '@angular/core';
import { RouterOutlet, RouterModule } from '@angular/router';
import { CityListComponent } from './components/city-list/city-list.component';
import { CityFormComponent } from './components/city-form/city-form.component';
import { HttpClient } from '@angular/common/http'; 
import { CityTypeListComponent } from './components/city-type-list/city-type-list.component';
import { CityTypeFormComponent } from './components/city-type-form/city-type-form.component';

@Component({
  selector: 'app-root',
  standalone: true,
  encapsulation: ViewEncapsulation.None,
  imports: [RouterOutlet, RouterModule, CityListComponent, CityFormComponent, CityTypeListComponent, CityTypeFormComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ancient-cities';
}
