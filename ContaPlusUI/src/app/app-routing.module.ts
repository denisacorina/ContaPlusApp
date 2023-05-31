import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/pages/login/login.component';
import { RegisterComponent } from './components/pages/register/register.component';
import { DashboardComponent } from './components/pages/dashboard/dashboard.component';
import { AuthGuard } from 'src/app/shared/guards/auth.guard'
import { ForgotPasswordComponent } from './components/pages/forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './components/pages/reset-password/reset-password.component';
import { UserProfileComponent } from './components/pages/user-profile/user-profile.component';
import { IncomeComponent } from './components/accounting/income/income.component';
import { CreateIncomeComponent } from './components/accounting/create-income/create-income.component';
import { ClientComponent } from './components/pages/company-info/clients/client.component';
import { SupplierComponent } from './components/pages/company-info/suppliers/suppliers.component';
import { InventoryComponent } from './components/pages/inventory/inventory.component';

export const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard]},
  {path: '', pathMatch: 'full', redirectTo: 'login'},
  {path: 'forgot-password', component: ForgotPasswordComponent},
  {path: 'reset-password/:email/:resetToken', component: ResetPasswordComponent },
  {path: 'myProfile', component: UserProfileComponent},
  {path: 'income', component: IncomeComponent},
  {path: 'income/addIncomeTransaction', component: CreateIncomeComponent},
  {path: 'income/allIncomes', component: IncomeComponent},
  {path: 'company/clients', component: ClientComponent},
  {path: 'company/suppliers', component: SupplierComponent},
  {path: 'inventory', component: InventoryComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
