import { Component, OnInit } from '@angular/core';
import { CompanyModel } from '../../shared/models/company.model';
import { CompanyDataService } from '../../core/data-services/company-data.service';
import * as _ from 'lodash';
import { OktaAuthService } from '@okta/okta-angular';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public companyData: Array<any>
  public currentCompany: any;
  public errors: any;
  public error: any;
  public isAuthenticated: boolean;
  public userName: string;

  constructor(private companyDataService: CompanyDataService, public oktaAuth: OktaAuthService, ) {
   
    // get authentication state for immediate use
    this.oktaAuth.isAuthenticated().then(result => {
      this.isAuthenticated = result;
    });

    // subscribe to authentication state changes
    this.oktaAuth.$authenticationState.subscribe(
      (isAuthenticated: boolean) => this.isAuthenticated = isAuthenticated
    );
    this.companyData = [];
    this.errors = "";
    this.currentCompany = this.setInitialValuesForCompanyData();
  //  oktaAuth.signInWithRedirect();
   
  }

  async ngOnInit() {
    this.loadData();
    this.isAuthenticated = await this.oktaAuth.isAuthenticated();
    if (this.isAuthenticated) {
      const userClaims = await this.oktaAuth.getUser();
      this.userName = userClaims.name;
    }
  }

  public loadData(): void {
    
    this.companyDataService.getAll().subscribe((data: any) => this.companyData = data)
  }

  private setInitialValuesForCompanyData() {
    return {
      id: undefined,
      name: '',
      exchange: "",
      ticker: "",
      isin: "",
      website: ""
    }
  }
  async login() {
    console.log('starting to log in');
    try {
       await this.oktaAuth.signInWithRedirect().catch(err => { console.log("error", err)});
    } catch (err) {
      console.error(err);
      this.error = err;
    }
  }

  async logout() {
    console.log('starting to log in');
    try {
      await this.oktaAuth.signOut().catch(err => { console.log("error", err) });
    } catch (err) {
      console.error(err);
      this.error = err;
    }
  }

  public createOrUpdateCompany = function (company: any) {
    // if company id is present in companyData, we can assume this is an update
    // otherwise it is adding a new element
    let companyWithId;
    companyWithId = _.find(this.companyData, (el => el.isin === company.isin));

    if (companyWithId) {
      const updateIndex = _.findIndex(this.companyData, { id: companyWithId.id });
      this.companyDataService.update(company).subscribe(
        () => this.companyData.splice(updateIndex, 1, company)
      );
    } else {
      this.companyDataService.add(company).subscribe(
        () => this.companyData.push(company),
        err => {
          this.errors = err.error;
          console.log('error');
          console.log(this.errors);
        }
      );
    }

    this.currentJogging = this.setInitialValuesForCompanyData();
  };

  public editClicked = function (record) {
    this.currentCompany = record;
  };

  public newClicked = function () {
    this.currentJogging = this.setInitialValuesForJoggingData();
  };

  public deleteClicked(record) {
    const deleteIndex = _.findIndex(this.companyData, { id: record.id });
    this.companyDataService.remove(record).subscribe(
      result => this.companyData.splice(deleteIndex, 1)
    );
  }
}
