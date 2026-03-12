import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Home } from '../models/types';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class HomeService {
  private apiUrl = `${environment.apiUrl}/Home`;
  constructor(private http: HttpClient) {}

  getAll(): Observable<Home[]> {
    return this.http.get<Home[]>(this.apiUrl);
  }
}
