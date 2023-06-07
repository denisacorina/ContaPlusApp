import { Component, ElementRef, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ClientService } from 'src/app/services/client.service';
import { InventoryService } from 'src/app/services/inventory.service';
import { MatTableDataSource } from '@angular/material/table';
import { CompanyService } from 'src/app/services/company.service';
import { TransactionService } from 'src/app/services/transaction.service';
import { SupplierService } from 'src/app/services/supplier.service';

@Component({
  selector: 'app-create-purchase',
  templateUrl: './create-purchase.component.html',
  styleUrls: ['./create-purchase.component.css']
})
export class CreatePurchaseComponent {

  salesForm!: FormGroup;
  products: any[] = [];
  suppliers: any[] = [];
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

  accountCodes!: any[];
  selectedAccountCode: any;
  selectedAccount: any;
  product: any;

  constructor(
    private inventoryService: InventoryService,
    private supplierService: SupplierService,
    private companyService: CompanyService,
    private transactionService: TransactionService
  ) {}

  ngOnInit() {
    

    this.supplierService.getSuppliers().subscribe(
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

  // onAccountSelected(accountCode: any) {
  //   this.selectedAccount = this.accountCodes.find(accountCode => accountCode.accountCode === accountCode);
  //   console.log("onaccountselected", this.selectedAccount)
  // }

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
    const newProduct = {
      productName: this.form.get('productName')?.value,
      quantity: quantity,
      boughtPrice: this.form.get('boughtPrice')?.value,
      price: this.form.get('sellingPrice')?.value,
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
    this.form.get('selectedAccount')?.reset();
    this.form.get('boughtPrice')?.reset();
    this.form.get('sellingPrice')?.reset();
    this.form.get('productName')?.reset();

   

    
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
      selectedAccount:  new FormControl('')
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
      supplierId: this.form.get('supplierId')?.value
    }

  

    const selectedSupplierId = this.form.get('supplierId')?.value;
    const selectedSupplier = this.suppliers.find(supplier => supplier.supplierId === selectedSupplierId);
    const supplierName = selectedSupplier ? selectedSupplier.supplierName : '';
  
    const transaction = {
      
      supplier: supplier,
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
      const chartOfAccounts = this.form.get('selectedAccount')?.value;
      const productName = this.form.get('productName')?.value;
      const quantity = this.form.get('quantity')?.value;
      const price = this.form.get('sellingPrice')?.value;
    
      const productListItem: any = {
        
          chartOfAccountsCode: {
            accountCode: chartOfAccounts,
          },
        productName,
        quantity,
        price,
      };
      
      this.productList.push(productListItem);
      
    });
  
    console.log(this.productList)
    const model = {
      Transaction: transaction,
      ProductPurchaseItems:  this.addedProducts
    };

    console.log("this.addedProducts", this.addedProducts)
    console.log(" this.productList",  this.productList)
  
    this.transactionService.createProductPurchaseTransaction(model).subscribe(
      () => {
        window.location.reload();
      }
    );
  }
 

  


}
