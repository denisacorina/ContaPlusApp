import { Component, OnInit } from '@angular/core';
import { TransactionService } from 'src/app/services/transaction.service';
import { DatePipe } from '@angular/common';
import { FormControl, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-income',
  templateUrl: './income.component.html',
  styleUrls: ['./income.component.css'],
  providers: [DatePipe]
})
export class IncomeComponent implements OnInit {

  transactions: any[] = [];
  transactionDateFilter: any;
  dueDateFilter: any;

  createIncomeTransactionForm!: FormGroup;
  isCreateIncomeTransactionDialogOpen: boolean = false;

  constructor(private transactionService: TransactionService, private datePipe: DatePipe) { }

  ngOnInit() {
    this.getIncomeTransactions();
    this.initializeCreateIncomeTransactionForm();
  }

  initializeCreateIncomeTransactionForm() {
    this.createIncomeTransactionForm = new FormGroup({
      transactionAmount: new FormControl('', [Validators.required]),
      debitAccount: new FormControl('', [Validators.required]),
      creditAccount: new FormControl('', [Validators.required]),
      paidAmount: new FormControl('', [Validators.required]),
      documentNumber: new FormControl('', [Validators.required]),
      documentSeries: new FormControl('', [Validators.required]),
      dueDate: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required])
    });
  }
  
  openCreateIncomeTransactionDialog(): void {
    this.isCreateIncomeTransactionDialogOpen = true;
  }

  closeCreateIncomeTransactionDialog(): void {
    this.isCreateIncomeTransactionDialogOpen = false;
  }

  onCreateIncomeTransactionSubmit(): void {
    const transactionAmount = this.createIncomeTransactionForm.value.transactionAmount;
    const debitAccount = {
      accountCode: this.createIncomeTransactionForm.value.debitAccount
    };
    const creditAccount = {
      accountCode: this.createIncomeTransactionForm.value.creditAccount
    };


    const paidAmount = this.createIncomeTransactionForm.value.paidAmount;
    const documentNumber = this.createIncomeTransactionForm.value.documentNumber;
    const documentSeries = this.createIncomeTransactionForm.value.documentSeries;
    const dueDate = new Date(this.createIncomeTransactionForm.value.dueDate);
    const description = this.createIncomeTransactionForm.value.description;
  
  

      const model = {
        transactionAmount,
        debitAccount,
        creditAccount,
        paidAmount,
        documentNumber,
        documentSeries,
        dueDate,
        description
      };
  
      this.transactionService.createIncomeTransaction(model).subscribe(
        () => {
          alert("good");
        },
        (error) => {
          console.log(error);
        }
      );
    
  }
  



  getIncomeTransactions() {
    const companyId = sessionStorage.getItem('selectedCompanyId');
    if (companyId) {
      this.transactionService.getIncomeTransactions(companyId).subscribe(
        (response) => {
          this.transactions = response;
          this.applyFilters();
        }
      );
    }
  }
  
  applyFilters() {
    if (this.transactionDateFilter) {
      this.transactions = this.transactions.filter(
        (transaction) =>
          new Date(transaction.transactionDate).toDateString() ===
          new Date(this.transactionDateFilter).toDateString()
      );
    }
  
    if (this.dueDateFilter) {
      this.transactions = this.transactions.filter(
        (transaction) =>
          new Date(transaction.dueDate).toDateString() ===
          new Date(this.dueDateFilter).toDateString()
      );
    }
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