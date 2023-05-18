import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, map, of } from 'rxjs';
import { environment } from 'environments/environment';
@Injectable({
  providedIn: 'root'
})
export class RoleService {

  private readonly baseRoleUrl = environment.baseRoleUrl;

  constructor(private http: HttpClient) { }


  getRoles(){
    return this.http.get<any[]>(`${this.baseRoleUrl}/getRoles`);
  }
}