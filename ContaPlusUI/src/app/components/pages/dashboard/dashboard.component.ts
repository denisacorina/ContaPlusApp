import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CompanyService } from 'src/app/services/company.service';
import { UserService } from 'src/app/services/user.service';
import { AuthGuard } from 'src/app/shared/guards/auth.guard';
import { Chart, Colors, registerables } from 'chart.js';
import * as ApexCharts from 'apexcharts';
import { ClientService } from 'src/app/services/client.service';
import { TransactionService } from 'src/app/services/transaction.service';
import { SupplierService } from 'src/app/services/supplier.service';
import { formatDate } from '@angular/common';
Chart.register(...registerables);

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  providers: [AuthGuard]
})
export class DashboardComponent implements OnInit {
  companyId = sessionStorage.getItem('selectedCompanyId')

  model: any;
  title = 'chartDemo';
  userId: any;
  user: any;
  companies!: any;
  company!: any;
  selectedCompanyId!: string;
  showCompanyDropdown: boolean = false;
  isUpdateCompanyDialogOpen: boolean = false;
  updateCompanyForm!: FormGroup;
  companyNeverUpdated: any;
  selectedCounty: any;
  selectedFile: any;
  imageUrl!: any;
  isEarningDropdownOpen: boolean = false;
  isExpenseDropdownOpen: boolean = false;


  totalClients: number = 0;
  clients: [] = [];
  client!: any;
  suppliers: [] = [];
  supplier!: any;

  totalIncome: number = 0;

  selectedFilter: string = 'today';
  totalSuppliers: any;
  totalExpense!: number;

  constructor(private companyService: CompanyService,
    private clientService: ClientService,
    private supplierService: SupplierService,
    private transactionService: TransactionService) { }

  ngOnInit() {
    this.chart();
    this.barChart();
    this.getCompaniesForUser();
    this.getClients();
    this.getSuppliers();
    this.getIncomeTransactions();
    this.getExpenseTransactions();
    this.getCurrentCompany();


  }

  getCurrentCompany()
  {
    if(this.companyId)
    this.companyService.getCompanyById(this.companyId).subscribe( (response) =>
    {
        this.company = response;
    })
  }

  options = document.getElementsByClassName('option');

  toggleOption(selectedIndex: number) {
    for (var i = 0; i < this.options.length; i++) {
      if (i === selectedIndex) {
        this.options[i].classList.add('selected');
      } else {
        this.options[i].classList.remove('selected');
      }
    }
  
    switch (selectedIndex) {
      case 0: 
        this.selectedFilter = 'month';
       
        break;
      case 1: 
        this.selectedFilter = 'week';
       
        break;
      case 2:
        this.selectedFilter = 'today';
      
        break;
      default:
        break;
    }
  }

  toggleEarningDropdown(): void {
    this.isEarningDropdownOpen = !this.isEarningDropdownOpen;
  }

  closeEarningDropdown(): void {
    this.isEarningDropdownOpen = false;
  }

  toggleExpenseDropdown(): void {
    this.isExpenseDropdownOpen = !this.isExpenseDropdownOpen;
  }

  closeExpenseDropdown(): void {
    this.isExpenseDropdownOpen = false;
  }
  barChart() {
    const months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
  
    if (this.companyId) {
      this.transactionService.getIncomeTransactions(this.companyId).subscribe(
        (incomeTransactions) => {
          const paidAmountByMonth = new Array<number>(12).fill(0);
          for (const transaction of incomeTransactions) {
            const transactionDate = new Date(transaction.transactionDate);
            const monthIndex = transactionDate.getMonth();
            const paidAmount = transaction.paidAmount;
    
            paidAmountByMonth[monthIndex] += paidAmount;
          }
          if (this.companyId) 
          this.transactionService.getExpenseTransactions(this.companyId).subscribe(
            (expenseTransactions) => {
              const expensePaidAmountByMonth = new Array<number>(12).fill(0);
              for (const transaction of expenseTransactions) {
                const transactionDate = new Date(transaction.transactionDate);
                const monthIndex = transactionDate.getMonth();
                const paidAmount = transaction.paidAmount;
    
                expensePaidAmountByMonth[monthIndex] += paidAmount;
              }
    
              var options = {
                chart: {
                  type: 'bar',
                  toolbar: {
                    show: false
                  },
                  animations: {
                    enabled: true
                  },
                  dropShadow: {
                    enabled: true,
                    blur: 1,
                    opacity: 0.6
                  },
                  sparkline: {
                    enabled: false
                  }
                },
                series: [
                  {
                    name: 'Expenses',
                    data: expensePaidAmountByMonth,
                  },
                  {
                    name: 'Incomes',
                    data: paidAmountByMonth,
                  }
                ],
                xaxis: {
                  categories: months
                },
                colors: ['rgba(000, 000, 000, 0.700)', 'rgba(87, 87, 243, 0.600)'],
                dataLabels: {
                  enabled: false
                }
              };

              var chart = new ApexCharts(document.querySelector("#chart"), options);
              chart.render();
            }
          );
        }
      );
    }
  }
  

  chart() {
    const months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
  
    if (this.companyId) {
      this.transactionService.getIncomeTransactions(this.companyId).subscribe(
        (incomeTransactions) => {
          const paidAmountByMonth = new Array<number>(12).fill(0);
          for (const transaction of incomeTransactions) {
            const transactionDate = new Date(transaction.transactionDate);
            const monthIndex = transactionDate.getMonth();
            const paidAmount = transaction.paidAmount;
    
            paidAmountByMonth[monthIndex] += paidAmount;
          }
    if(this.companyId)
          this.transactionService.getExpenseTransactions(this.companyId).subscribe(
            (expenseTransactions) => {
              const expensePaidAmountByMonth = new Array<number>(12).fill(0);
              for (const transaction of expenseTransactions) {
                const transactionDate = new Date(transaction.transactionDate);
                const monthIndex = transactionDate.getMonth();
                const paidAmount = transaction.paidAmount;
    
                expensePaidAmountByMonth[monthIndex] += paidAmount;
              }
    
              var myChart = new Chart("myChart", {
                type: 'line',
                data: {
                  labels: months,
                  datasets: [
                    {
                      label: 'Expenses',
                      data: expensePaidAmountByMonth,
                      backgroundColor: 'rgba(000, 000, 000, 0.730)',
                      borderColor: "#000",
                      borderWidth: 2,
                      fill: true,
                      tension: 0.4
                    },
                    {
                      label: 'Incomes',
                      data: paidAmountByMonth,
                      backgroundColor: 'rgba(87, 87, 243, 0.675)',
                      borderColor: "#5757f3",
                      borderWidth: 2,
                      fill: true,
                      tension: 0.4
                    }
                  ]
                },
                options: {
                  scales: {
                    y: {
                      beginAtZero: true
                    }
                  },
                  plugins: {
                    legend: {
                      position: 'bottom'
                    },
                    tooltip: {
                      intersect: false
                    }
                  },
                  elements: {
                    line: {
                      tension: 0.4
                    }
                  }
                }
              });
            }
          );
        }
      );
    }
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

  getCompaniesForUser() {
    const userId = sessionStorage.getItem('userId');
    if (userId) {
      this.companyService.getCompaniesForUser(userId).subscribe(
        (response) => {
          this.companies = response;
        }
      )
    }
  }

  getClients() {
      this.clientService.getClients().subscribe(
        (response: any[]) => {
          this.client = response;
          this.totalClients = this.client.length;
          console.log(this.totalClients)
        }
      )
    
  }

  getSuppliers() {
      this.supplierService.getSuppliers().subscribe(
        (response: any[]) => {
          this.supplier = response;
          this.totalSuppliers = this.supplier.length;
          console.log(this.totalSuppliers)
        }
      )  
  }

  getIncomeTransactions() {
    const companyId = sessionStorage.getItem('selectedCompanyId');
    if (companyId) {
      this.transactionService.getIncomeTransactions(companyId).subscribe(
        (transactions: any) => {
          this.totalIncome = this.calculatePaidAmountSum(transactions);
        }
      );
    }
  }

 

  getExpenseTransactions() {
    const companyId = sessionStorage.getItem('selectedCompanyId');
    if (companyId) {
      this.transactionService.getExpenseTransactions(companyId).subscribe(
        (transactions: any) => {
          this.totalExpense = this.calculatePaidAmountSum(transactions);
        }
      );
    }
  }

  calculatePaidAmountSum(transactions: any[]): number {
    let sum = 0;
    for (const transaction of transactions) {
      sum += transaction.paidAmount;
    }
    return sum;
  }


  // onUpdateCompanySubmit(): void {
  //   if (this.updateCompanyForm.invalid) {
  //     return;
  //   }
  //   const companyId = this.companyNeverUpdated.companyId;
  //   this.companyService.updateCompany(this.updateCompanyForm.value, companyId).subscribe(
  //     () => location.reload(),
  //     error => console.error(error)
  //   );

  //   this.isUpdateCompanyDialogOpen = false;
  //   alert("company updated")
  // }

  // showUpdateCompanyModal() {
  //   const userId = this.getLoggedInUserId();
  //   if (!userId) {
  //     return;
  //   }
  //   this.companyService.getCompaniesForUser(userId).subscribe(companies => {
  //     this.companyNeverUpdated = companies.find(c => c.UpdatedAt === null);

  //     if (this.companyNeverUpdated) {
  //       this.isUpdateCompanyDialogOpen = true;
  //       this.updateCompany();
  //     }
  //   });
  // }


  // async getLoggedInUser() {
  //   const userId = this.getLoggedInUserId();
  //   if (userId) {
  //     try {
  //       const response = await this.userService.getUserInfo(userId).toPromise();
  //       this.user = response;
  //     } catch (error) {
  //       console.error('Failed to retrieve user information:', error);
  //     }
  //   }
  // }

  // fetchListOfCompaniesForUser() {
  //   const userId = this.getLoggedInUserId();

  //   if (userId) {
  //     this.companyService.getCompaniesForUser(userId).subscribe(companies => {
  //       this.companies = companies;

  //       if (this.companies) {
  //         if (this.companies.length == 1 || !sessionStorage.getItem('selectedCompanyId')) {
  //           this.selectedCompanyId = this.companies[0].companyId;
  //           sessionStorage.setItem('selectedCompanyId', this.selectedCompanyId);
  //           this.selectCompany(this.selectedCompanyId);
  //           this.showCompanyDropdown = false;
  //         }

  //         if (this.companies.length > 1) {
  //           this.showCompanyDropdown = true;
  //           this.selectedCompanyId = sessionStorage.getItem('selectedCompanyId') as string;
  //           this.selectCompany(this.selectedCompanyId);
  //         }

  //       } else {
  //         console.error("No companies");
  //       }
  //     });
  //   }
  // }
  // async selectCompany(companyId: string) {
  //   if (companyId) {
  //     try {
  //       this.companyData = await this.companyService.getCompanyById(companyId).toPromise();
  //       console.log('company data:', this.companyData);
  //     } catch (error) {
  //       console.log('Error fetching company data:', error);
  //     }
  //   }
  //   sessionStorage.setItem('selectedCompanyId', companyId);
  // }

  // getLoggedInUserId(): string | null {
  //   const token = localStorage.getItem('accessToken');
  //   if (token) {
  //     const decodedToken = this.jwtHelper.decodeToken(token);
  //     if (decodedToken && decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name']) {
  //       return decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
  //     }
  //   }
  //   return null;
  // }

  // onFileSelected(event: Event) {
  //   const inputElement = event.target as HTMLInputElement;
  //   if (inputElement.files && inputElement.files.length) {
  //     this.selectedFile = inputElement.files[0];
  //   }
  // }

  // onUpload() {
  //   var userId = this.getLoggedInUserId();
  //   if (userId) {
  //     this.userService.uploadProfilePicture(userId, this.selectedFile).subscribe(
  //       (response: any) => {
  //         console.log('Profile picture uploaded successfully:', response);
  //       }
  //     );
  //   } else {
  //     console.error('User is not logged in');
  //   }
  // }

  // async getUserProfilePicture() {
  //   var userId = this.getLoggedInUserId();
  //   if (userId) {
  //   await this.userService.getProfilePicture(userId).subscribe(
  //     (response: any) => {
  //       const reader = new FileReader();
  //       reader.readAsDataURL(response);
  //       reader.onloadend = () => {
  //         this.imageUrl = reader.result as string;
  //       };
  //     }
  //   );
  // }
  // }

}
