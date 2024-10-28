import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule, RouterLink } from '@angular/router';
import { CityType } from '../../models/city-type';
import { CityTypeService } from '../../services/city-type.service';
import { CityTypeComponent } from '../city-type/city-type.component';

@Component({
  selector: 'app-city-type-list',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule, CityTypeComponent],
  templateUrl: './city-type-list.component.html',
  styleUrl: './city-type-list.component.scss'
})

export class CityTypeListComponent {
  cityTypes: CityType[] = [];

  constructor(private cityTypeService: CityTypeService) { }

  ngOnInit() : void {
    this.loadCityTypes();
  }

  loadCityTypes(): void
  {
    this.cityTypeService.getCityTypes().subscribe(types => {
      this.cityTypes = types;
    })
  }

  deleteCityType(id: number): void {
    this.cityTypeService.deleteCityType(id).subscribe(() => {
      this.loadCityTypes();
    });
  }
}
