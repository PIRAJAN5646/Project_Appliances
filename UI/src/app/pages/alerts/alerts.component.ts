import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AlertService } from '../../services/alert.service';
import { Alert } from '../../models/types';

@Component({
  selector: 'app-alerts',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './alerts.component.html',
  styleUrl: './alerts.component.css'
})
export class AlertsComponent implements OnInit {
  alerts: Alert[] = [];
  filteredAlerts: Alert[] = [];
  loading = true;
  error = '';

  filterResolved = 'all';
  filterSeverity = 'all';

  constructor(private alertService: AlertService) {}

  ngOnInit(): void {
    this.alertService.getAll().subscribe({
      next: (data) => {
        this.alerts = data;
        this.filteredAlerts = data;
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Failed to load alerts.';
        this.loading = false;
        console.error(err);
      }
    });
  }

  applyFilters(): void {
    this.filteredAlerts = this.alerts.filter(a => {
      const matchResolved =
        this.filterResolved === 'all' ||
        (this.filterResolved === 'yes' && a.is_resolved) ||
        (this.filterResolved === 'no' && !a.is_resolved);

      const matchSeverity =
        this.filterSeverity === 'all' ||
        (this.filterSeverity === 'critical' && a.severity >= 8) ||
        (this.filterSeverity === 'warning' && a.severity >= 5 && a.severity < 8) ||
        (this.filterSeverity === 'info' && a.severity < 5);

      return matchResolved && matchSeverity;
    });
  }
}
