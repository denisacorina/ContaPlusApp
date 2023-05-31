import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, map } from 'rxjs';
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
  showCancelButton: boolean = false;

  addCompanyForm!: FormGroup;

  isAddCompanyDialogOpen = false;

  emailExists!: any;
  fiscalCodeExists!: Observable<boolean>;
  tradeRegisterExists!:  Observable<boolean>;
  imageUrl: any;


  constructor(private companyService: CompanyService,
    private userService: UserService) { }

    public getUserService(): UserService {
      return this.userService;
    }

  ngOnInit(): void {
    this.userService.getLoggedInUser();
    this.fetchListOfCompaniesForUser();
    this.addCompanyToUser();
    this.userService.getUserProfilePicture();
    this.imageUrl = this.userService.imageUrl;
  }


 showUserData() {
  const userId = this.userService.getLoggedInUserId();
    if (userId) {
      this.userService.getUserInfo(userId).subscribe(
        response => {
          this.user = response;
        },
        error => {
          console.error('Failed to retrieve user information:', error);
        }
      );
    }
 }

  addCompanyToUser() {
    this.addCompanyForm = new FormGroup({
      companyName: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email],[this.checkEmailExists.bind(this)]),
      fiscalCode: new FormControl('', [Validators.pattern(/^RO\d+$/), Validators.required], [this.checkFiscalCodeExists.bind(this)]),
      tradeRegister: new FormControl('', [Validators.pattern('^J\\d{2}/\\d{3}/\\d{4}$'), Validators.required], [this.checkTradeRegisterExists.bind(this)]),
      phoneNumber: new FormControl('', [Validators.pattern(/^07\d{8}$/), Validators.required]),
      address: new FormControl('', Validators.required),
      tvaPayer: new FormControl(false),
      socialCapital: new FormControl('', [Validators.min(200), Validators.required]),
      cashBalance: new FormControl('', Validators.required)
    });
  }

  onAddCompanySubmit(): void {
    if (this.addCompanyForm.invalid) {
      return;
    }

   this.setErrorCheckEmailExists();
   this.setErrorCheckFiscalCodeExists();
   this.setErrorCheckTradeRegisterExists();

    this.userId = this.userService.getLoggedInUserId();
    this.companyService.addCompanyToUser(this.addCompanyForm.value, this.userId).subscribe(
      (response: any) => {
        sessionStorage.setItem('selectedCompanyId', response.companyId);
        location.reload();
      }, 
      error => console.error(error)
    );

    this.isAddCompanyDialogOpen = false;
    alert("company created")
    window.location.reload();
  }

  checkEmailExists(control: AbstractControl): Observable<ValidationErrors | null> {
    const email = control.value;
    return this.companyService.checkEmailExists(email).pipe(
      map((emailExists: any) => {
        if (emailExists) {
          return { emailExists: true };
        } else {
          return null;
        }
      })
    );
  }

  checkFiscalCodeExists(control: AbstractControl): Observable<ValidationErrors | null> {
    const fiscalCode = control.value;
    return this.companyService.checkFiscalCodeExists(fiscalCode).pipe(
      map((fiscalCodeExists: any) => {
        if (fiscalCodeExists) {
          return { fiscalCodeExists: true };
        } else {
          return null;
        }
      })
    );
  }

  checkTradeRegisterExists(control: AbstractControl): Observable<ValidationErrors | null> {
    const tradeRegister = control.value;
    return this.companyService.checkTradeRegisterExists(tradeRegister).pipe(
      map((tradeRegisterExists: any) => {
        if (tradeRegisterExists) {
          return { tradeRegisterExists: true };
        } else {
          return null;
        }
      })
    );
  }
  
  setErrorCheckEmailExists(): void {
    const emailControl = this.addCompanyForm.get('email');
    if (emailControl) {
      this.checkEmailExists(emailControl).subscribe(
        errors => emailControl.setErrors(errors)
      );
    }
  }
  
  setErrorCheckFiscalCodeExists(): void {
    const fiscalCodeControl = this.addCompanyForm.get('fiscalCode');
    if (fiscalCodeControl) {
      this.checkFiscalCodeExists(fiscalCodeControl).subscribe(
        errors => fiscalCodeControl.setErrors(errors)
      );
    }
  }
  
  setErrorCheckTradeRegisterExists(): void {
    const tradeRegisterControl = this.addCompanyForm.get('tradeRegister');
    if (tradeRegisterControl) {
      this.checkTradeRegisterExists(tradeRegisterControl).subscribe(
        errors => tradeRegisterControl.setErrors(errors)
      );
    }
  }
  
  onCancel(): void {
    this.isAddCompanyDialogOpen = false;
  }

  fetchListOfCompaniesForUser() {
    const userId = this.userService.getLoggedInUserId();

    if (userId) {
      this.companyService.getCompaniesForUser(userId).subscribe(companies => {
        this.companies = companies;

        if (!this.companies?.length) {
          this.isAddCompanyDialogOpen = true;
          this.showCancelButton = false;
          return;
        }
    
        if (this.companies.length === 1 || !sessionStorage.getItem('selectedCompanyId')) {
          this.selectedCompanyId = this.companies[0]?.companyId;
          sessionStorage.setItem('selectedCompanyId', this.selectedCompanyId);
          this.showCompanyDropdown = false;
          this.showCancelButton = true;
        } else {
          this.showCompanyDropdown = true;
          this.showCancelButton = true;
          this.selectedCompanyId = sessionStorage.getItem('selectedCompanyId') as string;
        }
    
        this.selectCompany(this.selectedCompanyId);
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




  logout(): void {
    localStorage.removeItem('accessToken');
    sessionStorage.removeItem('selectedCompanyId');
  }
}

