import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CompanyService } from 'src/app/services/company.service';
import { RoleService } from 'src/app/services/role.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent {
  imageUrl!: any;
  showChoosePhoto: boolean = false;
  updateUserForm!: FormGroup;
  addUserToCompanyForm!: FormGroup;
  isEditMode: boolean = false;

  currentUserRoles: any[] = [];
  companyUsers: any[] = [];
  companies: any[] = [];

  userId!: any;

  isExistingUser!: boolean;
  roles: any[] = [];
  isAddUserToCompanyDialogOpen: boolean = false;

  constructor(private userService: UserService, private companyService: CompanyService, private roleService: RoleService) {
  }

  getUserService(): UserService {
    return this.userService;
  }

  ngOnInit(): void {

    this.userId = this.userService.getLoggedInUserId();
    this.userService.getUserProfilePicture();
    this.imageUrl = this.userService.imageUrl;

    this.userUpdateMethod();
    this.onUserShow();

    this.getCurrentUserRoleToCompany();

    this.getAllUsersToCurrentCompany();
    this.getCompaniesForUser();
    this.getRoles();
    this.getAdminCompanies(this.userId);

    this.addUserToCompany();
  }



  getCurrentUserRoleToCompany() {
    const user = this.userId;
    const companyId = sessionStorage.getItem('selectedCompanyId');
    if (user && companyId)
      this.userService.getUserCompanyRole(user, companyId).subscribe(
        (response) => {
          this.currentUserRoles = response.roles.map((role: { roleName: any; }) => role.roleName);
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

  getCompaniesForUser() {
    const user = this.userId;
    if (user) {
      this.companyService.getCompaniesForUser(user).subscribe(
        (response) => {
          this.companies = response;
        }
      )
    }
  }

  getImageUrl(imageData: any): string {
    const blob = new Blob([imageData], { type: 'image/jpeg' });
    return URL.createObjectURL(blob);
  }

  onChoosePhotoClicked() {
    this.showChoosePhoto = true;
  }

  onExit() {
    this.showChoosePhoto = false;
  }

  onExitEdit() {
    this.updateUserForm.disable();
    this.isEditMode = false;
  }

  onFileSelected(event: Event) {
    this.userService.onFileSelected(event);

  }

  onUpload() {
    this.userService.onUpload();
    setTimeout(() => {
      window.location.reload();
    }, 1000);
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


  onAddUserToCompanySubmit() {
    let { companyId, email, roleId } = this.addUserToCompanyForm.value;
  console.log(companyId)
  roleId = 1
  console.log(roleId)
    
      if (this.isExistingUser) {
        this.userService.addExistingUserToCompany(companyId, email, roleId).subscribe(
          () => {
            alert('User has been added to the company');
            this.closeAddUserToCompanyDialog();
          },
          (error) => {
            console.error('Error adding existing user to company:', error);
          }
        );
      } else {
        const { firstName, lastName } = this.addUserToCompanyForm.value;
        this.userService.addNewUserToCompany(companyId, firstName, lastName, email, roleId).subscribe(
          () => {
            alert('User has been added to the company');
            this.closeAddUserToCompanyDialog();
          },
          (error) => {
            console.error('Error adding new user to company:', error);
          }
        );
      }
  }




  getRoles() {
    this.roleService.getRoles().subscribe((roles) => {
      this.roles = roles;
    });
  }

  getAdminCompanies(user: string) {
    user = this.userId;
    this.companyService.getAdminCompanies(user).subscribe((companies) => {
      this.companies = companies;
    })
  }

  userUpdateMethod() {
    this.updateUserForm = new FormGroup({
      firstName: new FormControl({ value: '', disabled: !this.isEditMode }, Validators.required),
      lastName: new FormControl({ value: '', disabled: !this.isEditMode }, Validators.required),
      email: new FormControl({ value: '', disabled: true }),
      phoneNumber: new FormControl({ value: '', disabled: !this.isEditMode }, [Validators.pattern(/^07\d{8}$/)])
    });
  }

  onUserUpdateSubmit() {
    const formData = this.updateUserForm.value;
    const user = this.userId;
    if (user) {
      this.userService.updateUser(user, formData).subscribe(
        (response) => {
          console.log('User updated successfully:', response);
        }
      );
    }
    window.location.reload();
  }

  onUserShow() {
    const user = this.userId;
    if (user) {
      this.userService.getUserInfo(user).subscribe(user => {
        this.updateUserForm.setValue({
          firstName: user.firstName,
          lastName: user.lastName,
          email: user.email,
          phoneNumber: user.phoneNumber || 'No Phone Number Added'
        });
      });
    }
  }

  toggleEditMode() {
    this.isEditMode = !this.isEditMode;

    if (this.isEditMode) {
      this.updateUserForm.enable();
    } else {
      this.updateUserForm.disable();
    }
  }

  openAddUserToCompanyDialog() {
    this.isAddUserToCompanyDialogOpen = true;
  }

  closeAddUserToCompanyDialog() {
    this.isAddUserToCompanyDialogOpen = false;
  }
}
