import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.css']
})
export class SideBarComponent implements OnInit{

  mini = true;

  dropdownIncomeVisible = false;
  dropdownExpenseVisible = false;
  dropdownCompanyVisible = false;
  currentUserRoles: any;
  isAdmin: any;
  isManager: any;
  isAccountant: any;

  constructor(private router: Router, private userService: UserService) {}
  ngOnInit(): void {
    this.getCurrentUserRoleToCompany();
  }
  
  isActive(route: string): boolean {
    return this.router.isActive(route, false);
  }

  toggleDropdownIncome() {
    this.dropdownIncomeVisible = !this.dropdownIncomeVisible;
  }

  toggleDropdownExpense() {
    this.dropdownExpenseVisible = !this.dropdownExpenseVisible;
  }

  toggleDropdownCompany() {
    this.dropdownCompanyVisible = !this.dropdownCompanyVisible;
  }

  toggleSidebar() {
    if (this.mini) {
      console.log("opening sidebar");
      const sidebar = document.getElementById("mySidebar");
      const main = document.getElementById("main");
      const logo = document.getElementById("logo");
      if (sidebar != null && main != null && logo != null) {
        sidebar.style.width = "170px";
        main.style.marginLeft = "170px";
        logo.style.transition = "margin-left 0.5s";
        logo.style.marginLeft = "60px";
        this.mini = false;
      }
    } else {
      const sidebar = document.getElementById("mySidebar");
      const main = document.getElementById("main");
      const logo = document.getElementById("logo");
      this.dropdownIncomeVisible = false;
      this.dropdownExpenseVisible = false;
      console.log("closing sidebar");
      if (sidebar != null && main != null && logo != null) {
        sidebar.style.width = "85px";
        main.style.marginLeft = "85px";
        logo.style.margin = "18px";
        this.mini = true;
      }

    }

  }


  getCurrentUserRoleToCompany() {
    const user = sessionStorage.getItem('userId');
    const companyId = sessionStorage.getItem('selectedCompanyId');
    if (user && companyId) {
      this.userService.getUserCompanyRole(user, companyId).subscribe(
        (response) => {
          this.currentUserRoles = response.roles.map((role: { roleName: any; }) => role.roleName);
          this.isAdmin = this.currentUserRoles.includes('admin');
          this.isManager = this.currentUserRoles.includes('manager');
          this.isAccountant = this.currentUserRoles.includes('accountant');
        },
        (error) => {
          console.log(error);
        }
      );
    }
  }
}
