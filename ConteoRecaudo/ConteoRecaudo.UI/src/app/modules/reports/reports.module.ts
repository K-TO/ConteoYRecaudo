import { NgModule } from '@angular/core';
import { CommonModule, DecimalPipe } from '@angular/common';
import { RecaudoReportComponent } from './components/recaudo-report/recaudo-report.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReportsRoutingModule } from './reports-routing.module';
import { DataTablesModule } from 'angular-datatables';
import { HttpClientModule } from '@angular/common/http';
import { ReportService } from 'src/app/core/services/report.service';

@NgModule({
  declarations: [
    RecaudoReportComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReportsRoutingModule,
    DataTablesModule,
    HttpClientModule
  ],
  exports: [
    RecaudoReportComponent
  ],
  providers: [
    ReportService,
    DecimalPipe    
  ]
})
export class ReportsModule { }
