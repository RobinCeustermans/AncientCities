import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CityType } from '../models/city-type';

@Injectable({
  providedIn: 'root'
})
export class CityTypeService {
  private apiUrl = 'http://localhost:5000/api/citytype';

  constructor(private http: HttpClient) { }

  getCityTypes(): Observable<CityType[]> {
    return this.http.get<CityType[]>(this.apiUrl);
  }
}
