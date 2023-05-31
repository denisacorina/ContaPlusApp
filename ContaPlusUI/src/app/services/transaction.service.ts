import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, map, of } from 'rxjs';
import { environment } from 'environments/environment';
@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  private readonly baseTransactionUrl = environment.baseTransactionUrl;
  companyId = sessionStorage.getItem('selectedCompanyId');

  constructor(private http: HttpClient) { }


  getIncomeTransactions(companyId: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseTransactionUrl}/getIncomeTransactions`,{ params: { companyId } });
  }

  createIncomeTransaction(model: any, companyId: string): Observable<any> {
    const url = `${this.baseTransactionUrl}/createIncomeTransaction?companyId=${this.companyId}`;
    return this.http.post<any>(url, model);
  }

  deleteTransaction(transactionId: number) {
    const url = `${this.baseTransactionUrl}/deleteTransaction?transactionId=${transactionId}&companyId=${this.companyId}`;
    return this.http.delete(url);
  }

  deletePartialPaymentTransaction(transactionId: number) {
    const url = `${this.baseTransactionUrl}/deletePartialPaymentTransaction?transactionId=${transactionId}&companyId=${this.companyId}`;
    return this.http.delete(url);
  }

  getExpenseTransactions(companyId: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseTransactionUrl}/getExpenseTransactions`,{ params: { companyId } });
  }

  createExpenseTransaction(model: any): Observable<any> {
    const url = `${this.baseTransactionUrl}/createExpenseTransaction?companyId=${this.companyId}`;
    return this.http.post<any>(url, model);
  }
}
 

