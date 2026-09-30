import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { HealthStatus } from '../models/health-status.model';

@Injectable({
  providedIn: 'root'
})
export class HealthService {
  private readonly url = `${environment.apiBaseUrl}/health`;

  constructor(private readonly http: HttpClient) {}

  getStatus(): Observable<HealthStatus> {
    return this.http.get<HealthStatus>(this.url);
  }
}
