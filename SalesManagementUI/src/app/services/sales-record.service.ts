// import { Injectable } from '@angular/core';

// @Injectable({
//   providedIn: 'root'
// })
// export class SalesRecordService {

//   constructor() { }
// }


import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';

// SalesRepresentative model
export interface SalesRepresentative {
  id: number;
  name?: string;
  contactDetails?: string;
  address?: string;
  position?: string;
  dateOfJoining: string;
}

// SalesRecord model
export interface SalesRecord {
  id: number;
  date: string;
  amount: number;
  productDetails?: string;
  customerInfo?: string;
  representativeId: number;
  representative?: SalesRepresentative;
}

@Injectable({
  providedIn: 'root'
})
export class SalesRecordService {

  private apiUrl = 'http://localhost:5050/api/SalesRecords';

  constructor(private http: HttpClient) { }

  // GET: Fetch all sales records
  // getAllSalesRecords(): Observable<SalesRecord[]> {
  //   return this.http.get<SalesRecord[]>(this.apiUrl);
  // }

  getAllSalesRecords(repId?: number, search?: string, startDate?: string, endDate?: string): Observable<SalesRecord[]> {
    let params = new HttpParams();
    if (repId) params = params.set('repId', repId.toString());
    if (search) params = params.set('search', search);
    if (startDate) params = params.set('startDate', startDate);
    if (endDate) params = params.set('endDate', endDate);

    return this.http.get<SalesRecord[]>(this.apiUrl, { params }).pipe(
      catchError(error => {
        console.error('Error fetching sales records:', error);
        return throwError(() => new Error('Failed to load sales records. Please try again later.'));
      }));
  }

  getAllRepresentatives(): Observable<SalesRepresentative[]> {
  return this.http.get<SalesRepresentative[]>(this.apiUrl.replace('SalesRecords', 'SalesRecords/Representatives'));
}

  // GET: Fetch a sales record by ID
  getSalesRecordById(id: number): Observable<SalesRecord> {
    return this.http.get<SalesRecord>(`${this.apiUrl}/${id}`);
  }

  // POST: Create a new sales record
  createSalesRecord(record: SalesRecord): Observable<any> {
    return this.http.post(this.apiUrl, record);
  }

  // PUT: Update an existing sales record
  updateSalesRecord(id: number, record: SalesRecord): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, record);
  }

  // DELETE: Delete a sales record by ID
  deleteSalesRecord(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
