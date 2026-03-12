import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeService } from '../../services/home.service';
import { Home } from '../../models/types';

@Component({
  selector: 'app-homes',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="page-header"><div class="header-titles"><h1>Homes</h1><p class="subtitle">Registered home locations.</p></div></div>
    <div class="error-banner" *ngIf="error"><p>⚠ {{ error }}</p></div>
    <div class="loading" *ngIf="loading"><p>Loading homes...</p></div>
    <div class="card-panel table-card" *ngIf="!loading && homes.length > 0">
      <div class="table-responsive">
        <table class="batman-table">
          <thead><tr><th>ID</th><th>Name</th><th>Address</th><th>Owner (User ID)</th><th>Created</th></tr></thead>
          <tbody>
            <tr *ngFor="let h of homes">
              <td class="text-secondary">#{{ h.home_id }}</td>
              <td class="font-medium">{{ h.name }}</td>
              <td>{{ h.address }}</td>
              <td>#{{ h.user_id }}</td>
              <td class="text-secondary">{{ h.created_at | date:'shortDate' }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <div class="empty-state" *ngIf="!loading && homes.length === 0 && !error"><p>No homes registered.</p></div>
  `,
  styles: [`
    .page-header { display: flex; justify-content: space-between; align-items: center; margin-bottom: 2rem; }
    .header-titles h1 { font-size: 2rem; font-weight: 800; text-transform: uppercase; margin-bottom: 0.25rem; }
    .subtitle { color: var(--text-secondary); font-size: 0.95rem; }
    .table-card { padding: 0; overflow: hidden; }
  `]
})
export class HomesComponent implements OnInit {
  homes: Home[] = [];
  loading = true;
  error = '';
  constructor(private homeService: HomeService) {}
  ngOnInit(): void {
    this.homeService.getAll().subscribe({
      next: (data) => { this.homes = data; this.loading = false; },
      error: (err) => { this.error = 'Failed to load homes.'; this.loading = false; console.error(err); }
    });
  }
}
