import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApplianceService } from '../../services/appliance.service';
import { Appliance } from '../../models/types';

@Component({
  selector: 'app-appliance-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './appliance-list.component.html',
  styleUrl: './appliance-list.component.css'
})
export class ApplianceListComponent implements OnInit {
  appliances: Appliance[] = [];
  loading = true;
  error = '';

  constructor(private applianceService: ApplianceService) {}

  ngOnInit(): void {
    this.applianceService.getAppliances().subscribe({
      next: (data) => {
        this.appliances = data;
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Failed to load appliances. Ensure the API server is running.';
        this.loading = false;
        console.error(err);
      }
    });
  }

  deleteAppliance(id: number): void {
    if (confirm('Are you sure you want to delete this appliance?')) {
      this.applianceService.deleteAppliance(id).subscribe({
        next: () => {
          this.appliances = this.appliances.filter(a => a.appliance_id !== id);
        },
        error: (err) => console.error('Delete failed', err)
      });
    }
  }
}
