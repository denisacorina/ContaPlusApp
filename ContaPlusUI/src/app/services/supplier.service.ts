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


  getSuppliers(companyId: any): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseSupplierUrl}/getAllSuppliersForCompany?companyId=${companyId}`);
  }

  getSupplierByName(supplierName: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseSupplierUrl}/getSupplierByName?supplierName=${supplierName}`);
  }

  addSupplierForCompany(supplier: any, companyId: any): Observable<any> {
    const url = `${this.baseSupplierUrl}/addSupplierForCompany`;
    return this.http.post<any>(url, supplier, companyId);
  }

  updateSupplierForCompany(supplier: any, companyId: any): Observable<any> {
    const url = `${this.baseSupplierUrl}/updateSupplierForCompany`;
    return this.http.put<any>(url, supplier, companyId);
  }

  
}