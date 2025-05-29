import { Component, OnInit } from '@angular/core';
import { SalesRecord, SalesRecordService, SalesRepresentative } from '../../services/sales-record.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { } from '@angular/forms';
import { finalize } from 'rxjs';

@Component({
  selector: 'app-sales-records',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './sales-records.component.html',
  styleUrl: './sales-records.component.css'
})

export class SalesRecordsComponent implements OnInit {

  salesRecords: SalesRecord[] = [];
  representatives: SalesRepresentative[] = [];

  searchText: string = '';
  selectedRepresentativeId?: number;
  startDate?: string; // ISO date string e.g. '2025-05-28'
  endDate?: string;

  loading: boolean = false;
  errorMessage: string = '';

  constructor(private salesService: SalesRecordService) { }

  ngOnInit(): void {
    this.loadRepresentatives();
    this.applyFilters(); // load initial data
  }

  loadRepresentatives(): void {
    this.salesService.getAllRepresentatives().subscribe({
      next: (reps: SalesRepresentative[]) => this.representatives = reps,
      error: () => {
        this.errorMessage = 'Failed to load representatives.';
      }
    });
  }

  applyFilters(): void {
    this.loading = true;
    this.errorMessage = '';

    this.salesService.getAllSalesRecords(
      this.selectedRepresentativeId,
      this.searchText,
      this.startDate,
      this.endDate
    )
      .pipe(finalize(() => this.loading = false))
      .subscribe({
        next: (records: SalesRecord[]) => this.salesRecords = records,
        error: (err: { message: string; }) => this.errorMessage = err.message || 'Failed to load sales records.'
      });
  }

  clearFilters(): void {
    this.searchText = '';
    this.selectedRepresentativeId = undefined;
    this.startDate = undefined;
    this.endDate = undefined;
    this.applyFilters();
  }
}