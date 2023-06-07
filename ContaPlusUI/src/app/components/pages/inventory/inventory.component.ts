import { Component, OnInit, ViewChild } from '@angular/core';
import { InventoryService } from 'src/app/services/inventory.service';
import { MatTableDataSource } from '@angular/material/table';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.css']
})
export class InventoryComponent implements OnInit {

  generalChartOfAccounts: any;
  filteredAccounts!: any;
  accountFilterControl: any;
  searchControl = new FormControl();
  productForm!: FormGroup;
  isAddProductDialogOpen!: boolean;

  dataSource!: MatTableDataSource<any>;
  displayedProductsColumns: string[] = ['type','productName', 'price', 'quantity', 'description'];
  products!: any[];
  @ViewChild(MatSort, { static: true }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;

  constructor(private inventoryService: InventoryService) {}

  ngOnInit(): void {
    this.fetchGeneralChartOfAccountsList();
    this.createProductForm();
    this.getProducts();
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
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

  createProductForm()
  {
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
    const createdAt =  new Date();
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

  getProducts()
  {
    this.inventoryService.getProductsByCompanyId().subscribe((response) => {
      this.products = response;
      this.dataSource = new MatTableDataSource(this.products);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    })
  }

  openAddProductDialog(): void {
    this.isAddProductDialogOpen = true;
  }

  closeAddProductDialog(): void {
    this.isAddProductDialogOpen = false;
  }

  onPaginateChange(event: any) {
    const pageSize = event.pageSize;
    const pageIndex = event.pageIndex;
  
    const startIndex = pageIndex * pageSize;
    const endIndex = startIndex + pageSize;
    this.dataSource.data = this.products.slice(startIndex, endIndex); 
  }
}



