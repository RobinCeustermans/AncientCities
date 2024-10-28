import { Component, OnInit } from '@angular/core';
import { CityType } from '../../models/city-type';
import { ActivatedRoute, Router } from '@angular/router';
import { CityTypeService } from '../../services/city-type.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-city-type-form',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './city-type-form.component.html',
  styleUrl: './city-type-form.component.scss'
})
export class CityTypeFormComponent implements OnInit{
  cityType: CityType = new CityType();
  isEditMode = false;

  constructor(
    private cityTypeService: CityTypeService,
    private router: Router,
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    const cityTypeId = this.route.snapshot.params['id'];
    if (cityTypeId) {
      this.isEditMode = true;
      this.cityTypeService.getCityType(cityTypeId).subscribe(cityType => {
        this.cityType = cityType;
      });
    }
  }

  cancel() {
    this.router.navigate(['/citytypes']);
  }

  saveCityType(): void {
    this.cityTypeService.saveCityType(this.cityType).subscribe(() => {
      this.router.navigate(['/citytypes']);
    });
  }
}
