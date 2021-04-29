import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddOrUpdateCompanyComponent } from './add-or-update-company.component';

describe('AddOrUpdateCompanyComponent', () => {
  let component: AddOrUpdateCompanyComponent;
  let fixture: ComponentFixture<AddOrUpdateCompanyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddOrUpdateCompanyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddOrUpdateCompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
