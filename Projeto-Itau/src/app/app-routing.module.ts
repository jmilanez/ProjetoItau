import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContasPagarComponent } from './contas/contas-pagar/contas-pagar.component';
import { ContasReceberComponent } from './contas/contas-receber/contas-receber.component';
import { DashboardComponent } from './dashboard/dashboard.component';

const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'contas/contas-pagar', component: ContasPagarComponent },
  { path: 'contas/contas-receber', component: ContasReceberComponent },
  { path: 'dashboard', component: DashboardComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
