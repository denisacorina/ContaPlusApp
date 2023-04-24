import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, map, of } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private isAuthenticated: boolean = false;

  baseUrl = "https://localhost:7121/api/Auth/";
 


  constructor(private http : HttpClient, private jwtHelper: JwtHelperService, private router: Router) { }

  register(model:any)
  {
    return this.http.post(`${this.baseUrl}register`, model);
  }

  login(model: any, rememberMe: boolean) {
    return this.http.post<any>(`${this.baseUrl}login`, { ...model, rememberMe })
      .pipe(
        map(response => {
          const userId = response.userId;
          localStorage.setItem('userId', userId);

          return response;
        })
      );
  }



  isUserAuthenticated = (): any => {
    const token = localStorage.getItem("token");
    return token && !this.jwtHelper.isTokenExpired(token);
  }


}
