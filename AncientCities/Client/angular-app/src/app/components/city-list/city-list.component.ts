import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { City } from '../../models/city.model';
import { CityService } from '../../services/city.service';
import { RouterLink, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CityComponent } from '../city/city.component';

@Component({
  selector: 'app-city-list',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule, CityComponent],
  templateUrl: './city-list.component.html',
  styleUrls: ['./city-list.component.scss']
})

export class CityListComponent implements OnInit {
  cities: City[] = [];

  constructor(private cityService: CityService) { }

  ngOnInit(): void {
    this.loadCities();
  }

  loadCities(): void {
    this.cityService.getAllCities().subscribe(cities => {
      this.cities = cities;
    });
  }

  deleteCity(id: number): void {
    this.cityService.deleteCity(id).subscribe(() => {
      this.loadCities();
    });
  }
}
