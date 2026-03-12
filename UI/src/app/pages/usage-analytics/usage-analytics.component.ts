import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EnergyUsageService } from '../../services/energy-usage.service';
import { WaterUsageService } from '../../services/water-usage.service';
import { EnergyUsage, WaterUsage } from '../../models/types';

@Component({
  selector: 'app-usage-analytics',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './usage-analytics.component.html',
  styleUrl: './usage-analytics.component.css'
})
export class UsageAnalyticsComponent implements OnInit {
  energyData: EnergyUsage[] = [];
  waterData: WaterUsage[] = [];
  loading = true;
  error = '';

  totalKwh = 0;
  totalLiters = 0;
  totalEnergyCost = 0;
  totalWaterCost = 0;
  maxKwh = 1;
  maxLiters = 1;

  constructor(
    private energyService: EnergyUsageService,
    private waterService: WaterUsageService
  ) {}

  ngOnInit(): void {
    this.energyService.getAll().subscribe({
      next: (data) => {
        this.energyData = data;
        this.totalKwh = data.reduce((s, e) => s + e.kwh_consumed, 0);
        this.totalEnergyCost = data.reduce((s, e) => s + e.cost_estimated, 0);
        this.maxKwh = Math.max(...data.map(e => e.kwh_consumed), 1);
      },
      error: (err) => { this.error = 'Could not load energy data.'; console.error(err); }
    });

    this.waterService.getAll().subscribe({
      next: (data) => {
        this.waterData = data;
        this.totalLiters = data.reduce((s, w) => s + w.liters_consumed, 0);
        this.totalWaterCost = data.reduce((s, w) => s + w.cost_estimated, 0);
        this.maxLiters = Math.max(...data.map(w => w.liters_consumed), 1);
        this.loading = false;
      },
      error: (err) => { this.error = 'Could not load water data.'; this.loading = false; console.error(err); }
    });
  }

  getBarHeight(value: number, max: number): number {
    return max > 0 ? (value / max) * 100 : 0;
  }
}
