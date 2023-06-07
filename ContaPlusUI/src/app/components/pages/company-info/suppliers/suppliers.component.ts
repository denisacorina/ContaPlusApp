import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { SupplierService } from 'src/app/services/supplier.service';


@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.css']
})
export class SupplierComponent implements OnInit {

activeRoute!: string;
  supplier!: any;
  companyId = sessionStorage.getItem('selectedCompanyId');
  addSupplierForm!: FormGroup;
  suppliers: any[] = [];
  dataSource!: MatTableDataSource<any>;
  displayedSuppliersColumns: string[] = ['supplierName', 'fiscalCode', 'address', 'bankAccount']; 
  isAddSupplierDialogOpen: boolean = false;

    constructor(private router: Router, private supplierService: SupplierService) { }

  isActive(route: string): boolean {
    return this.router.isActive(route, false);
   
  }
  
  ngOnInit()
  {
    this.getSuppliersForCompany();
    this.addSupplier();
  }

  getSuppliersForCompany()
  {
     if(this.companyId)
     this.supplierService.getSuppliers().subscribe((response) =>
    {
      this.suppliers = response;
      this.dataSource = new MatTableDataSource(this.suppliers);
    })
  }

  
  addSupplier() {
    this.addSupplierForm = new FormGroup({
      supplierName: new FormControl('', [Validators.required]),
      fiscalCode: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required]),
      bankAccount: new FormControl('', [Validators.required])
    });
  }

  openAddSupplierDialog(): void {
    this.isAddSupplierDialogOpen = true;
  }

  closeAddSupplierDialog(): void {
    this.isAddSupplierDialogOpen = false;
  }

  onAddSupplierSubmit(): void {
  
    const supplierName = this.addSupplierForm.value.supplierName;
    const fiscalCode = this.addSupplierForm.value.fiscalCode;
    const address = this.addSupplierForm.value.address;
    const bankAccount = this.addSupplierForm.value.bankAccount;

    const model = {
      supplierName,
      fiscalCode,
      address,
      bankAccount
    };

    if(this.addSupplierForm.valid)
    this.supplierService.addSupplierForCompany(model).subscribe(
      () => {
        window.location.reload();
      
      }
    );
    }
  

}
