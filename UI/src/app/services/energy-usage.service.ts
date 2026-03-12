import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EnergyUsage } from '../models/types';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class EnergyUsageService {
  private apiUrl = `${environment.apiUrl}/EnergyUsage`;
  constructor(private http: HttpClient) {}

  getAll(): Observable<EnergyUsage[]> {
    return this.http.get<EnergyUsage[]>(this.apiUrl);
  }
}
