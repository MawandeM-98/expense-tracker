import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { HealthStatus } from '../../core/models/health-status.model';
import { HealthService } from '../../core/services/health.service';

@Component({
  selector: 'app-root',
  imports: [CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'Expense Tracker';
  loading = true;
  error: string | null = null;
  health: HealthStatus | null = null;

  constructor(private readonly healthService: HealthService) {}

  ngOnInit(): void {
    this.refresh();
  }

  refresh(): void {
    this.loading = true;
    this.error = null;

    this.healthService.getStatus().subscribe({
      next: (health) => {
        this.health = health;
        this.loading = false;
      },
      error: () => {
        this.health = null;
        this.loading = false;
        this.error =
          'Could not reach the API. Start ExpenseTracker.API on http://localhost:5000, then try again.';
      }
    });
  }
}
