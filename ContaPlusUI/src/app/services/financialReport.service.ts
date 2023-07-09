import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'environments/environment';
@Injectable({
  providedIn: 'root'
})
export class FinancialReportService {

  private readonly baseFinancialReportUrl = environment.baseFinancialReportUrl;
  companyId = sessionStorage.getItem('selectedCompanyId');

  constructor(private http: HttpClient) { }

  getProfitLossReport(startDate: any, endDate: any): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseFinancialReportUrl}/getProfitLossReport?companyId=${this.companyId}`,{ params: { startDate, endDate } });
  }

  getTrialBalanceReport(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseFinancialReportUrl}/getTrialBalanceReport?companyId=${this.companyId}`);
  }

  getJournalEntryReport(startDate: any, endDate: any): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseFinancialReportUrl}/getJournalEntryReport?companyId=${this.companyId}`,{ params: { startDate, endDate } });
  }
}