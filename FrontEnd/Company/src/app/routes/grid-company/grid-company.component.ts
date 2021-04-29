import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CompanyModel } from '../../shared/models/company.model';

@Component({
  selector: 'app-grid-company',
  templateUrl: './grid-company.component.html',
  styleUrls: ['./grid-company.component.css']
})
export class GridCompanyComponent implements OnInit {

  @Output() recordDeleted = new EventEmitter<any>();
  @Output() newClicked = new EventEmitter<any>();
  @Output() editClicked = new EventEmitter<any>();
  @Input() companyData: Array<any>;


  ngOnInit(): void {
    
  }

  public deleteRecord(record) {
    this.recordDeleted.emit(record);
  }

  public editRecord(record) {
    console.log('edit record grid', record);
    const clonedRecord = Object.assign({}, record);
    console.log('ccloned', clonedRecord);
    this.editClicked.emit(clonedRecord);

  }

  public newRecord() {
    this.newClicked.emit();
  }
}
