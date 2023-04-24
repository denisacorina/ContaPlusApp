import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, map, of } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class UserService {
    baseUserUrl = "https://localhost:7121/api/Users";

    constructor(private http : HttpClient, private jwtHelper: JwtHelperService, private router: Router) { }

    getUserInfo(userId: string): Observable<any> {
        return this.http.get<any>(`${this.baseUserUrl}/getUserById`, { params: { userId } });
      }
      
      
      updateUser(model:any, userId: string) {
        return this.http.put<any>(`${this.baseUserUrl}/updateUser/${userId}`, model);
      }
      
      
}