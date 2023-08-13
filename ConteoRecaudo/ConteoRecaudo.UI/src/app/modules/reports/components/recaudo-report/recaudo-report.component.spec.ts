import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecaudoReportComponent } from './recaudo-report.component';

describe('RecaudoReportComponent', () => {
  let component: RecaudoReportComponent;
  let fixture: ComponentFixture<RecaudoReportComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RecaudoReportComponent]
    });
    fixture = TestBed.createComponent(RecaudoReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
