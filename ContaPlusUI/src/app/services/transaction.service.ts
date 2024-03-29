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
  userId = sessionStorage.getItem('userId');

  constructor(private http: HttpClient) { }


  getIncomeTransactions(companyId: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseTransactionUrl}/getIncomeTransactions`,{ params: { companyId } });
  }

  createIncomeTransactionForClient(model: any, clientId: any): Observable<any> {
    const url = `${this.baseTransactionUrl}/createIncomeTransaction?companyId=${this.companyId}&clientId=${clientId}&userId=${this.userId}`;
    return this.http.post<any>(url, model);
  }

  createIncomeTransaction(model: any): Observable<any> {
    const url = `${this.baseTransactionUrl}/createIncomeTransaction?companyId=${this.companyId}&userId=${this.userId}`;
    return this.http.post<any>(url, model);
  }

  payExistingTransaction(transactionId: number, amount: number): Observable<any> {
    const url = `${this.baseTransactionUrl}/payExistingTransaction?transactionId=${transactionId}&amount=${amount}`;
    return this.http.put<any>(url, null);
  }

  updateTransactionById(transactionId: number, updatedTransaction: any) {
    const url = `${this.baseTransactionUrl}/updateTransactionById/${transactionId}`;
    console.log(updatedTransaction)
    return this.http.put(url, updatedTransaction);

  }

  getTransactionById(transactionId: number): Observable<any> {
    return this.http.get<any>(`${this.baseTransactionUrl}/getTransactionById`,{ params: { transactionId } });
  }

  getAllCompanyTransactions(): Observable<any> {
    return this.http.get<any>(`${this.baseTransactionUrl}/getAllCompanyTransactions?companyId=${this.companyId}`);
  }

  deleteTransaction(transactionId: number) {
    const url = `${this.baseTransactionUrl}/deleteTransaction?transactionId=${transactionId}&companyId=${this.companyId}`;
    return this.http.delete(url);
  }

  getExpenseTransactions(companyId: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseTransactionUrl}/getExpenseTransactions`,{ params: { companyId } });
  }

  createExpenseTransactionForSupplier(model: any, supplierId: any): Observable<any> {
    const url = `${this.baseTransactionUrl}/createExpenseTransaction?companyId=${this.companyId}&supplierId=${supplierId}&userId=${this.userId}`;
    return this.http.post<any>(url, model);
  }

  createExpenseTransaction(model: any): Observable<any> {
    const url = `${this.baseTransactionUrl}/createExpenseTransaction?companyId=${this.companyId}&userId=${this.userId}`;
    return this.http.post<any>(url, model);
  }

  getClientUnpaidTransactions(clientId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseTransactionUrl}/getClientUnpaidTransactions?companyId=${this.companyId}`,{ params: { clientId } });
  }

  getSupplierUnpaidTransactions(supplierId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseTransactionUrl}/getSupplierUnpaidTransactions?companyId=${this.companyId}`,{ params: { supplierId } });
  }

  createProductSaleTransaction(model: any) {
    const url = `${this.baseTransactionUrl}/createProductSaleTransaction?companyId=${this.companyId}&userId=${this.userId}`;
    return this.http.post<any>(url, model);
  }

  createProductPurchaseTransaction(model: any) {
    const url = `${this.baseTransactionUrl}/createProductPurchaseTransaction?companyId=${this.companyId}&userId=${this.userId}`;
    return this.http.post<any>(url, model);
  }
}
 

