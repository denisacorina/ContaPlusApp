import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, map, of } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  baseCompanyUrl = "https://localhost:7121/api/Companies";

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService, private router: Router) { }


  getCompaniesForUser(userId: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseCompanyUrl}/getCompaniesForCurrentUser`, { params: { userId } });
  }

  getCompanyById(companyId: string): Observable<any[]> {
    return this.http.get<any>(`${this.baseCompanyUrl}/getCompanyById`, { params: { companyId } });
  }

  addCompanyToUser(model: any, userId: string) {
    return this.http.post<any>(`${this.baseCompanyUrl}/${userId}/addCompany`, model);
  }

  updateCompany(model:any, companyId: string) {
    return this.http.put<any>(`${this.baseCompanyUrl}/updateCompany/${companyId}`, model);
  }





}