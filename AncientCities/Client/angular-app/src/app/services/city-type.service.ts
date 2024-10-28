import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CityType } from '../models/city-type';

@Injectable({
  providedIn: 'root'
})
export class CityTypeService {
  private apiUrl = 'http://localhost:5000/api/apicitytype';

  constructor(private http: HttpClient) { }

  getCityTypes(): Observable<CityType[]> {
    return this.http.get<CityType[]>(this.apiUrl);
  }

  getCityType(id: number): Observable<CityType> {
    return this.http.get<CityType>(`${this.apiUrl}/${id}`);
  }

  saveCityType(cityType: CityType): Observable<CityType> {
    if (cityType.id === 0) {
      return this.http.post<CityType>(this.apiUrl, cityType);
    } else {
      return this.http.put<CityType>(`${this.apiUrl}/${cityType.id}`, cityType);
    }
  }

  deleteCityType(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
