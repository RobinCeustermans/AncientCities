import { Component, Input } from '@angular/core';
import { CityType } from '../../models/city-type';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-city-type',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './city-type.component.html',
  styleUrl: './city-type.component.scss'
})
export class CityTypeComponent {
  @Input() cityType!: CityType;
  @Input() deleteCityType!: (id: number) => void;

  onDeleteCityType(): void {
    if (confirm('Are you sure you want to delete this city type?')) {
      this.deleteCityType(this.cityType.id);
    }
  }
}
