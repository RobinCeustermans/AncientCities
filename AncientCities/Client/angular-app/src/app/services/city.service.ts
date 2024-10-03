import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { City } from '../models/city.model';

@Injectable({
  providedIn: 'root'
})
export class CityService {
  private apiUrl = 'http://localhost:5000/api/apicity';

  constructor(private http: HttpClient) { }

  getAllCities(): Observable<City[]> {
    return this.http.get<City[]>(this.apiUrl);
  }

  getCity(id: number): Observable<City> {
    return this.http.get<City>(`${this.apiUrl}/${id}`);
  }

  saveCity(city: City): Observable<City> {
    if (city.id === 0) {
      return this.http.post<City>(this.apiUrl, city);
    } else {
      return this.http.put<City>(`${this.apiUrl}/${city.id}`, city);
    }
  }
  deleteCity(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
