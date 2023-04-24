import { GoogleLoginProvider, SocialAuthService } from '@abacritt/angularx-social-login';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, TitleStrategy, UrlSerializer } from '@angular/router';
import { catchError, map, tap, throwError } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  loggedIn = false;
  errorMessage!: string;
  showError!: boolean;
  jwtHelper: any;

  rememberMe: boolean = false;
  loginForm!: FormGroup;

  constructor(private authService: AuthService, private router: Router ){}
  
  ngOnInit(): void {
    this.loginFormMethod();
  }

  loginFormMethod() {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required]),
      password: new FormControl('', Validators.required),
      rememberMe: new FormControl(false)
    });
  }

  onLoginSubmit() {
    const formData = this.loginForm.value;
    this.authService.login(formData, formData.rememberMe).pipe(
      map((response: any) => {
        const accessToken = response.accessToken;
        localStorage.setItem('accessToken', accessToken);
        this.router.navigateByUrl("/dashboard");
      }),
      catchError((error: any) => {
        this.errorMessage = "Invalid login credentials. Please try again.";
        return error;
      })
    ).subscribe();
  }

}


