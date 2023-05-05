import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/pages/login/login.component';
import { RegisterComponent } from './components/pages/register/register.component';
import { DashboardComponent } from './components/pages/dashboard/dashboard.component';
import { AuthGuard } from 'src/app/shared/guards/auth.guard'
import { ForgotPasswordComponent } from './components/pages/forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './components/pages/reset-password/reset-password.component';

export const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard]},
  {path: '', pathMatch: 'full', redirectTo: 'login'},
  {path: 'forgot-password', component: ForgotPasswordComponent},
  { path: 'reset-password/:email/:resetToken', component: ResetPasswordComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
