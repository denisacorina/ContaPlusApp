import { Component, OnInit } from '@angular/core';
import { ClientService } from 'src/app/services/client.service';
import { InventoryService } from 'src/app/services/inventory.service';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { TransactionService } from 'src/app/services/transaction.service';
import { DatePipe } from '@angular/common';
import { CompanyService } from 'src/app/services/company.service';
import * as jsPDF from 'jspdf';


@Component({
  selector: 'app-create-income',
  templateUrl: './create-income.component.html',
  styleUrls: ['./create-income.component.css'],
  providers: [DatePipe]
})
export class CreateIncomeComponent implements OnInit {
  selectedIncomeType!: string;
  generalChartOfAccounts!: any;
  clients!: any[];
  transactions!: any[];
  dataSource: MatTableDataSource<any> = new MatTableDataSource<any>();
  displayedColumns: string[] = ['documentDate', 'documentSeries', 'documentNumber', 'transactionAmount', 'remainingAmount', 'dueDate', 'pay'];
  form!: FormGroup;
  selectedTransaction: any;
  isPartialPayment: boolean = false;
  payLater: boolean = false;
  createIncomeTransactionForm: any;
  generalChartOfAccountsForReceivePayment!: any[];
  addClientForm!: FormGroup;
  isAddClientDialogOpen!: boolean;
  companyId = sessionStorage.getItem("selectedCompanyId")
  company: any;

  constructor(
    private inventoryService: InventoryService,
    private clientService: ClientService,
    private transactionService: TransactionService,
    private companyService: CompanyService,
    private datePipe: DatePipe
  ) { }

  ngOnInit(): void {

    
    if (this.companyId) {
      this.companyService.getCompanyById(this.companyId).subscribe((response) => {
        this.company = response;
      });
    }


    this.fetchGeneralChartOfAccountsList();
    this.fetchGeneralChartOfAccountsListForReceivePayment();
    this.getClients();
    this.incomeForm();
    this.addClient();

    this.form.get('isPartialPayment')?.valueChanges.subscribe(value => {
      if (!value) {
        this.form.get('paidAmount')?.setValue(this.form.get('amount')?.value);
      }
    });
  }

  incomeForm() {
    this.form = new FormGroup({
      clientId: new FormControl(null),
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

  onCreateIncomeTransactionSubmit(): void {
    const clientId = this.form.value.clientId !== '' ? this.form.value.clientId : null;
   
    const selectedClientId =  this.form.value.clientId;
    const selectedClient = this.clients.find(client => client.clientId === selectedClientId);
    const clientInfo = {
      clientName: selectedClient ? selectedClient.clientName : '',
      fiscalCode: selectedClient ? selectedClient.fiscalCode : '',
      bankAccount: selectedClient ? selectedClient.bankAccount : ''

    };
    let debitAccount;
    if (clientId) {
      debitAccount = {
        accountCode: '4111'
      };
    } else {
      debitAccount = {
        accountCode: this.form.value.debitAccount
      };
    }

    let transactionAmount = this.form.value.amount;
    const creditAccount = {
      accountCode: this.form.value.creditAccount
    };
    console.log(creditAccount)
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

      if (isDueDateCorrect)
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

      const receiptClientPDFContent = `
        <div id="invoice-container" class="invoice-container" style="width: 500px">
          <h5 style="padding: 10px; background-color: #5757f3; color: white; width: 300px; text-align: center;>Receipt <span style="text-transform: uppercase;">Receipt ${this.form.value.documentSeries} - ${this.form.value.documentNumber}</span></h5>
          <p style="font-size: 10px; ">Transaction Date: ${this.form.value.transactionDate.toLocaleDateString()}</p>
          
          <div class="supplier col" style="font-size: 10px">
          <p>Company information:</p>
          <p style="font-size: 14px!important; margin-top: -20px;"><b> ${this.company.companyName} </b></p>
          <p style="margin-top: -20px;">Fiscal Code ${this.company.fiscalCode} </p>
          <p style="margin-top: -20px;">Trade Register ${this.company.tradeRegister} </p>
          <p style="margin-top: -20px;">Bank Account ${this.company.bankAccount ? this.company.bankAccount : 'No bank account'} </p>
          <p style="margin-top: -20px;">Email ${this.company.email} </p>
          </div>
          <div class="client col" style="font-size: 10px">
          <p>Received from <b>${clientInfo.clientName}</b>, fiscal Code ${clientInfo.fiscalCode}<br> The amount of ${this.form.value.PaidAmount}, representing ${this.form.value.description ? this.form.value.description : ''}</p>
          </div>
          <br>
          <p style="font-size: 10px">Generated by <b>ContaPlus</b></p>
        </div>
      `;

      const receiptPDFContent = `
        <div id="invoice-container" class="invoice-container" style="width: 500px">
          <h5 style="padding: 10px; background-color: #5757f3; color: white; width: 300px; text-align: center;>Receipt <span style="text-transform: uppercase;">Receipt ${this.form.value.documentSeries} - ${this.form.value.documentNumber}</span></h5>
          <p style="font-size: 10px; ">Transaction Date: ${this.form.value.transactionDate.toLocaleDateString()}</p>
          
          <div class="supplier col" style="font-size: 10px">
          <p>Company information:</p>
          <p style="font-size: 14px!important; margin-top: -20px;"><b> ${this.company.companyName} </b></p>
          <p style="margin-top: -20px;">Fiscal Code ${this.company.fiscalCode} </p>
          <p style="margin-top: -20px;">Trade Register ${this.company.tradeRegister} </p>
          <p style="margin-top: -20px;">Bank Account ${this.company.bankAccount ? this.company.bankAccount : 'No bank account'} </p>
          <p style="margin-top: -20px;">Email ${this.company.email} </p>
          </div>
          <div class="client col" style="font-size: 10px">
          <p>Received the amount of ${this.form.value.PaidAmount}, representing ${this.form.value.description ? this.form.value.description : ''}</p>
          </div>
          <br>
          <p style="font-size: 10px">Generated by <b>ContaPlus</b></p>
        </div>
      `;


      if (clientId) {
        this.transactionService.createIncomeTransactionForClient(model, clientId).subscribe(
          () => {
            this.generateClientReceiptPDF(receiptClientPDFContent);
            this.form.reset();
          }
        );
      }
      else {
        this.transactionService.createIncomeTransaction(model).subscribe(
          () => {
            this.generateReceiptPDF(receiptPDFContent);
            this.form.reset();
          }
        );
      }

    }
  }


  generateClientReceiptPDF(receiptClientPDFContent: string) {
    const pdf = new jsPDF.default('p', 'pt', 'a4');


    pdf.html(receiptClientPDFContent, {
      margin: [10, 30, 30, 30],

      callback: (pdf) => {
        pdf.setProperties({
          title: 'Receipt',

        });


        pdf.output('dataurlnewwindow');

        // pdf.save('receipt.pdf');
      },
    });
  }

  generateReceiptPDF(receiptPDFContent: string) {
    const pdf = new jsPDF.default('p', 'pt', 'a4');


    pdf.html(receiptPDFContent, {
      margin: [10, 30, 30, 30],

      callback: (pdf) => {
        pdf.setProperties({
          title: 'Receipt',

        });


        pdf.output('dataurlnewwindow');

        // pdf.save('receipt.pdf');
      },
    });
  }


  fetchGeneralChartOfAccountsList() {
    this.inventoryService.getGeneralChartOfAccountsList().subscribe((response) => {
      this.generalChartOfAccounts = response.filter((account) => account.accountNumber === 7);
    });
  }


  fetchGeneralChartOfAccountsListForReceivePayment() {
    this.inventoryService.getGeneralChartOfAccountsList().subscribe((response) => {
      this.generalChartOfAccountsForReceivePayment = response.filter((account) => account.accountCode === 5121 || account.accountCode === 5311);
    });
  }

  getClients() {
    this.clientService.getClients(this.companyId).subscribe((response) => {
      this.clients = response;
    });
  }

  getClientUnpaidTransactions() {
    const clientId = this.form.value.clientId;

    this.form.get('amount')?.setValue(null);
    this.form.get('description')?.setValue(null);

    this.transactionService.getClientUnpaidTransactions(clientId).subscribe((response: any[]) => {
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
        } else {
          amount.setErrors(null);
        }

        const documentDetails = `Representing the equivalent value of the Invoice ${transaction.documentSeries} ${transaction.documentNumber} from ${this.datePipe.transform(transaction.transactionDate, 'dd/MM/yyyy')}`;
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



  addClient() {
    this.addClientForm = new FormGroup({
      clientName: new FormControl('', Validators.required),
      fiscalCode: new FormControl('', Validators.required),
      address: new FormControl('', Validators.required),
      bankAccount: new FormControl('', Validators.required)
    });
  }

  openAddClientDialog(): void {
    this.isAddClientDialogOpen = true;
  }

  closeAddClientDialog(): void {
    this.isAddClientDialogOpen = false;
  }

  onAddClientSubmit(): void {

    const clientName = this.addClientForm.value.clientName;
    const fiscalCode = this.addClientForm.value.fiscalCode;
    const address = this.addClientForm.value.address;
    const bankAccount = this.addClientForm.value.bankAccount;

    const model = {
      clientName,
      fiscalCode,
      address,
      bankAccount
    };

    if (this.addClientForm.valid)
      this.clientService.addClientForCompany(model, this.companyId).subscribe(
        () => {
          this.isAddClientDialogOpen = false;
          this.getClients();

        }
      );
  }

}



