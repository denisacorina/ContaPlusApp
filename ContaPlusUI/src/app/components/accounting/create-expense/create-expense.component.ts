import { Component, OnInit } from '@angular/core';
import { InventoryService } from 'src/app/services/inventory.service';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { TransactionService } from 'src/app/services/transaction.service';
import { DatePipe } from '@angular/common';
import { SupplierService } from 'src/app/services/supplier.service';

@Component({
  selector: 'app-create-expense',
  templateUrl: './create-expense.component.html',
  styleUrls: ['./create-expense.component.css'],
  providers: [DatePipe]
})

export class CreateExpenseComponent implements OnInit {
  selectedIncomeType!: string;
  generalChartOfAccounts!: any;
  suppliers!: any[];
  transactions!: any[];
  dataSource: MatTableDataSource<any> = new MatTableDataSource<any>();
  displayedColumns: string[] = ['documentSeries', 'documentNumber', 'transactionAmount', 'remainingAmount', 'dueDate', 'pay'];
  form!: FormGroup;
  selectedTransaction: any;
  isPartialPayment: boolean = false;
  payLater: boolean = false;
  createExpenseTransactionForm: any;
  generalChartOfAccountsForMakePayment!: any[];
  companyId = sessionStorage.getItem("selectedCompanyId")

  constructor(
    private inventoryService: InventoryService,
    private supplierService: SupplierService,
    private transactionService: TransactionService,
    private datePipe: DatePipe
  ) { }

  ngOnInit(): void {
    this.fetchGeneralChartOfAccountsList();
    this.fetchGeneralChartOfAccountsListForMakePayment();
    this.getSuppliers();
    this.expenseForm();

    this.form.get('isPartialPayment')?.valueChanges.subscribe(value => {
      if (!value) {
        this.form.get('paidAmount')?.setValue(this.form.get('amount')?.value);
      }
    });
  }

  expenseForm() {
    this.form = new FormGroup({
      supplierId: new FormControl(null),
      transactionAmount: new FormControl('', Validators.required),
      amount: new FormControl('', Validators.required),
      isPartialPayment: new FormControl(false),
      payLater: new FormControl(false),
      paidAmount: new FormControl(0),
      remainingAmount: new FormControl('', Validators.required),
      transactionDate: new FormControl('', Validators.required),
      dueDate: new FormControl('', Validators.required),
      description: new FormControl(''),
      documentNumber: new FormControl('', Validators.required),
      documentSeries: new FormControl('', Validators.required),
      debitAccount: new FormControl('', Validators.required),
      creditAccount: new FormControl('', Validators.required)
    });
  }

  onCreateExpenseTransactionSubmit(): void {
    const supplierId = this.form.value.supplierId !== '' ? this.form.value.supplierId : null;

    let creditAccount;
    if (supplierId) {
      creditAccount = {
        accountCode: '401'
      };
    } else {
      creditAccount = {
        accountCode: this.form.value.creditAccount
      };
    }

    let transactionAmount = this.form.value.amount;
    console.log(this.form.value.amount)
    console.log(transactionAmount)
    const debitAccount = {
      accountCode: this.form.value.debitAccount
    };
    let paidAmount = this.form.value.paidAmount;

    const documentNumber = this.form.value.documentNumber;
    const documentSeries = this.form.value.documentSeries;
    const transactionDate = new Date(this.form.value.transactionDate);
    const dueDate = new Date(this.form.value.dueDate);
    const description = this.form.value.description !== '' ? this.form.value.description : null;

    
    let isDueDateCorrect = false;

    if (dueDate < transactionDate) {
      alert('Due date cannot be before the Transaction Date');
      isDueDateCorrect = false;
      return;
    } else isDueDateCorrect = true;

    if (this.selectedTransaction && this.selectedTransaction.payCheckbox) {
      const transactionId = this.selectedTransaction.transactionId;
      paidAmount = this.form.value.amount;
      if (this.isPartialPayment)
        paidAmount = this.form.value.paidAmount;

      this.transactionService.payExistingTransaction(transactionId, paidAmount).subscribe(
        () => {
          window.location.reload();
        }
      );
    } else {
      const model = {
        transactionAmount,
        debitAccount,
        creditAccount,
        paidAmount: this.isPartialPayment ? paidAmount : (this.form.value.payLater ? 0 : transactionAmount),
        documentNumber,
        documentSeries,
        transactionDate,
        dueDate,
        description,
      };

      if (!this.isPartialPayment) {
        paidAmount = this.form.value.transactionAmount;
      }
      if (this.payLater) {
        paidAmount = 0;
      }
      if (supplierId) {
        if(isDueDateCorrect)
        this.transactionService.createExpenseTransactionForSupplier(model, supplierId).subscribe(
          () => {
            window.location.reload();
          }
        );
      }
      else {
        if(isDueDateCorrect)
        this.transactionService.createExpenseTransaction(model).subscribe(
          () => {
            window.location.reload();
          }
        );
      }

    }
  }



  fetchGeneralChartOfAccountsList() {
    this.inventoryService.getGeneralChartOfAccountsList().subscribe((response) => {
      this.generalChartOfAccounts = response.filter((account) => account.accountNumber === 6);
    });
  }

  fetchGeneralChartOfAccountsListForMakePayment() {
    this.inventoryService.getGeneralChartOfAccountsList().subscribe((response) => {
      this.generalChartOfAccountsForMakePayment = response.filter((account) => account.accountCode === 5121 || account.accountCode === 5311);
    });
  }

  getSuppliers() {
    this.supplierService.getSuppliers(this.companyId).subscribe((response) => {
      this.suppliers = response;
    });
  }

  getSupplierUnpaidTransactions() {
    const supplierId = this.form.value.supplierId;

    this.form.get('amount')?.setValue(null);
    this.form.get('description')?.setValue(null);

    this.transactionService.getSupplierUnpaidTransactions(supplierId).subscribe((response: any[]) => {
      this.transactions = response;
      this.dataSource.data = this.transactions;
    });
  }
  updatePaidAmount(transaction: any) {
    const amount = this.form.get('amount');
    const description = this.form.get('description');

    if (amount && description) {
      if (this.selectedTransaction === transaction) {
        this.selectedTransaction = null;
        transaction.payCheckbox = false;
        amount.setValue(null);
        description.setValue('');
      } else {
        if (this.selectedTransaction) {
          this.selectedTransaction.payCheckbox = false;
          const paidAmountControl = this.form.get('amount');
          if (paidAmountControl) {
            paidAmountControl.setValue(null);
          }
        }
        this.selectedTransaction = transaction;
        transaction.payCheckbox = true;
        amount.enable();
        amount.setValue(transaction.remainingAmount);

        if (amount.value <= 0 || amount.value > transaction.remainingAmount) {
          amount.setErrors({ invalidAmount: true });
        }

        const documentDetails = `Representing the payment of the Transaction ${transaction.documentSeries} ${transaction.documentNumber} from ${this.datePipe.transform(transaction.transactionDate, 'dd/MM/yyyy')}`;
        description.setValue(documentDetails);

      }
    }
  }

  onPartialPaymentChange() {
    this.payLater = false;
  }

  onPayLaterChange() {
    this.isPartialPayment = false;
  }

}



