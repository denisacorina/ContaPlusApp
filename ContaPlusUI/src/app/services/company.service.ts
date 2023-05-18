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
export class CompanyService {

  private readonly baseCompanyUrl = environment.baseCompanyUrl;
  private readonly baseImageUploadUrl = environment.baseImageUploadUrl;

  companies!: any;
  companyData!: any;

  showCompanyDropdown: boolean = false;

  constructor(private http: HttpClient) { }


  getCompaniesForUser(userId: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseCompanyUrl}/getCompaniesForCurrentUser`,{ params: { userId } });
  }

  getCompanyById(companyId: string): Observable<any[]> {
    return this.http.get<any>(`${this.baseCompanyUrl}/getCompanyById`,{ params: { companyId } });
  }

  getAdminCompanies(userId: string): Observable<any> {
  return this.http.get<any>(`${this.baseCompanyUrl}/adminCompanies/${userId}`);
  }

  addCompanyToUser(model: any, userId: string) {
    return this.http.post<any>(`${this.baseCompanyUrl}/${userId}/addCompany`, model);
  }

  updateCompany(model:any, companyId: string) {
    return this.http.put<any>(`${this.baseCompanyUrl}/updateCompany/${companyId}`, model);
  }

  checkEmailExists(email: any) {
    return this.http.get<boolean>(`${this.baseCompanyUrl}/emailExists`, { params: { email } });
  }

  checkFiscalCodeExists(fiscalCode: any) {
    return this.http.get<boolean>(`${this.baseCompanyUrl}/fiscalCodeExists`, { params: { fiscalCode } });
  }

  checkTradeRegisterExists(tradeRegister: any) {
    return this.http.get<boolean>(`${this.baseCompanyUrl}/tradeRegisterExists`, { params: { tradeRegister } });
  }

  uploadCompanyLogo(companyId: string, file: File) {
    const formData = new FormData();
    formData.append('file', file);
    return this.http.post<any>(`${this.baseImageUploadUrl}/company_logo/${companyId}`, formData);
}

uploadCompanySignature(companyId: string, file: File) {
    const formData = new FormData();
    formData.append('file', file);
    return this.http.post<any>(`${this.baseImageUploadUrl}/company_signature/${companyId}`, formData);
}


}