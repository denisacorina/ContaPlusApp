import { Component, OnInit, ViewChild } from '@angular/core';
import { TransactionService } from 'src/app/services/transaction.service';
import { DatePipe } from '@angular/common';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

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

  editTransactionForm!: FormGroup;


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
  isEditing!: boolean;
  editingTransactionId!: number;
  transaction: any;
  transactionForm: any;


  constructor(private transactionService: TransactionService, private datePipe: DatePipe) {
    this.transactionForm = new FormGroup({
      documentNumber: new FormControl(),
      documentSeries: new FormControl(),
      transactionAmount: new FormControl(),
      paidAmount: new FormControl()
    });
   }

  ngOnInit() {
    this.getExpenseTransactions();
    this.filterTable();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }


  editTransaction(transactionId: number) {
    this.isEditing = true;
    this.editingTransactionId = transactionId;
    this.getTransaction(transactionId);
  }

  cancelEdit() {
    this.isEditing = false;
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

  getTransaction(transactionId: number) {
    this.transactionService.getTransactionById(transactionId).subscribe((response) => {
      this.transaction = response;

      this.transactionForm.patchValue({
        documentNumber: this.transaction.documentNumber,
        documentSeries: this.transaction.documentSeries,
        transactionAmount: this.transaction.transactionAmount,
        paidAmount: this.transaction.paidAmount
      
      });
    });
  }

  saveTransaction() {
    let transactionId =  this.transaction.transactionId
    console.log(transactionId)
    let transactionAmount = parseFloat(this.transactionForm.value.transactionAmount);
    let paidAmount = parseFloat(this.transactionForm.value.paidAmount);
    let model = {
      DocumentNumber: this.transactionForm.value.documentNumber,
      DocumentSeries: this.transactionForm.value.documentSeries,
      TransactionAmount: transactionAmount,
      PaidAmount: paidAmount,
    }
  
    this.transactionService.updateTransactionById(transactionId, model).subscribe(() => {
      this.isEditing = false;
     window.location.reload()
    });
  
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
