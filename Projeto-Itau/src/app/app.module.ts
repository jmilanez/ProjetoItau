import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { APP_BASE_HREF, registerLocaleData } from '@angular/common';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

import { DashboardComponent } from './dashboard/dashboard.component';
import { ContasReceberComponent } from './contas/contas-receber/contas-receber.component';
import { ContasPagarComponent } from './contas/contas-pagar/contas-pagar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import localePt from '@angular/common/locales/pt';
import { ContaReceberService } from './contas/contas-receber/conta-receber.service';
import { ContaPagarService } from './contas/contas-pagar/conta-pagar.service';
registerLocaleData(localePt);


@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    ContasReceberComponent,
    ContasPagarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxPaginationModule,
    Ng2SearchPipeModule
  ],
  providers: [ContaReceberService, ContaPagarService, {provide: APP_BASE_HREF, useValue: '/'}],
  bootstrap: [AppComponent]
})
export class AppModule { }
