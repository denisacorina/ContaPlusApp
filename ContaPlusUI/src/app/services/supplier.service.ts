import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, map, of } from 'rxjs';
import { environment } from 'environments/environment';
@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  private readonly baseSupplierUrl = environment.baseSupplierUrl;

  companyId = sessionStorage.getItem('selectedCompanyId')

  constructor(private http: HttpClient) { }


  getSuppliers(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseSupplierUrl}/getAllSuppliersForCompany?companyId=${this.companyId}`);
  }

  getSupplierByName(supplierName: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseSupplierUrl}/getSupplierByName?supplierName=${supplierName}`);
  }

  addSupplierForCompany(supplier: any): Observable<any> {
    const url = `${this.baseSupplierUrl}/addSupplierForCompany?companyId=${this.companyId}`;
    return this.http.post<any>(url, supplier);
  }

  updateSupplierForCompany(client: any): Observable<any> {
    const url = `${this.baseSupplierUrl}/updateSupplierForCompany?companyId=${this.companyId}`;
    return this.http.put<any>(url, client);
  }

  
}