import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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
  isEditMode: boolean = false;

  currentUserRoles: any[] = [];
  companyUsers: any[] = [];



  constructor(private userService: UserService) {
  }

  getUserService(): UserService {
    return this.userService;
  }

  ngOnInit(): void {
   
    this.userService.getUserProfilePicture();
    this.imageUrl = this.userService.imageUrl;

    this.userUpdateMethod();
    this.onUserShow();



    this.getCurrentUserRoleToCompany();

    this.getAllUsersToCurrentCompany();

  }



  getCurrentUserRoleToCompany() {
    const userId =  sessionStorage.getItem('userId'); 
    const companyId = sessionStorage.getItem('selectedCompanyId');
    if (userId && companyId)
      this.userService.getUserCompanyRole(userId, companyId).subscribe(
        (response) => {
          this.currentUserRoles = response.roles;
        },
        (error) => {
          console.log(error);
        }
      );
  }

  getAllUsersToCurrentCompany() {
    const userId =  sessionStorage.getItem('userId'); 
    const companyId = sessionStorage.getItem('selectedCompanyId');
  
    if (userId && companyId) {
      this.userService.getUsersAndRolesFromCompany(companyId).subscribe(
        (response) => {
          this.companyUsers = response.filter(user => user.user.userId !== userId);

          for (const user of this.companyUsers) {
            this.userService.getProfilePicture(user.user.userId).subscribe(
              (res) => {
                const reader = new FileReader();
                reader.readAsDataURL(res);
                reader.onloadend = () => {
                  user.profilePictureUrl = reader.result as string;
                }
              },
              (error) => {
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
    const userId =  sessionStorage.getItem('userId'); 
    if (userId) {
      this.userService.updateUser(userId, formData).subscribe(
        (response) => {
          console.log('User updated successfully:', response);
        }
      );
    }
    window.location.reload();
  }

  onUserShow() {
    const userId =  sessionStorage.getItem('userId'); 
    if (userId) {
      this.userService.getUserInfo(userId).subscribe(user => {
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

}
