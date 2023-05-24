import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, map, of } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { UserService } from './user.service';
import { environment } from 'environments/environment';
@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  private readonly baseTransactionUrl = environment.baseTransactionUrl;


  constructor(private http: HttpClient) { }


  getIncomeTransactions(companyId: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseTransactionUrl}/getIncomeTransactions`,{ params: { companyId } });
  }

  createIncomeTransaction(model: any): Observable<any> {
    const companyId = sessionStorage.getItem('selectedCompanyId');
    const url = `${this.baseTransactionUrl}/createIncomeTransaction?companyId=${companyId}`;
    return this.http.post<any>(url, model);
  }
}
 

