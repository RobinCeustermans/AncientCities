import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { City } from '../../models/city.model';
import { CityService } from '../../services/city.service';
import { RouterLink, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-city-list',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
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
    if (confirm('Are you sure you want to delete this city?')) {
      this.cityService.deleteCity(id).subscribe(() => {
        this.loadCities();
      });
    }
  }
}
