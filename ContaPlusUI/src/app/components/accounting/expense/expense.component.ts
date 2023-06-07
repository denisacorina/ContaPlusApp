import { Component, OnInit, ViewChild } from '@angular/core';
import { TransactionService } from 'src/app/services/transaction.service';
import { DatePipe } from '@angular/common';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatSortModule } from '@angular/material/sort';


@Component({
  selector: 'app-expense',
  templateUrl: './expense.component.html',
  styleUrls: ['./expense.component.css'],
  providers: [DatePipe]
})
export class ExpenseComponent implements OnInit{
 
  
  transactions: any[] = [];
  transactionDateFilter!: any;
  dueDateFilter!: any;

  createExpenseTransactionForm!: FormGroup;
  isCreateExpenseTransactionDialogOpen: boolean = false;

  dataSource!: MatTableDataSource<any>;
  displayedColumns: string[] = ['documentNumber', 'documentSeries', 'transactionAmount', 'paidAmount', 'remainingAmount', 'transactionDate', 'dueDate', 'paymentStatus', 'actions'];

  @ViewChild(MatSort, { static: true }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  selection: any;
  documentNumberFilter: any;
  documentSeriesFilter: any;
  transactionAmount: any;
  startDate!: Date;
  endDate!: Date;


  constructor(private transactionService: TransactionService, private datePipe: DatePipe) { }

  ngOnInit() {
    this.getExpenseTransactions();
    this.createExpenseTransaction();
    this.filterTable();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  createExpenseTransaction() {
    this.createExpenseTransactionForm = new FormGroup({
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

  openCreateExpenseTransactionDialog(): void {
    this.isCreateExpenseTransactionDialogOpen = true;
  }

  closeCreateExpenseTransactionDialog(): void {
    this.isCreateExpenseTransactionDialogOpen = false;
  }

  onCreateExpenseTransactionSubmit(): void {
    const companyId = sessionStorage.getItem('selectedCompanyId');
    if (companyId) {
    const transactionAmount = this.createExpenseTransactionForm.value.transactionAmount;
    const debitAccount = {
      accountCode: this.createExpenseTransactionForm.value.debitAccount
    };
    const creditAccount = {
      accountCode: this.createExpenseTransactionForm.value.creditAccount
    };
    const paidAmount = this.createExpenseTransactionForm.value.paidAmount;
    const documentNumber = this.createExpenseTransactionForm.value.documentNumber;
    const documentSeries = this.createExpenseTransactionForm.value.documentSeries;
    const dueDate = new Date(this.createExpenseTransactionForm.value.dueDate);
    const description = this.createExpenseTransactionForm.value.description;

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

    this.transactionService.createExpenseTransaction(model).subscribe(
      () => {
        window.location.reload();
      
      }
    );
    }
  }

  getExpenseTransactions() {
    const companyId = sessionStorage.getItem('selectedCompanyId');
    if (companyId) {
      this.transactionService.getExpenseTransactions(companyId).subscribe(
        (response) => {
          this.transactions = response;
          this.dataSource = new MatTableDataSource(this.transactions);
          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;

          
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

  onSortData(event: any) {
    const direction = event.direction;
    const active = event.active;

    if (direction === '') {
      this.dataSource.data = this.transactions;
    } else {
      this.dataSource.sortingDataAccessor = (item, property) => {
        switch (property) {
          case 'transactionDate':
            return new Date(item.transactionDate);
          default:
            return item[property];
        }
      };
      this.dataSource.sort = this.sort;
      this.dataSource.sort.active = active || '';
      this.dataSource.sort.direction = direction || '';
     
    }
  }


  filterTable() {
    this.dataSource.filterPredicate = (data: any, filter: string): boolean => {
      return (
        data.name.toLocaleLowerCase().includes(filter)
      )
    }
  }

  applyFilter(event: Event): void {
    const filter = (event.target as HTMLInputElement).value.trim().toLocaleLowerCase();
    this.dataSource.filter = filter;
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  onPaginateChange(event: any) {
    const pageSize = event.pageSize;
    const pageIndex = event.pageIndex;
  
    const startIndex = pageIndex * pageSize;
    const endIndex = startIndex + pageSize;
    this.dataSource.data = this.transactions.slice(startIndex, endIndex); 
  }



}
