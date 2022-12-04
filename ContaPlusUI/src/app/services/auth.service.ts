import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = "https://localhost:7121/api/User"
  constructor(private http : HttpClient) { }

  register(model:any)
  {
    return this.http.post(`${this.baseUrl}/registration`, model);
  }

  login(model:any){
    return this.http.post(`${this.baseUrl}/login`, model);
  }

  getAll(model:any){
    return this.http.get<any>(`${this.baseUrl}`, model);
  }
}
