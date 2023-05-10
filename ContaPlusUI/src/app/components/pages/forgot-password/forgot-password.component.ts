import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {

  email!: string;
  forgotPasswordForm!: FormGroup;
  successAlert: boolean = false;

  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    this.loginFormMethod();
  }

  loginFormMethod() {
    this.forgotPasswordForm = new FormGroup({
      email: new FormControl('', [Validators.email, Validators.required]),  
    });
  }

  onSubmitForgotPassword() {
    this.email = this.forgotPasswordForm.get('email')?.value;

    this.http.post(`https://localhost:7121/api/Users/forgotPassword/${this.email}`, null).subscribe(
      () => {console.log('Forgot password link has been sent to the email you provided.')},
      (error) => {
        if (error.status === 404) {
          console.log('Email not found');
        }
      }
    );
    alert('Forgot password link has been sent to the email you provided.');
  }
}