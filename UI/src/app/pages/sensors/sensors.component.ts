import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SensorDataService } from '../../services/sensor-data.service';
import { SensorData } from '../../models/types';

@Component({
  selector: 'app-sensors',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="page-header"><div class="header-titles"><h1>Sensor Data</h1><p class="subtitle">Real-time sensor readings from appliances.</p></div></div>
    <div class="error-banner" *ngIf="error"><p>⚠ {{ error }}</p></div>
    <div class="loading" *ngIf="loading"><p>Loading sensor data...</p></div>
    <div class="card-panel table-card" *ngIf="!loading && sensors.length > 0">
      <div class="table-responsive">
        <table class="batman-table">
          <thead><tr><th>Sensor ID</th><th>Appliance</th><th>Reading Type</th><th>Value</th><th>Unit</th><th>Timestamp</th></tr></thead>
          <tbody>
            <tr *ngFor="let s of sensors">
              <td class="text-secondary">#{{ s.Sensor_id }}</td>
              <td>#{{ s.appliance_id }}</td>
              <td class="font-medium">{{ s.reading_type }}</td>
              <td class="text-yellow-inline">{{ s.value }}</td>
              <td>{{ s.unit }}</td>
              <td class="text-secondary">{{ s.timestramp | date:'medium' }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <div class="empty-state" *ngIf="!loading && sensors.length === 0 && !error"><p>No sensor data available.</p></div>
  `,
  styles: [`
    .page-header { display: flex; justify-content: space-between; align-items: center; margin-bottom: 2rem; }
    .header-titles h1 { font-size: 2rem; font-weight: 800; text-transform: uppercase; margin-bottom: 0.25rem; }
    .subtitle { color: var(--text-secondary); font-size: 0.95rem; }
    .table-card { padding: 0; overflow: hidden; }
    .text-yellow-inline { color: #fce205 !important; font-weight: 600; }
  `]
})
export class SensorsComponent implements OnInit {
  sensors: SensorData[] = [];
  loading = true;
  error = '';
  constructor(private sensorService: SensorDataService) {}
  ngOnInit(): void {
    this.sensorService.getAll().subscribe({
      next: (data) => { this.sensors = data; this.loading = false; },
      error: (err) => { this.error = 'Failed to load sensor data.'; this.loading = false; console.error(err); }
    });
  }
}
