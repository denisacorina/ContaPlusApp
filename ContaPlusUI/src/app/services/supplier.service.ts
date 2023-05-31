import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, map, of } from 'rxjs';
import { environment } from 'environments/environment';
@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  private readonly baseSupplierUrl = environment.baseSupplierUrl;


  constructor(private http: HttpClient) { }


  getSuppliers(companyId: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseSupplierUrl}/getAllSuppliersForCompany`,{ params: { companyId } });
  }

  addSupplierForCompany(supplier: any, companyId: string): Observable<any> {
    const url = `${this.baseSupplierUrl}/addSupplierForCompany?companyId=${companyId}`;
    return this.http.post<any>(url, supplier);
  }

  updateSupplierForCompany(client: any, companyId: string): Observable<any> {
    const url = `${this.baseSupplierUrl}/updateSupplierForCompany?companyId=${companyId}`;
    return this.http.put<any>(url, client);
  }

  
}