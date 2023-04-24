import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CompanyService } from 'src/app/services/company.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-top-nav-bar',
  templateUrl: './top-nav-bar.component.html',
  styleUrls: ['./top-nav-bar.component.css']
})
export class TopNavBarComponent implements OnInit {
 model : any;

  userId: any;
  user: any;
  companies!: any;
  selectedCompanyId!: string;
  companyData: any;
  showCompanyDropdown: boolean = false;

  
  constructor(private companyService : CompanyService, 
              private userService : UserService, 
              private router: Router, 
              private jwtHelper: JwtHelperService) {}

  ngOnInit(): void {
   this.getLoggedInUser();
   this.fetchListOfCompaniesForUser();
 
  }
   getLoggedInUser()
  {
    const userId = this.getLoggedInUserId();
    if (userId) {
      this.userService.getUserInfo(userId).subscribe(
        (response: any) => {
          this.user = response;
        },
        (error: any) => {
          console.error('Failed to retrieve user information:', error);
        }
      );
    }
  }

   fetchListOfCompaniesForUser() {
    const userId = this.getLoggedInUserId();
  
    if (userId) {
      this.companyService.getCompaniesForUser(userId).subscribe(companies => {
        this.companies = companies;
        
        if (this.companies) {
          if (this.companies.length == 1 || !localStorage.getItem('selectedCompanyId')) {
            this.selectedCompanyId = this.companies[0].companyId;
            localStorage.setItem('selectedCompanyId', this.selectedCompanyId);
            this.selectCompany(this.selectedCompanyId);
            this.showCompanyDropdown = false;
          } 
          
          if (this.companies.length > 1) {
            this.showCompanyDropdown = true;
            this.selectedCompanyId = localStorage.getItem('selectedCompanyId') as string;
            this.selectCompany(this.selectedCompanyId);
          }
          
        } else {
          console.error("No companies");
        }
      });
    }
  }


  selectCompany(companyId: string) {
    console.log('selected companyId:', companyId);
    if (companyId) {
      this.companyService.getCompanyById(companyId).subscribe(data => {
        this.companyData = data;
        console.log('company data:', this.companyData);
      });
    }
    localStorage.setItem('selectedCompanyId', companyId);
  }

  getLoggedInUserId(): string | null {
    const token = localStorage.getItem('accessToken');
    if (token) {
      const decodedToken = this.jwtHelper.decodeToken(token);
      if (decodedToken && decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name']) {
        return decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
      }
    }
    return null;
  }


  logout(): void {
    localStorage.removeItem('accessToken');
    localStorage.removeItem('userId');
    localStorage.removeItem('selectedCompanyId');
  }
}

