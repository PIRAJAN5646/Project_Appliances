import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user.service';
import { User } from '../../models/types';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="page-header">
      <div class="header-titles">
        <h1>User Management</h1>
        <p class="subtitle">View and manage registered users.</p>
      </div>
    </div>

    <div class="error-banner" *ngIf="error">
      <p>⚠ {{ error }}</p>
    </div>

    <div class="loading" *ngIf="loading">
      <p>Loading users...</p>
    </div>

    <div class="card-panel table-card" *ngIf="!loading && users.length > 0">
      <div class="table-responsive">
        <table class="batman-table">
          <thead>
            <tr>
              <th>ID</th>
              <th>Name</th>
              <th>Email</th>
              <th>Created</th>
              <th class="text-right">Actions</th>
            </tr>
          </thead>
          <tbody>
            <tr *ngFor="let user of users">
              <td class="text-secondary">#{{ user.user_id }}</td>
              <td class="font-medium">{{ user.name }}</td>
              <td class="text-secondary">{{ user.email }}</td>
              <td class="text-secondary">{{ user.created_at | date:'shortDate' }}</td>
              <td class="text-right">
                <button class="btn btn-icon danger" title="Delete" (click)="deleteUser(user.user_id)">
                   <svg width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><line x1="18" y1="6" x2="6" y2="18"></line><line x1="6" y1="6" x2="18" y2="18"></line></svg>
                </button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>

    <div class="empty-state" *ngIf="!loading && users.length === 0 && !error">
      <p>No users found. Register one via the API.</p>
    </div>
  `,
  styles: [`
    .page-header { display: flex; justify-content: space-between; align-items: center; margin-bottom: 2rem; }
    .header-titles h1 { font-size: 2rem; font-weight: 800; text-transform: uppercase; margin-bottom: 0.25rem; }
    .subtitle { color: var(--text-secondary); font-size: 0.95rem; }
    .table-card { padding: 0; overflow: hidden; }
  `]
})
export class UserListComponent implements OnInit {
  users: User[] = [];
  loading = true;
  error = '';

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.userService.getUsers().subscribe({
      next: (data) => {
        this.users = data;
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Failed to load users. Ensure the API server is running.';
        this.loading = false;
        console.error(err);
      }
    });
  }

  deleteUser(id: number): void {
    if (confirm('Are you sure you want to delete this user?')) {
      this.userService.deleteUser(id).subscribe({
        next: () => {
          this.users = this.users.filter(u => u.user_id !== id);
        },
        error: (err) => console.error('Delete failed', err)
      });
    }
  }
}
