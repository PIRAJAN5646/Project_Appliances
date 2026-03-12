import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotificationService } from '../../services/notification.service';
import { Notification } from '../../models/types';

@Component({
  selector: 'app-notifications',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="page-header"><div class="header-titles"><h1>Notifications</h1><p class="subtitle">System alerts and messages sent to users.</p></div></div>
    <div class="error-banner" *ngIf="error"><p>⚠ {{ error }}</p></div>
    <div class="loading" *ngIf="loading"><p>Loading notifications...</p></div>
    <div class="card-panel table-card" *ngIf="!loading && notifications.length > 0">
      <div class="table-responsive">
        <table class="batman-table">
          <thead><tr><th>ID</th><th>User ID</th><th>Alert ID</th><th>Channel</th><th>Sent At</th><th>Read At</th></tr></thead>
          <tbody>
            <tr *ngFor="let n of notifications">
              <td class="text-secondary">#{{ n.notification_id }}</td>
              <td>#{{ n.user_id }}</td>
              <td>#{{ n.alert_id }}</td>
              <td><span class="power-badge" [ngClass]="n.channel === 1 ? 'medium' : 'low'">{{ n.channel === 1 ? 'Email' : n.channel === 2 ? 'SMS' : 'Push' }}</span></td>
              <td class="text-secondary">{{ n.sent_at | date:'medium' }}</td>
              <td class="text-secondary">{{ n.read_at | date:'medium' }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <div class="empty-state" *ngIf="!loading && notifications.length === 0 && !error"><p>No notifications found.</p></div>
  `,
  styles: [`
    .page-header { display: flex; justify-content: space-between; align-items: center; margin-bottom: 2rem; }
    .header-titles h1 { font-size: 2rem; font-weight: 800; text-transform: uppercase; margin-bottom: 0.25rem; }
    .subtitle { color: var(--text-secondary); font-size: 0.95rem; }
    .table-card { padding: 0; overflow: hidden; }
  `]
})
export class NotificationsComponent implements OnInit {
  notifications: Notification[] = [];
  loading = true;
  error = '';
  constructor(private notificationService: NotificationService) {}
  ngOnInit(): void {
    this.notificationService.getAll().subscribe({
      next: (data) => { this.notifications = data; this.loading = false; },
      error: (err) => { this.error = 'Failed to load notifications.'; this.loading = false; console.error(err); }
    });
  }
}
