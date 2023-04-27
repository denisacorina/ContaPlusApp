import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
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
  model: any;

  userId: any;
  user: any;
  companies!: any;
  selectedCompanyId!: string;
  companyData: any;
  showCompanyDropdown: boolean = false;

  addCompanyForm!: FormGroup;

  isAddCompanyDialogOpen = false;


  constructor(private companyService: CompanyService,
    private userService: UserService,
    private jwtHelper: JwtHelperService) { }

  ngOnInit(): void {
    this.getLoggedInUser();
    this.fetchListOfCompaniesForUser();
    this.addCompanyToUser();

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

  addCompanyToUser() {
    this.addCompanyForm = new FormGroup({
      companyName: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      fiscalCode: new FormControl('', [Validators.pattern('^RO\d+$'), Validators.required]),
      tradeRegister: new FormControl('', [Validators.pattern('^J\\d{2}/\\d{3}/\\d{4}$'), Validators.required]),
      phoneNumber: new FormControl('', [Validators.pattern('^07\d{8}$'), Validators.required]),
      address: new FormControl('', Validators.required),
      tvaPayer: new FormControl(false),
      socialCapital: new FormControl('', [Validators.min(200), Validators.required])
    });

  }

  onAddCompanySubmit(): void {
    if (this.addCompanyForm.invalid) {
      return;
    }
    this.userId = this.getLoggedInUserId();
    this.companyService.addCompanyToUser(this.addCompanyForm.value, this.userId).subscribe(
      () => location.reload(),
      error => console.error(error)
    );

    this.isAddCompanyDialogOpen = false;
    alert("company created")
  }



  onCancel(): void {
    this.isAddCompanyDialogOpen = false;
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

          if (this.companies.length == 0) {
            this.isAddCompanyDialogOpen = true;
            this.selectedCompanyId = this.companies[0].companyId;
            sessionStorage.setItem('selectedCompanyId', this.selectedCompanyId);
            this.selectCompany(this.selectedCompanyId);
          }
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
    localStorage.removeItem('selectedCompanyId');
  }
}

