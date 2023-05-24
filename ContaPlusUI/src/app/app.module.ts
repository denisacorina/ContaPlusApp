import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './components/pages/login/login.component';
import { RegisterComponent } from './components/pages/register/register.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MaterialModule } from './shared/modules/material/material.module';
import { IgxCarouselModule } from 'igniteui-angular';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { DashboardComponent } from './components/pages/dashboard/dashboard.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthGuard } from 'src/app/shared/guards/auth.guard'
import { JwtHelperService, JwtModule } from '@auth0/angular-jwt';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from 'src/app/shared/jwt.incerceptor';
import { SideBarComponent } from './components/navigation/side-bar/side-bar.component';
import { TopNavBarComponent } from './components/navigation/top-nav-bar/top-nav-bar.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import {  NgApexchartsModule } from 'ng-apexcharts';
import { ForgotPasswordComponent } from './components/pages/forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './components/pages/reset-password/reset-password.component';
import { UserProfileComponent } from './components/pages/user-profile/user-profile.component';
import { CommonModule } from '@angular/common';
import { IncomeComponent } from './components/accounting/income/income.component';
import {MatNativeDateModule} from '@angular/material/core';
import {MatDatepickerModule} from '@angular/material/datepicker';

export function tokenGetter()
{
  return localStorage.getItem("token");
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    DashboardComponent,
    SideBarComponent,
    TopNavBarComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent,
    UserProfileComponent,
    IncomeComponent,
    

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FontAwesomeModule,
    IgxCarouselModule,
    MatFormFieldModule,
    MatInputModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    NgApexchartsModule,
    ReactiveFormsModule,
    MatDatepickerModule, 
    MatNativeDateModule,
    CommonModule,
    ModalModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:5001"],
        disallowedRoutes: []
      }
    })
  
  ],
providers: [ [
  {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
  }
], [AuthGuard], [JwtHelperService],
],
  bootstrap: [AppComponent]
})

export class AppModule { }
