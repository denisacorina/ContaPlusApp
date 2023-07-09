import { Component, ElementRef, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { ClientService } from 'src/app/services/client.service';
import { InventoryService } from 'src/app/services/inventory.service';
import { MatTableDataSource } from '@angular/material/table';
import { CompanyService } from 'src/app/services/company.service';
import { TransactionService } from 'src/app/services/transaction.service';
import { SupplierService } from 'src/app/services/supplier.service';
import * as jsPDF from 'jspdf';
import html2canvas from 'html2canvas';
import * as pdfMake from 'pdfmake/build/pdfmake';
import * as pdfFonts from 'pdfmake/build/vfs_fonts'
import { Router } from '@angular/router';

import 'jspdf-autotable';


(pdfMake as any).vfs = pdfFonts.pdfMake.vfs;

@Component({
  selector: 'app-create-purchase',
  templateUrl: './create-purchase.component.html',
  styleUrls: ['./create-purchase.component.css']
})
export class CreatePurchaseComponent {

  companyId = sessionStorage.getItem("selectedCompanyId")
  salesForm!: FormGroup;
  products: any[] = [];
  suppliers: any[] = [];
  productList: any[] = [];
  invoiceForm: any;
  form!: FormGroup;
  dataSource: MatTableDataSource<any> = new MatTableDataSource<any>();
  displayedColumns: string[] = ['nr', 'good/service', 'quantity', 'boughtPrice', 'price', 'totalWithoutTva', 'tva', 'totalWithTva'];
  productForm!: FormGroup;
  addedProducts: any[] = [];
  isAddedProduct: any;
  company!: any;
  isTvaPayer: any;
  tva!: any;
  totalWithoutTva!: any;
  selectedProduct: any;
  totalWithTva!: any;

  totalAmountWithoutTva!: any;
  totalAmountWithTva!: any;
  totalAmountTva!: any;
  productFormArray: any;
  selectedProductId: any;
  description: any;

  accountCodes!: any[];
  selectedAccountCode: any;
  selectedAccount: any;
  product: any;
  payLater: boolean = false;
  isPartialPayment: boolean = false;

  constructor(
    private inventoryService: InventoryService,
    private supplierService: SupplierService,
    private companyService: CompanyService,
    private transactionService: TransactionService
  ) {}

  ngOnInit() {
    if(this.companyId)
    this.companyService.getCompanyById(this.companyId). subscribe(response => {
      this.company = response;
    })

    this.supplierService.getSuppliers(this.companyId).subscribe(
      (suppliers) => {
        this.suppliers = suppliers;
      }
    );

      this.inventoryService.getGeneralChartOfAccountsList().subscribe(
        (response) => {
           this.accountCodes = response.filter((account) => account.accountNumber === 3 && account.product_Service === 'Bun');
        });

    this.saleForm();
    console.log(this.saleForm())
  
  }

  addProduct() {
    this.selectedAccount = this.form.get('selectedAccount')?.value;
    
    console.log("addproduct",this.selectedAccount)

    const companyId = sessionStorage.getItem('selectedCompanyId');
    const productName = this.form.get('productName')?.value;
    this.description = this.form.get('description')?.value;
    
      const quantity = this.form.get('quantity')?.value;
      const price = this.form.get('boughtPrice')?.value;
      this.totalWithoutTva = (price * quantity);
  
      if (companyId) {
        this.companyService.getCompanyById(companyId).subscribe((response) => {
          this.isTvaPayer = response.tvaPayer;
          this.calculateTva();
        });
      }
    
  }
  
  calculateTva() {
    this.tva = this.isTvaPayer ? (this.totalWithoutTva * 0.19) : 0;

    const totalWithTva = this.totalWithoutTva + this.tva;
    const quantity = parseInt(this.form.get('quantity')?.value, 10) || null;
    const selectedAccountCode = this.accountCodes.find(account => account.accountCode === this.selectedAccount);
    const newProduct = {
      productName: this.form.get('productName')?.value,
      quantity: quantity,
      boughtPrice: this.form.get('boughtPrice')?.value,
      price: this.form.get('sellingPrice')?.value,
      accountCode: this.form.get('selectedAccount')?.value,
      accountName: selectedAccountCode ? selectedAccountCode.accountName : '',
      totalWithoutTva: this.totalWithoutTva,
      tva: this.tva,
      totalWithTva: totalWithTva,
      description: this.description,
      chartofaccountsCode : {
         accountCode : this.form.get('selectedAccount')?.value,
      }
     
    };
  
    this.addedProducts.push(newProduct);

    this.form.get('quantity')?.reset();
    this.form.get('productName')?.reset();
    this.form.get('selectedAccount')?.reset();
    this.form.get('boughtPrice')?.reset();
    this.form.get('sellingPrice')?.reset();
    this.form.get('description')?.reset();

    
  this.totalAmountWithoutTva = 0;
  this.totalAmountTva = 0;
  this.totalAmountWithTva = 0;

  this.addedProducts.forEach(product => {
    this.totalAmountWithoutTva += product.totalWithoutTva;
    this.totalAmountTva += product.tva;
    this.totalAmountWithTva += product.totalWithTva;
  });

  this.totalAmountWithoutTva = Number(this.totalAmountWithoutTva.toFixed(2));
  this.totalAmountTva = Number(this.totalAmountTva.toFixed(2));
  this.totalAmountWithTva = Number(this.totalAmountWithTva.toFixed(2));

  console.log(this.addedProducts);
  }
  

  removeProduct(index: number): void {
    this.addedProducts.splice(index, 1);
  }


  saleForm() {
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
      quantity: new FormControl(''),
      productName: new FormControl(''),
      boughtPrice: new FormControl(''),
      sellingPrice: new FormControl(''),
      selectedAccount: new FormControl(''),
    });
  }

  submitForm() {
    let debitAccount = {
        accountCode: '6021' // cheltuiala
      };
    let creditAccount = {
      accountCode: '401' // furnizor
    };
    let supplier = {
      supplierId: Number(this.form.get('supplierId')?.value)
    }

    const selectedSupplierId = this.form.get('supplierId')?.value;
    const selectedSupplier = this.suppliers.find(supplier => supplier.supplierId === selectedSupplierId);
  
    
    const supplierInfo = {
      supplierName: selectedSupplier ? selectedSupplier.supplierName : '',
      fiscalCode: selectedSupplier ? selectedSupplier.fiscalCode : '',
      bankAccount: selectedSupplier ? selectedSupplier.bankAccount : ''

    };
    
    let isDueDateCorrect = false;
    const dueDate = this.form.get('dueDate')?.value;
    const transactionDate = this.form.get('transactionDate')?.value
 

    if (dueDate < transactionDate) {
      alert('Due date cannot be before the Transaction Date');
      isDueDateCorrect = false;
      return;
    } else isDueDateCorrect = true;
  
    const transaction = {
      
      supplier: supplier,
      transactionAmount: this.isTvaPayer ? this.totalAmountWithTva : this.totalAmountWithoutTva,
      paidAmount: this.isTvaPayer ? this.totalAmountWithTva : this.totalAmountWithoutTva,


      transactionDate: new Date(this.form.get('transactionDate')?.value),
      dueDate: new Date(this.form.get('dueDate')?.value),
     
      documentNumber: this.form.get('documentNumber')?.value,
      documentSeries: this.form.get('documentSeries')?.value,
      description: this.form.get('description')?.value,
      debitAccount: debitAccount,
      creditAccount: creditAccount
    };

    if (!this.isPartialPayment && !this.form.value.payLater)
      transaction.paidAmount = transaction.transactionAmount;
    if(this.payLater)
      transaction.paidAmount = 0
    if(this.isPartialPayment)
      transaction.paidAmount = this.form.get('paidAmount')?.value

  
  
    this.addedProducts.forEach(() => {
      const productName = this.form.get('productName')?.value;
      const quantity = this.form.get('quantity')?.value;
      const price = this.form.get('sellingPrice')?.value;
    
      const productListItem: any = {
        
          chartOfAccountsCode: {
            accountCode: this.form.get('selectedAccount')?.value,
          },
        productName,
        quantity,
        price,
      };
      
      this.productList.push(productListItem);
      console.log(this.productList)
    });
  
    
    const model = {
      Transaction: transaction,
      ProductPurchaseItems:  this.addedProducts
    };

    const goodsReceiptNotePDFContent = `
    <div id="invoice-container" class="invoice-container" style="width: 500px">
      <h5 style="padding: 10px; background-color: #5757f3; color: white; width: 300px; text-align: center;">Goods Receipt Note <span style="text-transform: uppercase;"> ${transaction.documentSeries} - ${transaction.documentNumber}</span></h5>
      <div class="row">
      <div class="supplier col" style="font-size: 10px">
      <p>Company information:</p>
      <p style="font-size: 14px!important; margin-top: -20px;"><b> ${this.company.companyName} </b></p>
      <p style="margin-top: -20px;">Fiscal Code ${this.company.fiscalCode} </p>
      <p style="margin-top: -20px;">Trade Register ${this.company.tradeRegister} </p>
      <p style="margin-top: -20px;">Bank Account ${this.company.bankAccount ? this.company.bankAccount : 'No bank account'} </p>
      <p style="margin-top: -20px;">Email ${this.company.email} </p>
      </div>
      <div class="client col" style="font-size: 10px">
      <p>Supplier information:</p>
      <p style="font-size: 14px!important; margin-top: -20px;"><b>  ${supplierInfo.supplierName} </b></p>
      <p style="margin-top: -20px;">Fiscal Code ${supplierInfo.fiscalCode} </p>
      <p style="margin-top: -20px;">Bank Account ${supplierInfo.bankAccount} </p>
      </div>
      </div>
      <p style="font-size: 10px; ">Transaction Date: ${transaction.transactionDate.toLocaleDateString()}</p>
      <p style="font-size: 10px; margin-top: -20px;  margin-bottom: 10px;">Due Date: ${transaction.dueDate.toLocaleDateString()}</p>

      <table style="font-size: 12px;">
        <thead style="font-size: 12px;  background-color: #5757f3; color: white">
          <tr>
            <th style="margin-right: 12px!important;">Nr</th>
            <th style="margin-right: 12px!important;">Product</th>
            <th>Quantity</th>
            <th>Price</th>
            <th>Total without TVA </th> 
            <th>Total with TVA </th>
            <th>Description</th>
          </tr>
        </thead>
        <tbody>
          ${this.generateProductRows()}  
        </tbody>
      </table>
      <br>
        <div margin-top: 20px;>Total without TVA: <span class="amount"> ${this.totalAmountWithoutTva ? this.totalAmountWithoutTva : 0}</span></div>
        <div>Total TVA: <span class="amount"> ${this.totalAmountTva ? this.totalAmountTva : 0}</span></div>
        <div style="padding: 10px; background-color: #5757f3; color: white; width: 150px; text-align: center;">Total: <span class="amount"> ${this.totalAmountWithTva ? this.totalAmountWithTva : 0}</span></div>
        <br>
        <p style="font-size: 10px">Generated by <b>ContaPlus</b></p>
    </div>
  `;
  
    if(isDueDateCorrect)
    this.transactionService.createProductPurchaseTransaction(model).subscribe(
      () => {
        
        this.generateReceiptPDF(goodsReceiptNotePDFContent)
        this.form.reset();
        this.addedProducts = [];
          
      }
    );
  }
  

  generateReceiptPDF(goodsReceiptNotePDFContent: string) {
    const pdf = new jsPDF.default('p', 'pt', 'a4');


    pdf.html(goodsReceiptNotePDFContent, {
      margin: [10, 30, 30, 30],

      callback: (pdf) => {
        pdf.setProperties({
          title: 'Goods Receipt Note',

        });


        pdf.output('dataurlnewwindow');

        // pdf.save('goodsReceiptNote.pdf');
      },
    });
  }


  generateProductRows() {
    let rows = '';
    let index = 1;

    this.addedProducts.forEach(product => {
      rows += `<tr>
          <td>${index}</td>
          <td>${product.productName}</td>
          <td>${product.quantity ? product.quantity : ''}</td>
          <td>${product.price}</td>
          <td>${product.totalWithoutTva}</td>
          <td>${product.totalWithTva}</td>
          <td>${product.description ? product.description : ''}</td>
        </tr>`;

      index++;
    });

    return rows;
  }

 
  onPartialPaymentChange() {
    this.payLater = false;
  }

  onPayLaterChange() {
    this.isPartialPayment = false;
  }
  


}
