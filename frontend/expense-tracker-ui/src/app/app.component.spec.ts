import { TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { AppComponent } from './app.component';
import { HealthService } from './core/services/health.service';

describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppComponent],
      providers: [
        {
          provide: HealthService,
          useValue: {
            getStatus: () =>
              of({
                status: 'ok',
                application: 'ExpenseTracker.API',
                utcNow: new Date().toISOString(),
                databaseConnected: true,
                databaseProvider: 'Npgsql.EntityFrameworkCore.PostgreSQL',
                databaseMessage: 'Successfully connected to PostgreSQL.'
              })
          }
        }
      ]
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    expect(fixture.componentInstance).toBeTruthy();
  });

  it('should show the application title', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('h1')?.textContent).toContain('Expense Tracker');
  });
});
