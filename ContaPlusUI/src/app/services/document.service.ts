import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, map, of } from 'rxjs';
import { environment } from 'environments/environment';
import { param } from 'jquery';
@Injectable({
  providedIn: 'root'
})
export class DocumentService {

  private readonly baseDocumentUrl = environment.baseDocumentUrl;
  companyId = sessionStorage.getItem('selectedCompanyId');

  constructor(private http: HttpClient) { }

  getClientUnpaidTransactions(clientId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseDocumentUrl}/getClientUnpaidTransactions?companyId=${this.companyId}`,{ params: { clientId } });
  }
}