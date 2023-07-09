import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CompanyService } from 'src/app/services/company.service';
import { UserService } from 'src/app/services/user.service';
import { AuthGuard } from 'src/app/shared/guards/auth.guard';
import { Chart, Colors, registerables } from 'chart.js';
import * as ApexCharts from 'apexcharts';
import { ClientService } from 'src/app/services/client.service';
import { TransactionService } from 'src/app/services/transaction.service';
import { SupplierService } from 'src/app/services/supplier.service';
import { MatTableDataSource } from '@angular/material/table';
import { find } from 'rxjs';

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

  expenseTransactionType!: string;
  incomeTransactionType!: string


  totalClients: number = 0;
  clients: [] = [];
  client!: any;
  suppliers: [] = [];
  supplier!: any;

  totalIncome: number = 0;

  selectedFilter: string = 'today';
  totalSuppliers: any;
  totalExpense!: number;
  isFirstLoad = true;
  overDueTransactions!: any[];
 
  overDueIncomeTransactions!: any[];
  salesTransactions: any;

 
  constructor(private companyService: CompanyService,
    private clientService: ClientService,
    private supplierService: SupplierService,
    private transactionService: TransactionService,
    private userService: UserService) { }

  ngOnInit() {
    this.chart();
    this.barChart();
    this.getCompaniesForUser();
    this.getClients();
    this.getSuppliers();
    this.getIncomeTransactions();
    this.getExpenseTransactions();
    this.getCurrentCompany();
    this.getExpenseTransactionsOverdue();
    this.getIncomeTransactionsOverdue();
    //this.getSalesTransactions();
   
  }

  getSalesTransactions()
  {
    this.transactionService.getAllCompanyTransactions().subscribe((response) => {
      this.salesTransactions = response.filter((transaction: { transactionType: number; }) => transaction.transactionType === 0);
    })
  }
  

  getCurrentCompany()
  {
    const companyId = sessionStorage.getItem('selectedCompanyId')
    if(companyId)
    this.companyService.getCompanyById(companyId).subscribe( (response) =>
    {
        this.company = response;
    })
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
  
    this.transactionService.getAllCompanyTransactions().subscribe(
      (salesTransactions) => {
        const filteredSalesTransactions = salesTransactions.filter((transaction: { transactionType: number; }) => transaction.transactionType === 0);
        const saleTransactionCountByMonth = new Array<number>(12).fill(0);
    
        for (const transaction of filteredSalesTransactions) {
          const transactionDate = new Date(transaction.transactionDate);
          const monthIndex = transactionDate.getMonth();
    
          saleTransactionCountByMonth[monthIndex]++;
        }
    
        this.transactionService.getAllCompanyTransactions().subscribe(
          (purchaseTransactions) => {
            const filteredSalesTransactions = purchaseTransactions.filter((transaction: { transactionType: number; }) => transaction.transactionType === 1);
            const purchaseTransactionCountByMonth = new Array<number>(12).fill(0);
        
            for (const transaction of filteredSalesTransactions) {
              const transactionDate = new Date(transaction.transactionDate);
              const monthIndex = transactionDate.getMonth();
        
              purchaseTransactionCountByMonth[monthIndex]++;
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
                    name: 'Sales',
                    data: saleTransactionCountByMonth,
                  },
                  {
                    name: 'Purchases',
                    data: purchaseTransactionCountByMonth,
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
    const userId = this.userService.getLoggedInUserId();
    if (userId) {
      this.companyService.getCompaniesForUser(userId).subscribe(
        (response) => {
          this.companies = response;
        }
      )
    }
  }

  getClients() {
    const companyId = sessionStorage.getItem('selectedCompanyId');
    if (companyId) {
      this.clientService.getClients(companyId).subscribe(
        (response: any[]) => {
          this.client = response;
          this.totalClients = this.client.length;
          console.log(this.totalClients)
        }
      )
      }
    
  }

  getSuppliers() {
    const companyId = sessionStorage.getItem('selectedCompanyId');
    if (companyId) {
      this.supplierService.getSuppliers(this.companyId).subscribe(
        (response: any[]) => {
          this.supplier = response;
          this.totalSuppliers = this.supplier.length;
          console.log(this.totalSuppliers)
        }
      )  
    }
    
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

  getExpenseTransactionsOverdue() {
    const companyId = sessionStorage.getItem('selectedCompanyId');
    if (companyId) {
      this.transactionService.getExpenseTransactions(companyId).subscribe(
        (response) => {
          this.overDueTransactions = response.filter(transaction => transaction.paymentStatus === 3);
          this.expenseTransactionType = "Expense"
        }
      );
    }
  }

  getIncomeTransactionsOverdue() {
    const companyId = sessionStorage.getItem('selectedCompanyId');
    if (companyId) {
      this.transactionService.getIncomeTransactions(companyId).subscribe(
        (response) => {
          this.overDueIncomeTransactions = response.filter(transaction => transaction.paymentStatus === 3);
          this.incomeTransactionType = "Income"
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

  getPaymentStatus(status: number): string {
    switch (status) {
      case 0:
        return 'unpaid';
      case 1:
        return 'partial';
      case 2:
        return 'paid';
      case 3:
        return 'overdue';
      default:
        return '';
    }
  }
}
