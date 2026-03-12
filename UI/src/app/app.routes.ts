import { Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { UserListComponent } from './pages/user-list/user-list.component';
import { ApplianceListComponent } from './pages/appliance-list/appliance-list.component';
import { UsageAnalyticsComponent } from './pages/usage-analytics/usage-analytics.component';
import { NotificationsComponent } from './pages/notifications/notifications.component';
import { AlertsComponent } from './pages/alerts/alerts.component';
import { SensorsComponent } from './pages/sensors/sensors.component';
import { HomesComponent } from './pages/homes/homes.component';

export const routes: Routes = [
  { path: '', component: DashboardComponent },
  { path: 'appliances', component: ApplianceListComponent },
  { path: 'users', component: UserListComponent },
  { path: 'analytics', component: UsageAnalyticsComponent },
  { path: 'notifications', component: NotificationsComponent },
  { path: 'alerts', component: AlertsComponent },
  { path: 'sensors', component: SensorsComponent },
  { path: 'homes', component: HomesComponent },
  { path: '**', redirectTo: '' }
];
