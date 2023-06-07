import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientService } from 'src/app/services/client.service';
import { MatTableDataSource } from '@angular/material/table';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-company-info',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {

  activeRoute!: string;
  client!: any;
  companyId = sessionStorage.getItem('selectedCompanyId');
  addClientForm!: FormGroup;
  clients: any[] = [];
  dataSource!: MatTableDataSource<any>;
  displayedClientsColumns: string[] = ['clientName', 'fiscalCode', 'address', 'bankAccount']; 
  isAddClientDialogOpen: boolean = false;

  constructor(private router: Router, private clientService: ClientService) { }

  isActive(route: string): boolean {
    return this.router.isActive(route, false);
   
  }
  
  ngOnInit()
  {
    this.getClientsForCompany();
    this.addClient();
  }

  getClientsForCompany()
  {
 
    this.clientService.getClients().subscribe((response) =>
    {
      this.clients = response;
      this.dataSource = new MatTableDataSource(this.clients);
    })
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

    if(this.addClientForm.valid)
    this.clientService.addClientForCompany(model).subscribe(
      () => {
        window.location.reload();
      
      }
    );
    
  }


}
