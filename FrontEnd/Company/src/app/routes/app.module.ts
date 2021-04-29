import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './home/home.component';
import { GridCompanyComponent } from './grid-company/grid-company.component';
import { AppComponent } from '../app.component';
import { CompanyDataService } from '../core/data-services/company-data.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AddOrUpdateCompanyComponent } from './add-or-update-company/add-or-update-company.component';
import { FormsModule } from '@angular/forms';
AuthInterceptor
HTTP_INTERCEPTORS

import {
  OktaAuthModule,
  OktaCallbackComponent,
  OKTA_CONFIG,
  
} from '@okta/okta-angular';
import { AuthInterceptor } from '../core/net/auth.interceptor';


// TODO: Change to config file
//const config = {
//  issuer: 'https://dev-95983139.okta.com/oauth2/default',
//  redirectUri: 'http://localhost:4200/implicit/callback',
//  clientId: '0oany2v0qdU2q1g8m5d6',
//  scopes: ['openid', 'profile', 'email'],
//};

const config = {
  clientId: '0oany2v0qdU2q1g8m5d6',
  issuer: 'https://dev-95983139.okta.com/oauth2/default',
  redirectUri: '/login/callback',
  scopes: ['openid', 'profile', 'email'],
  pkce: true
};

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GridCompanyComponent,
    AddOrUpdateCompanyComponent,

    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    OktaAuthModule
    
  ],
  providers: [CompanyDataService,
   
    { provide: OKTA_CONFIG, useValue: config },
 //   {  //provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    //{ provide: config, useValue: config}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
