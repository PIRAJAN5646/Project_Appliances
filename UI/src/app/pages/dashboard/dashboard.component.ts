import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApplianceService } from '../../services/appliance.service';
import { UserService } from '../../services/user.service';
import { Appliance, User } from '../../models/types';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit {
  
  totalAppliances = 0;
  activeAppliances = 0;
  totalUsers = 0;
  appliances: Appliance[] = [];
  recentUsers: User[] = [];
  loading = true;
  error = '';

  constructor(
    private applianceService: ApplianceService,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.loadDashboardData();
  }

  loadDashboardData(): void {
    this.applianceService.getAppliances().subscribe({
      next: (appliances) => {
        this.appliances = appliances;
        this.totalAppliances = appliances.length;
        this.activeAppliances = appliances.filter(a => a.status === 'Active').length;
      },
      error: (err) => {
        this.error = 'Could not load appliances. Make sure the API is running.';
        console.error(err);
      }
    });

    this.userService.getUsers().subscribe({
      next: (users) => {
        this.totalUsers = users.length;
        this.recentUsers = users.slice(0, 5);
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Could not load users. Make sure the API is running.';
        console.error(err);
        this.loading = false;
      }
    });
  }
}
