import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable} from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { CompanyService } from './company.service';
import { environment } from 'environments/environment';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  private readonly baseUserUrl = environment.baseUserUrl;
  private readonly baseImageUploadUrl = environment.baseImageUploadUrl;

  selectedFile!: any;
  imageUrl!: any;
  user!: any;
  companies!: any[];
  selectedCompanyId: any;
  showCompanyDropdown: boolean = false;
  companyData: any;
  updatedUser: any;

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService, private router: Router, private companyService: CompanyService) { }

  getUserInfo(userId: string): Observable<any> {
    return this.http.get<any>(`${this.baseUserUrl}/getUserById`, { params: { userId } });
  }

  updateUser(userId: string, updatedUser: any) {
    return this.http.put(`${this.baseUserUrl}/updateUser/${userId}`, updatedUser);
  }

  uploadProfilePicture(userId: string, file: File) {
    const formData = new FormData();
    formData.append('file', file);
    return this.http.post<any>(`${this.baseImageUploadUrl}/user/${userId}`, formData);
  }

  getProfilePicture(userId: string): Observable<any> {
    const fileName = `user_${userId}`;
    return this.http.get(`${this.baseImageUploadUrl}/${fileName}`, { responseType: 'blob' });
  }

  getUserCompanyRole(userId: string, companyId: string): Observable<any> {
    return this.http.get<any>(`${this.baseUserUrl}/getUserCompanyRoles/${userId}/${companyId}`);
  }

  getUsersAndRolesFromCompany(companyId: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUserUrl}/getUsersAndRolesFromCompany?companyId=${companyId}`);
  }

  public getLoggedInUserId(): string | null {
    const token = localStorage.getItem('accessToken');
    if (token) {
      const decodedToken = this.jwtHelper.decodeToken(token);
      if (decodedToken && decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name']) {
        return decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
      }
    }
    return null;
  }

  public async getLoggedInUser() {
    const userId = this.getLoggedInUserId();
    if (userId) {
      this.getUserInfo(userId).subscribe(
        response => {
          this.user = response;
        },
        error => {
          console.error('Failed to retrieve user information:', error);
        }
      );
    }
  }
  


  public onFileSelected(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    if (inputElement.files && inputElement.files.length) {
      this.selectedFile = inputElement.files[0];
    }
  }
  
  async onUpload() {
    var userId = this.getLoggedInUserId();
    if (userId) {
      await this.uploadProfilePicture(userId, this.selectedFile).toPromise();
      console.log('Profile picture uploaded successfully');
    } else {
      console.error('User is not logged in');
    }
  }
  
 public async getUserProfilePicture() {
    var userId = this.getLoggedInUserId();
    if (userId) {
      try {
        const response = await this.getProfilePicture(userId).toPromise();
        const reader = new FileReader();
        reader.readAsDataURL(response);
        reader.onloadend = () => {
          this.imageUrl = reader.result as string;
        };
      } catch (error) {
        console.log('Error fetching profile picture:', error);
      }
    }
  }






}