import { Component, OnInit, ViewChild } from '@angular/core';
import { TransactionService } from 'src/app/services/transaction.service';
import { DatePipe } from '@angular/common';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatSortModule } from '@angular/material/sort';


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
    this.getIncomeTransactions();
    this.createIncomeTransaction();
    this.filterTable();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
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
    const companyId = sessionStorage.getItem('selectedCompanyId');
    if (companyId) {
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

    this.transactionService.createIncomeTransaction(model, companyId).subscribe(
      () => {
        window.location.reload();
      
      }
    );
    }
  }

  getIncomeTransactions() {
    const companyId = sessionStorage.getItem('selectedCompanyId');
    if (companyId) {
      this.transactionService.getIncomeTransactions(companyId).subscribe(
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