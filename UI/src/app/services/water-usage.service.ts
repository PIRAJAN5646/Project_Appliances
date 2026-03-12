import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WaterUsage } from '../models/types';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class WaterUsageService {
  private apiUrl = `${environment.apiUrl}/WaterUsage`;
  constructor(private http: HttpClient) {}

  getAll(): Observable<WaterUsage[]> {
    return this.http.get<WaterUsage[]>(this.apiUrl);
  }
}
