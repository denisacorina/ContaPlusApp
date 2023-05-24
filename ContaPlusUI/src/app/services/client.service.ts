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


  getClients(companyId: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseClientUrl}/getAllClientsForCompany`,{ params: { companyId } });
  }

  
}