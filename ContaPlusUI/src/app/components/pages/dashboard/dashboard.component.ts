import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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
  model: any;

  userId: any;
  user: any;
  companies!: any;
  selectedCompanyId!: string;
  companyData: any;
  showCompanyDropdown: boolean = false;
  isUpdateCompanyDialogOpen: boolean = false;
  updateCompanyForm!: FormGroup;
  companyNeverUpdated: any;
  selectedCounty: any;
  counties!: any[];

  constructor(private companyService: CompanyService,
    private userService: UserService,
    private router: Router,
    private jwtHelper: JwtHelperService) { }

  ngOnInit(): void {
    document.body.classList.remove('no-scroll');
    document.body.classList.add('custom-scrollbar');
    this.getLoggedInUser();
    this.fetchListOfCompaniesForUser();
    this.showUpdateCompanyModal();
  }

  updateCompany() {
    this.updateCompanyForm = new FormGroup({
      companyName: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      fiscalCode: new FormControl(''),
      tradeRegister: new FormControl('', Validators.pattern('^J\\d{2}/\\d{3}/\\d{4}$')),
      phoneNumber: new FormControl(''),      
      address: new FormControl(''),
      socialCapital: new FormControl('', Validators.min(200)),
      tvaPayer: new FormControl(false)
    });
  }

  onUpdateCompanySubmit(): void {
    if (this.updateCompanyForm.invalid) {
      return;
    }
    const companyId = this.companyNeverUpdated.companyId;
    this.companyService.updateCompany(this.updateCompanyForm.value, companyId).subscribe(
      () => location.reload(),
      error => console.error(error)
    );

    this.isUpdateCompanyDialogOpen = false;
    alert("company updated")
  }

  showUpdateCompanyModal() {
    const userId = this.getLoggedInUserId();
    if (!userId) {
      return;
    }
    this.companyService.getCompaniesForUser(userId).subscribe(companies => {
      this.companyNeverUpdated = companies.find(c => c.UpdatedAt === null);

      if (this.companyNeverUpdated) {
        this.isUpdateCompanyDialogOpen = true;
        this.updateCompany();
      }
    });
  }


  getLoggedInUser() {
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
          if (this.companies.length == 1 || !sessionStorage.getItem('selectedCompanyId')) {
            this.selectedCompanyId = this.companies[0].companyId;
            sessionStorage.setItem('selectedCompanyId', this.selectedCompanyId);
            this.selectCompany(this.selectedCompanyId);
            this.showCompanyDropdown = false;
          }

          if (this.companies.length > 1) {
            this.showCompanyDropdown = true;
            this.selectedCompanyId = sessionStorage.getItem('selectedCompanyId') as string;
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
    sessionStorage.setItem('selectedCompanyId', companyId);
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
    sessionStorage.removeItem('selectedCompanyId');
  }
}



