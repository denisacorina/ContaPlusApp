import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CompanyService } from 'src/app/services/company.service';
import { RoleService } from 'src/app/services/role.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css']
})
export class TeamComponent implements OnInit {

  userId!: string | null;
  currentUserRoles: any;
  companyUsers!: any[];
  addUserToCompanyForm: any;
  isExistingUser!: boolean;
  roles!: any[];
  companies: any;
  isAddUserToCompanyDialogOpen: any;
  users!: any[];
  selectedUser!: string | null;
  selectedRole: any;
  isAdmin: any;
  isManager: any;
  isAccountant: any;
  constructor(private userService: UserService, private companyService: CompanyService, private roleService: RoleService) {
  }

  getUserService(): UserService {
    return this.userService;
  }

  ngOnInit(): void {

    this.userId = this.userService.getLoggedInUserId();

    this.getCurrentUserRoleToCompany();

    this.getAllUsersToCurrentCompany();

    this.getCurrentUserRoleToCompany();

    this.getAllUsersToCurrentCompany();
    this.getUsers();
    this.getRoles();
    this.addUserToCompany();

  }




  getCurrentUserRoleToCompany() {
    const user = this.userId;
    const companyId = sessionStorage.getItem('selectedCompanyId');
    if (user && companyId)
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


  getAllUsersToCurrentCompany() {
    const user = this.userId;
    const companyId = sessionStorage.getItem('selectedCompanyId');

    if (user && companyId) {
      this.userService.getUsersAndRolesFromCompany(companyId).subscribe(
        (response) => {
          this.companyUsers = response;

          for (const user of this.companyUsers) {
            this.userService.getProfilePicture(user.user.userId).subscribe(
              (res) => {
                const reader = new FileReader();
                reader.readAsDataURL(res);
                reader.onloadend = () => {
                  user.profilePictureUrl = reader.result as string;
                }
              },
              () => {
                console.log("User doesn't have profile picture set");
                user.profilePictureUrl = 'https://www.pngall.com/wp-content/uploads/5/Profile-Transparent.png';
              }
            );
          }
        },
        (error) => {
          console.log(error);
        }
      );
    }
  }


  addUserToCompany() {
    this.addUserToCompanyForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      companyId: new FormControl('', Validators.required),
      roleId: new FormControl('', Validators.required)
    });

  }

  checkIfUserExists(email: string) {
    this.userService.getUserByEmail(email).subscribe(() => {
      this.isExistingUser = true;
    }, () => {
      this.isExistingUser = false;
    });
  }

  openAddUserToCompanyDialog() {
    this.isAddUserToCompanyDialogOpen = true;
  }

  closeAddUserToCompanyDialog() {
    this.isAddUserToCompanyDialogOpen = false;
  }

  onAddUserToCompanySubmit() {
    let { email, roleId } = this.addUserToCompanyForm.value;
    const companyId = sessionStorage.getItem('selectedCompanyId');

    if (companyId) {
      if (this.isExistingUser) {
        this.userService.addExistingUserToCompany(companyId, email, roleId).subscribe(
          () => {
            alert('User has been added to the company');
            this.closeAddUserToCompanyDialog();
          }
        );
      } else {
        const { firstName, lastName } = this.addUserToCompanyForm.value;
        this.userService.addNewUserToCompany(companyId, firstName, lastName, email, roleId).subscribe(
          () => {
            alert('User has been added to the company');
            this.closeAddUserToCompanyDialog();
          }
        );
      }
      window.location.reload();
    }
  }

  getRoles() {
    this.roleService.getRoles().subscribe((roles) => {
      this.roles = roles;
    });
  }


  getUsers() {
    const companyId = sessionStorage.getItem('selectedCompanyId');
    if (companyId)
      this.userService.getUsersAndRolesFromCompany(companyId).subscribe((response) => {
        this.users = response;
        if (this.users.length > 0) {
          this.selectedUser = this.users[0].user.userId;
        }
      })
  }

  addUserRole() {
    const companyId = sessionStorage.getItem('selectedCompanyId');
    if (companyId && this.selectedUser && this.selectedRole) {
      this.userService.addUserRoleToCompany(this.selectedUser, this.selectedRole, companyId).subscribe(
        () =>
          window.location.reload()

      );
    }
  }
}
