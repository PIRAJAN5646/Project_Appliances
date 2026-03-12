export interface User {
  user_id: number;
  name: string;
  email: string;
  password_hash?: string;
  created_at?: string;
  updated_at?: string;
}

export interface Home {
  home_id: number;
  user_id: number;
  name: string;
  address: string;
  created_at?: string;
}

export interface Appliance {
  appliance_id: number;
  type_id: number;
  home_id: number;
  model: string;
  name: string;
  device_identifier: string;
  installed_at: string;
  status: string;
}

export interface ApplianceType {
  type_id: number;
  name: string;
  category: string;
  avg_energy_rating: number;
  avg_water_rating: number;
}

export interface EnergyUsage {
  energy_usage_id: number;
  appliance_id: number;
  date: string;
  kwh_consumed: number;
  peak_usage: number;
  cost_estimated: number;
}

export interface WaterUsage {
  water_usage_id: number;
  appliance_id: number;
  date: string;
  liters_consumed: number;
  cycle_count: number;
  cost_estimated: number;
}

export interface Alert {
  alert_id: number;
  appliance_id: number;
  alert_type: string;
  message: string;
  is_resolved: boolean;
  severity: number;
  created_at: string;
}

export interface Notification {
  notification_id: number;
  user_id: number;
  alert_id: number;
  channel: number;
  sent_at: string;
  read_at: string;
}

export interface SensorData {
  Sensor_id: number;
  appliance_id: number;
  timestramp: string;
  reading_type: string;
  unit: string;
  value: number;
}
