import { Component, OnInit, ViewChild } from '@angular/core';
import { TransactionService } from 'src/app/services/transaction.service';
import { DatePipe } from '@angular/common';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';


@Component({
  selector: 'app-income',
  templateUrl: './income.component.html',
  styleUrls: ['./income.component.css'],
  providers: [DatePipe]
})
export class IncomeComponent implements OnInit {

  transactions: any[] = [];
  transactionDateFilter!: any;
  dueDateFilter!: any;

  createIncomeTransactionForm!: FormGroup;
  isCreateIncomeTransactionDialogOpen: boolean = false;

  dataSource!: MatTableDataSource<any>;
  displayedColumns: string[] = ['checkbox', 'documentNumber', 'documentSeries', 'transactionAmount', 'paidAmount', 'remainingAmount', 'debitAccountCode', 'creditAccountCode', 'transactionDate', 'dueDate', 'description', 'paymentStatus'];

  @ViewChild(MatSort, { static: true }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  selection: any;

  constructor(private transactionService: TransactionService, private datePipe: DatePipe) { }

  ngOnInit() {
    this.getIncomeTransactions();
    this.createIncomeTransaction();


    this.dataSource = new MatTableDataSource(this.transactions);
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }
  
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }
  
  masterToggle() {
    this.isAllSelected() ?
      this.selection.clear() :
      this.dataSource.data.forEach(row => this.selection.select(row));
  }

 createIncomeTransaction() {
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
          window.location.reload();
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
    
         
        }
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

  deleteTransaction(transactionId: number) {
    const confirmed = confirm('Are you sure you want to delete this transaction?');
    if (confirmed) {
      this.transactionService.deleteTransaction(transactionId).subscribe(
        () => {
          window.location.reload();
        }
      );
    }
  }

  deletePartialPaymentTransaction(transactionId: number) {
    const confirmed = confirm('Are you sure you want to delete this partial payment?');
    if (confirmed) {
      this.transactionService.deletePartialPaymentTransaction(transactionId).subscribe(
        () => {
          window.location.reload();
        }
      );
    }
  }
}