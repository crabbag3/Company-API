import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GridCompanyComponent } from './grid-company.component';

describe('GridCompanyComponent', () => {
  let component: GridCompanyComponent;
  let fixture: ComponentFixture<GridCompanyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GridCompanyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GridCompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
