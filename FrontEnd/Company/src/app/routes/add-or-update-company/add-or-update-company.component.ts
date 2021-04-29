import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { CompanyModel } from '../../shared/models/company.model';

 

@Component({
  selector: 'app-add-or-update-company',
  templateUrl: './add-or-update-company.component.html',
  styleUrls: ['./add-or-update-company.component.css']
})
export class AddOrUpdateCompanyComponent implements OnInit {
  @Output() companyCreated = new EventEmitter<any>();
  @Input() companyInfo: any;

  public buttonText = 'Save';

  constructor(
    
  ) {
    this.clearCompanyInfo();

  }

  ngOnInit() {


  }

  private clearCompanyInfo = function () {
    // Create an empty jogging object
    this.companyInfo =  {
      id: undefined,
      name: "",
      exchange: "",
      isin: "",
      website: ""
    };
  };

  public addOrUpdateCompanyRecord = function (event) {
    this.companyCreated.emit(this.companyInfo);
    this.clearCompanyInfo();
  };

}
