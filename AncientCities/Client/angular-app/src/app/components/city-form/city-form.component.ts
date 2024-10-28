import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { City } from '../../models/city.model';
import { CityService } from '../../services/city.service';
import { FormsModule } from '@angular/forms';
import { Era } from '../../models/era';
import { CommonModule } from '@angular/common';
import { CityTypeService } from '../../services/city-type.service';
import { CityType } from '../../models/city-type';

@Component({
  selector: 'app-city-form',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './city-form.component.html',
  styleUrls: ['./city-form.component.scss']
})
export class CityFormComponent implements OnInit {
  city: City = new City();
  cityTypes: CityType[] = [];
  isEditMode = false;

  eraOptions = Era;

  constructor(
    private cityService: CityService,
    private cityTypeService: CityTypeService,
    private router: Router,
    private route: ActivatedRoute,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    const cityId = this.route.snapshot.params['id'];
    if (cityId) {
      this.isEditMode = true;
      this.cityService.getCity(cityId).subscribe(city => {
        this.city = city;
        this.city.created = this.parseToDate(city.created);
        this.city.defunct = this.parseToDate(city.defunct);
        this.cdr.detectChanges();
      });
    }

    this.getCityTypes();
  }

  getCityTypes(): void {
    this.cityTypeService.getCityTypes().subscribe((types: CityType[]) => {
      this.cityTypes = types;
    });
  }

  cancel() {
    this.router.navigate(['/']);
  }

  parseToDate(dateString: string | Date | undefined): Date | undefined {
    if (dateString) {
      return new Date(dateString);
    }
    return undefined;
  }

  saveCity(): void {
    this.cityService.saveCity(this.city).subscribe(() => {
      this.router.navigate(['/']);
    });
  }

  formatDateForInput(date: Date | undefined): string | undefined {
    if (date) {
      let year = date.getFullYear().toString();
      if (date.getFullYear() < 1000 && date.getFullYear() > -1000) {
        year = '0' + year;
      }
      const month = String(date.getMonth() + 1).padStart(2, '0');
      const day = String(date.getDate()).padStart(2, '0');
      return `${year}-${month}-${day}`;
    }
    return undefined;
  }

  dateChange(event: any, field: keyof City): void {
    const value = event.target.value;
    if (field === 'created' || field === 'defunct') {
      (this.city as any)[field] = value ? new Date(value) : undefined;
    }
  }

  isEraEnabled(dateField: Date | undefined): boolean {
    return !!dateField;
  }
}

