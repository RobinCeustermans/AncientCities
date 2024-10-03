import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CityListComponent } from './components/city-list/city-list.component';
import { CityFormComponent } from './components/city-form/city-form.component';
import { HttpClient } from '@angular/common/http'; 

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CityListComponent, CityFormComponent],
  template: `
    <main>
      <section class="content">
        <router-outlet></router-outlet>
      </section>
    </main>
  `,
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ancient-cities';
}
