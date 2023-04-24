import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CompanyService } from 'src/app/services/company.service';
import { UserService } from 'src/app/services/user.service';
import { AuthGuard } from 'src/app/shared/guards/auth.guard';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  providers: [AuthGuard]
})
export class DashboardComponent implements OnInit {
  model : any;
  mini = true;
  userId: any;
  user: any;
  companies!: any;
  selectedCompanyId!: string;
  companyData: any;
  showCompanyDropdown: boolean = false;

  showSubmenu = false;
  toggleSubmenu() {
    this.showSubmenu = !this.showSubmenu;
  }


toggleSidebar() {
  if (this.mini) {
    console.log("opening sidebar");
    const sidebar = document.getElementById("mySidebar");
    const main = document.getElementById("main");
    if(sidebar != null && main != null)
    {
      sidebar.style.width = "170px";
      main.style.marginLeft = "170px";
      this.mini = false;
    }
  } else {
    const sidebar = document.getElementById("mySidebar");
    const main = document.getElementById("main");
    console.log("closing sidebar");
    if(sidebar != null && main != null)
    {
      sidebar.style.width = "85px";
      main.style.marginLeft = "85px";
      this.mini = true;
    }

  }

}

  constructor(private companyService : CompanyService, 
              private userService : UserService, 
              private router: Router, 
              private jwtHelper: JwtHelperService) {}

  ngOnInit(): void {
   document.body.classList.remove('no-scroll');
    document.body.classList.add('custom-scrollbar');
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
  


