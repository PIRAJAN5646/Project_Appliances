import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Alert } from '../models/types';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class AlertService {
  private apiUrl = `${environment.apiUrl}/Alert`;
  constructor(private http: HttpClient) {}

  getAll(): Observable<Alert[]> {
    return this.http.get<Alert[]>(this.apiUrl);
  }
}
