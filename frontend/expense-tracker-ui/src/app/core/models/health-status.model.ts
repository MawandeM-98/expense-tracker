export interface HealthStatus {
  status: string;
  application: string;
  utcNow: string;
  databaseConnected: boolean;
  databaseProvider: string;
  databaseMessage: string | null;
}
