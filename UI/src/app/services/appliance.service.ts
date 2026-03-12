import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Appliance } from '../models/types';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApplianceService {
  private apiUrl = `${environment.apiUrl}/Appliance`;

  constructor(private http: HttpClient) {}

  getAppliances(): Observable<Appliance[]> {
    return this.http.get<Appliance[]>(this.apiUrl);
  }

  getAppliance(id: number): Observable<Appliance> {
    return this.http.get<Appliance>(`${this.apiUrl}/id/${id}`);
  }

  createAppliance(appliance: Partial<Appliance>): Observable<Appliance> {
    return this.http.post<Appliance>(this.apiUrl, appliance);
  }

  deleteAppliance(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/id/${id}`);
  }
}
