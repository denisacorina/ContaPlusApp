import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, map, of } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { environment } from 'environments/environment';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly baseAuthUrl = environment.baseAuthUrl;

  constructor(private http: HttpClient) { }

  register(model: any) {
    return this.http.post<any>(`${this.baseAuthUrl}register`, model);
  }

  login(model: any, rememberMe: boolean) {
    return this.http.post<any>(`${this.baseAuthUrl}login`, { ...model, rememberMe });
  }
}
