import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, map, of } from 'rxjs';
import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  private readonly baseClientUrl = environment.baseClientUrl;

  companyId = sessionStorage.getItem('selectedCompanyId')

  constructor(private http: HttpClient) { }


  getClients(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseClientUrl}/getAllClientsForCompany?companyId=${this.companyId}`);
  }

  getClientByName(clientName: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseClientUrl}/getClientByName?clientName=${clientName}`);
  }

  addClientForCompany(client: any): Observable<any> {
    const url = `${this.baseClientUrl}/addClientForCompany?companyId=${this.companyId}`;
    return this.http.post<any>(url, client);
  }

  updateClientForCompany(client: any): Observable<any> {
    const url = `${this.baseClientUrl}/updateClientForCompany?companyId=${this.companyId}`;
    return this.http.put<any>(url, client);
  }

  
}