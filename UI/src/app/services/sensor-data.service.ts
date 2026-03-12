import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SensorData } from '../models/types';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class SensorDataService {
  private apiUrl = `${environment.apiUrl}/SensorData`;
  constructor(private http: HttpClient) {}

  getAll(): Observable<SensorData[]> {
    return this.http.get<SensorData[]>(this.apiUrl);
  }
}
