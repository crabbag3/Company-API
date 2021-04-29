import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import {
  OKTA_CONFIG,
  OktaAuthGuard,
  OktaAuthModule,
  OktaCallbackComponent,
} from '@okta/okta-angular';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full',  },
  {
    path: 'login/callback',
    component: OktaCallbackComponent},
  ]
 // { path: 'implicit/callback', component: OktaCallbackComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
