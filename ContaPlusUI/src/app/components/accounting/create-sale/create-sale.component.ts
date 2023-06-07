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
import { PreviewService } from 'src/app/services/preview.service';
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

  constructor(
    private inventoryService: InventoryService,
    private clientService: ClientService,
    private companyService: CompanyService,
    private transactionService: TransactionService,
    private router: Router,
    private previewService: PreviewService
  ) {}

  ngOnInit() {
    

    this.inventoryService.getProductsByCompanyId().subscribe(
      (products) => {
        this.products = products;
      }
    );

    this.clientService.getClients().subscribe(
      (clients) => {
        this.clients = clients;
      }
    );
    this.saleForm();
  
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
    const clientName = selectedClient ? selectedClient.clientName : '';
  
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
      creditAccount: creditAccount
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
  
    this.transactionService.createProductSaleTransaction(model).subscribe(
      () => {
        const htmlContent = `
        <div id="invoice-container" class="invoice-container" style="width: 500px">
          <h3 class="col" style="font-weight: 700; color: #525252;">Invoice Details</h3>
          <p>Client: ${clientName}</p>
          <p>Transaction Date: ${transaction.transactionDate}</p>
          <p>Due Date: ${transaction.dueDate}</p>

          <table style="font-size: 12px;">
            <thead style="font-size: 12px; background-color: pink;">
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
            <div>Total without TVA: <span class="amount"> ${this.totalAmountWithoutTva ? this.totalAmountWithoutTva : 0 }</span></div>
            <div>Total TVA: <span class="amount"> ${ this.totalAmountTva ? this.totalAmountTva : 0 }</span></div>
            <div>Total with TVA: <span class="amount"> ${ this.totalAmountWithTva ? this.totalAmountWithTva : 0 }</span></div>
          </div>
        </div>
      `;

    
      this.generatePDF(htmlContent);
     //this.previewService.setHtmlContent(htmlContent);
     // this.router.navigate(['/preview']);
      }
    );
  }
  generatePDF(htmlContent: string) {
    const pdf = new jsPDF.default('p', 'pt', 'a4');
  
  
  pdf.html(htmlContent, {
    margin: [10, 30, 30 , 30],
    
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

  downloadPDF() {
    const doc = new jsPDF.default('p', 'mm', 'a4');
    const element = document.getElementById('pdfPreview');

    if(element)
    html2canvas(element).then((canvas) => {
      const imgData = canvas.toDataURL('image/png');
  
      doc.addImage(imgData, 'PNG', 10, 10, 190, 280);
  
      doc.save('document.pdf');
    });
  }

  generateAndOpenPDF() {
    const doc = new jsPDF.default('p', 'mm', 'a4');
  
    const element = document.getElementById('pdfPreviewContainer');
    if (element) {
      html2canvas(element).then((canvas) => {
        const imgData = canvas.toDataURL('image/jpeg');
  
        doc.addImage(imgData, 'JPEG', 10, 10, 190, 5);
  
        // Converteste PDF-ul generat într-un obiect Blob
        const pdfOutput = doc.output('blob');
  
        // Creează un URL pentru obiectul Blob
        const pdfURL = URL.createObjectURL(pdfOutput);
  
        // Deschide o nouă pagină cu PDF-ul afișat
        const newWindow = window.open();
        if (newWindow) {
          newWindow.document.open();
          newWindow.document.write('<html><head><title>PDF Preview</title></head><body>');
          newWindow.document.write('<embed width="100%" height="100%" src="' + pdfURL + '" type="application/pdf" />');
          newWindow.document.write('</body></html>');
          newWindow.document.close();
        }
      });
    }
  }
  

  


}
