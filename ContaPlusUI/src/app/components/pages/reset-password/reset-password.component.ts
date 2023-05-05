import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent {
  email!: any;
  resetPasswordForm!: FormGroup;
  resetToken!: any;
  password!: string;


  constructor(private http: HttpClient, private route: ActivatedRoute) {
   
  }

  ngOnInit(): void {
    this.resetPasswordFormMethod();
    this. getEmailResetToken();


  }

  getEmailResetToken() {
     this.route.paramMap.subscribe(params => {
      this.email = params.get('email');
      this.resetToken = params.get('resetToken');
    });
  }

  resetPasswordFormMethod() {
    this.resetPasswordForm = new FormGroup({
      password: new FormControl('', [Validators.required, Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/)]),
      confirmPassword: new FormControl('', Validators.required)}, {validators: this.passwordMatchValidator});
  }

  onSubmitResetPassword() {
    const password = this.resetPasswordForm.get('password')?.value;
    console.log(password)
    const resetPassword = { email: this.email, resetToken: this.resetToken, password: password };
    console.log(resetPassword)
    this.http.post('https://localhost:7121/api/Users/resetPassword', resetPassword).subscribe(
      () => {
        alert('Password has been changed successfully!');
        console.log('Password has been changed successfully!')
        console.log(resetPassword)
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  passwordMatchValidator(control: AbstractControl): { mismatch: boolean } | null {
    const newPassword = control.get('password');
    const confirmPassword = control.get('confirmPassword');
  
    if (newPassword && confirmPassword && newPassword.value !== confirmPassword.value) {
      return { mismatch: true };
    }
    return null;
  }
}  


