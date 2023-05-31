import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, map, of } from 'rxjs';
import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class InventoryService {

  private readonly baseInventoryUrl = environment.baseInventoryUrl;

  companyId = sessionStorage.getItem('selectedCompanyId')

  constructor(private http: HttpClient) { }

  getProductsByCompanyId(): Observable<any[]> {
    const url = `${this.baseInventoryUrl}/getProductsByCompany?companyId=${this.companyId}`;
    return this.http.get<any[]>(url);
  }

  getProductByIdForCompany(productId: number): Observable<any> {
    const url = `${this.baseInventoryUrl}/getProductByIdForCompany?productId=${productId}&companyId=${this.companyId}`;
    return this.http.get<any>(url);
  }

  addProductForCompany(product: any): Observable<any> {
    const url = `${this.baseInventoryUrl}/addProductForCompany?companyId=${this.companyId}`;
    return this.http.post<any>(url, product);
  }

  updateProductForCompany(product: any): Observable<any> {
    const url = `${this.baseInventoryUrl}/updateProductForCompany?companyId=${this.companyId}`;
    return this.http.put<any>(url, product);
  }

  deleteProductForCompany(productId: number): Observable<any> {
    const url = `${this.baseInventoryUrl}/deleteProductForCompany?productId=${productId}&companyId=${this.companyId}`;
    return this.http.delete<any>(url);
  }

  
}