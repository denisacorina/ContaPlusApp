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
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { CreateIncomeComponent } from './components/accounting/create-income/create-income.component';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { ClientComponent } from './components/pages/company-info/clients/client.component';
import { SupplierComponent } from './components/pages/company-info/suppliers/suppliers.component';
import { InventoryComponent } from './components/pages/inventory/inventory.component';
import { ExpenseComponent } from './components/accounting/expense/expense.component';
import { CreateExpenseComponent } from './components/accounting/create-expense/create-expense.component';
import { CreateSaleComponent } from './components/accounting/create-sale/create-sale.component';
import { CreatePurchaseComponent } from './components/accounting/create-purchase/create-purchase.component';
import { TeamComponent } from './components/pages/team/team.component';
import { ReportsComponent } from './components/pages/reports/reports.component';





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
    CreateIncomeComponent,
    ClientComponent,
    SupplierComponent,
    InventoryComponent,
    ExpenseComponent,
    CreateExpenseComponent,
    CreateSaleComponent,
    CreatePurchaseComponent,
    TeamComponent,
    ReportsComponent

    

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
    MatInputModule,
    MatSortModule,
    MatPaginatorModule,
    MatTableModule,
    MatCheckboxModule,
    MatButtonModule,
    MatMenuModule,
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
