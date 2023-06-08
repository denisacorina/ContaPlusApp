import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, map, of } from 'rxjs';
import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  private readonly baseClientUrl = environment.baseClientUrl;



  constructor(private http: HttpClient) { }


  getClients(companyId: any): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseClientUrl}/getAllClientsForCompany`, { params: { companyId } });
    
  }

  getClientByName(clientName: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseClientUrl}/getClientByName?clientName=${clientName}`);
  }

  addClientForCompany(client: any, companyId: any): Observable<any> {
    const url = `${this.baseClientUrl}/addClientForCompany`;
    return this.http.post<any>(url, client, companyId);
  }

  updateClientForCompany(client: any, companyId: any): Observable<any> {
    const url = `${this.baseClientUrl}/updateClientForCompany`;
    return this.http.put<any>(url, client), companyId;
  }

  
}