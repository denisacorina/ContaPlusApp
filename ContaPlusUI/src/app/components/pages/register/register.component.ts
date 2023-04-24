import { getLocaleDateTimeFormat } from '@angular/common';
import { Component, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, UrlSerializer } from '@angular/router';
import { finalize } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';
//import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

  
export class RegisterComponent {


  
    
model : any = {};
registered = true;  
errorMessage!: string;
passwordError!: string;
passwordIsValid: boolean = false;

registrationForm!: FormGroup;

  constructor(private authService : AuthService, private router : Router) {

  }


  ngOnInit(): void {
    this.registrationFormMethod();
   
  }

  registrationFormMethod() {
    this.registrationForm = new FormGroup({
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required,  Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/)]),
    });
  }

  submitData() {
    if (this.registrationForm.invalid) {
      return;
    }
    this.authService.register(this.registrationForm.value).subscribe({
      next: response => {
        console.log(response);
        this.registered = true;
        this.router.navigateByUrl("login");
      },
      error: err => {
        if (err.status == 400) {
          this.errorMessage = "Email is already used";
        }
        console.log(err);
      }
    })
  }
}
