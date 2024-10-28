import { Component, Input } from '@angular/core';
import { City } from '../../models/city.model';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-city',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.scss']
})
export class CityComponent {
  @Input() city!: City;
  @Input() deleteCity!: (id: number) => void;

  onDeleteCity(): void {
    if (confirm('Are you sure you want to delete this city?')) {
      this.deleteCity(this.city.id);
    }
  }
}
