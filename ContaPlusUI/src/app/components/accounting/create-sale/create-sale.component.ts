import { Component, ElementRef, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ClientService } from 'src/app/services/client.service';
import { InventoryService } from 'src/app/services/inventory.service';
import { MatTableDataSource } from '@angular/material/table';
import { CompanyService } from 'src/app/services/company.service';
import { TransactionService } from 'src/app/services/transaction.service';
import * as jsPDF from 'jspdf';
import html2canvas from 'html2canvas';
import * as pdfMake from 'pdfmake/build/pdfmake';
import * as pdfFonts from 'pdfmake/build/vfs_fonts'
import { Router } from '@angular/router';

import 'jspdf-autotable';


(pdfMake as any).vfs = pdfFonts.pdfMake.vfs;

@Component({
  selector: 'app-create-sale',
  templateUrl: './create-sale.component.html',
  styleUrls: ['./create-sale.component.css']
})
export class CreateSaleComponent implements OnInit {
  salesForm!: FormGroup;
  products: any[] = [];
  clients: any[] = [];
  productList: any[] = [];
  invoiceForm: any;
  form!: FormGroup;
  dataSource: MatTableDataSource<any> = new MatTableDataSource<any>();
  displayedColumns: string[] = ['nr', 'good/service', 'quantity', 'price', 'totalWithoutTva', 'tva', 'totalWithTva'];
  productForm!: FormGroup;
  addedProducts: any[] = [];
  isAddedProduct = (_: number, product: any) => !!product.added;
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
  @ViewChild('pdfPreview') pdfPreview!: ElementRef;
  pdfPreviewHidden: boolean = true;
  elementRef: any;
  companyId = sessionStorage.getItem('selectedCompanyId');
  addClientForm!: FormGroup<{ clientName: FormControl<string | null>; fiscalCode: FormControl<string | null>; address: FormControl<string | null>; bankAccount: FormControl<string | null>; }>;
  isAddClientDialogOpen!: boolean;
  isAddProductDialogOpen!: boolean;
  generalChartOfAccounts!: { title: string; accounts: any[]; }[];

  constructor(
    private inventoryService: InventoryService,
    private clientService: ClientService,
    private companyService: CompanyService,
    private transactionService: TransactionService,
    private router: Router,

  ) { }

  ngOnInit() {
    if (this.companyId)
      this.companyService.getCompanyById(this.companyId).subscribe(
        (company) => {
          this.company = company;
        })

    this.inventoryService.getProductsByCompanyId().subscribe(
      (products) => {
        this.products = products.filter((product) => product.quantity > 0);
      }
    );

    this.getClients();
    this.addClient()
    this.saleForm();
    this.createProductForm();
    this.fetchGeneralChartOfAccountsList();

  }

  onProductSelected(productId: string) {
    const selectedProduct = this.products.find(product => product.productId === productId);
    this.form.get('price')?.setValue(selectedProduct?.price);
  }

  addProduct() {
    this.selectedProductId = this.form.get('selectedProduct')?.value;
    this.selectedProduct = this.products.find(product => product.productId === this.selectedProductId);
    const companyId = sessionStorage.getItem('selectedCompanyId');
    const isService = this.products.find(product => product.productId === this.selectedProductId)?.isService;
    this.description = this.form.get('description')?.value;
    if (this.selectedProduct) {

      const quantity = this.form.get('quantity')?.value;
      const price = this.form.get('price')?.value;

      if (quantity > this.selectedProduct.quantity) {
        alert("Quantity exceeds available quantity");
        return;
      }

      this.totalWithoutTva = (price * quantity);

      if (isService) {
        this.totalWithoutTva = price;
      }


      if (companyId) {
        this.companyService.getCompanyById(companyId).subscribe((response) => {
          this.isTvaPayer = response.tvaPayer;
          this.calculateTva();
        });
      } else {
        this.calculateTva();
      }
    }
  }

  calculateTva() {
    this.tva = this.isTvaPayer ? (this.totalWithoutTva * 0.19) : 0;

    const totalWithTva = this.totalWithoutTva + this.tva;
    const quantity = parseInt(this.form.get('quantity')?.value, 10) || null;
    const newProduct = {
      productId: this.selectedProductId,
      productName: this.selectedProduct.productName,
      quantity: quantity,
      price: this.selectedProduct.price,
      totalWithoutTva: this.totalWithoutTva,
      tva: this.tva,
      totalWithTva: totalWithTva,
      description: this.description
    };

    this.addedProducts.push(newProduct);

    this.form.get('quantity')?.reset();
    this.form.get('selectedProduct')?.reset();
    this.form.get('price')?.reset();
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

  isServiceProduct() {
    const selectedProductId = this.form.get('selectedProduct')?.value;
    const selectedProduct = this.products.find(product => product.productId === selectedProductId);
    return selectedProduct ? selectedProduct.isService : false;
  }

  saleForm() {
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

      productId: new FormControl('', Validators.required),
      quantity: new FormControl(''),
      selectedProduct: new FormControl(''),
      price: new FormControl(''),
    });
  }


  submitForm() {
    let debitAccount = {
      accountCode: '4111' // client
    };
    let creditAccount = {
      accountCode: '7412' // venit
    };
    let client = {
      clientId: this.form.get('clientId')?.value
    }
    const selectedClientId = this.form.get('clientId')?.value;
    const selectedClient = this.clients.find(client => client.clientId === selectedClientId);
    const clientInfo = {
      clientName: selectedClient ? selectedClient.clientName : '',
      fiscalCode: selectedClient ? selectedClient.fiscalCode : '',
      bankAccount: selectedClient ? selectedClient.bankAccount : ''

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

      client: client,
      transactionAmount: this.isTvaPayer ? this.totalAmountWithTva : this.totalAmountWithoutTva,

      paidAmount: this.isTvaPayer ? this.totalAmountWithTva : this.totalAmountWithoutTva,

      transactionDate: this.form.get('transactionDate')?.value,
      dueDate: this.form.get('dueDate')?.value,

      documentNumber: this.form.get('documentNumber')?.value,
      documentSeries: this.form.get('documentSeries')?.value,
      description: this.form.get('description')?.value,
      debitAccount: debitAccount,
      creditAccount: creditAccount,
      documents: []
    };

    this.addedProducts.forEach(() => {
      const productId = this.form.get('selectedProduct')?.value;
      const quantity = this.form.get('quantity')?.value;
      const price = this.form.get('price')?.value;

      const productListItem: any = {
        productId,
        quantity,
        price
      };

      this.productList.push(productListItem);
    });

    const model = {
      Transaction: transaction,
      ProductSaleItems: this.addedProducts
    };

    const htmlContent = `
        <div id="invoice-container" class="invoice-container" style="width: 500px">
          <h3 class="col" style="font-weight: 700; color: #525252;">Invoice Details</h3>
          <h5>Invoice ${transaction.documentSeries}  ${transaction.documentNumber}</h5>
          <div class="row">
          <div class="client col" style="font-size: 10px">
          <p>Client information:</p>
          <p>Name ${clientInfo.clientName} </p>
          <p>Fiscal Code ${clientInfo.fiscalCode} </p>
          <p>Bank Account ${clientInfo.bankAccount} </p>
          </div>
          <div class="supplier col" style="font-size: 10px">
          <p>Supplier information:</p>
          <p>Name ${this.company.companyName} </p>
          <p>Fiscal Code ${this.company.fiscalCode} </p>
          <p>Trade Register ${this.company.tradeRegister} </p>
          <p>Bank Account ${this.company.bankAccount ? this.company.bankAccount : ''} </p>
          <p>Email ${this.company.email} </p>
          </div>
          </div>
          <p>Transaction Date: ${transaction.transactionDate.toLocaleDateString()}</p>
          <p>Due Date: ${transaction.dueDate.toLocaleDateString()}</p>

          <table style="font-size: 12px;">
            <thead style="font-size: 12px; background-color: #5757f3; color: white">
              <tr>
                <th>Nr</th>
                <th>Name of the good/service</th>
                <th>Quantity</th>
                <th>Price</th>
                <th>Total without TVA</th>
                <th>TVA</th>
                <th>Total with TVA</th>
                <th>Description</th>
              </tr>
            </thead>
            <tbody>
              ${this.generateProductRows()}  
            </tbody>
          </table>
          
          <div class="totalAmounts" *ngIf="addedProducts.length > 0">
            <div>Total without TVA: <span class="amount"> ${this.totalAmountWithoutTva ? this.totalAmountWithoutTva : 0}</span></div>
            <div>Total TVA: <span class="amount"> ${this.totalAmountTva ? this.totalAmountTva : 0}</span></div>
            <div>Total with TVA: <span class="amount"> ${this.totalAmountWithTva ? this.totalAmountWithTva : 0}</span></div>
          </div>
        </div>
      `;

    if(isDueDateCorrect)
    this.transactionService.createProductSaleTransaction(model).subscribe(
      () => {

        this.generatePDF(htmlContent);
        this.form.get('quantity')?.reset();
        this.form.get('selectedProduct')?.reset();
        this.form.get('price')?.reset();
        this.form.get('description')?.reset();
        this.form.get('clientId')?.reset();
        this.form.get('transactionDate')?.reset();
        this.form.get('dueDate')?.reset();
        this.form.get('documentSeries')?.reset();
        this.form.get('documentNumber')?.reset();
        this.addedProducts = [];
      }
    );

  }

  generatePDF(htmlContent: string) {
    const pdf = new jsPDF.default('p', 'pt', 'a4');


    pdf.html(htmlContent, {
      margin: [10, 30, 30, 30],

      callback: (pdf) => {
        pdf.setProperties({
          title: 'Invoice',

        });


        pdf.output('dataurlnewwindow');

        // pdf.save('invoice.pdf');
      },
    });
  }


  generateProductRows() {
    let rows = '';
    let index = 1;

    this.addedProducts.forEach(product => {
      rows += `
        <tr>
          <td>${index}</td>
          <td>${product.productName}</td>
          <td>${product.quantity}</td>
          <td>${product.price}</td>
          <td>${product.totalWithoutTva}</td>
          <td>${product.tva}</td>
          <td>${product.totalWithTva}</td>
          <td>${product.description}</td>
        </tr>
      `;

      index++;
    });

    return rows;
  }



  getClients() {
    this.clientService.getClients(this.companyId).subscribe(
      (clients) => {
        this.clients = clients;
      }
    );
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


  openAddProductDialog(): void {
    this.isAddProductDialogOpen = true;
  }

  closeAddProductDialog(): void {
    this.isAddProductDialogOpen = false;
  }

  createProductForm() {
    this.productForm = new FormGroup({
      productName: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      price: new FormControl('', Validators.required),
      quantity: new FormControl(''),
      isService: new FormControl(false),
      accountCode: new FormControl('', Validators.required)
    });

    this.productForm.get('accountCode')?.valueChanges.subscribe((value) => {
      if (value === 704) {
        this.productForm.get('isService')?.setValue(true);
      } else {
        this.productForm.get('isService')?.setValue(false);

      }
    });
  }

  onAddProductSubmit(): void {
    const chartOfAccountsCode = {
      accountCode: this.productForm.value.accountCode
    };
    const productName = this.productForm.value.productName;
    const description = this.productForm.value.description;
    const price = this.productForm.value.price;
    const isService = this.productForm.value.isService;
    const quantity = !isService ? this.productForm.value.quantity : null;
    const createdAt = new Date();
    const model = {
      chartOfAccountsCode,
      productName,
      description,
      price,
      quantity,
      isService,
      createdAt

    };

    if (isService || this.productForm.valid) {
      this.inventoryService.addProductForCompany(model).subscribe(
        () => {
          window.location.reload();
        }
      );
    }
  }

  fetchGeneralChartOfAccountsList() {
    this.inventoryService.getGeneralChartOfAccountsList().subscribe(
      (response) => {
        const goodsAccounts = response.filter((account) => account.accountNumber === 3 && account.product_Service === 'Bun');
        const serviceAccount = response.find((account) => account.accountCode === 704);

        this.generalChartOfAccounts = [
          { title: 'Good', accounts: goodsAccounts },
          { title: 'Service', accounts: [serviceAccount] },
        ];
      }
    );
  }

}
