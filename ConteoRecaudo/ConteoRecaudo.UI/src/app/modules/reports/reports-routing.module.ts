import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecaudoReportComponent } from './components/recaudo-report/recaudo-report.component';

const routes: Routes = [
    {
      path: 'recaudo',
      component: RecaudoReportComponent,
      children: [
        {
          path:'recaudo',
          component: RecaudoReportComponent
        }
      ]
    }
  ]; 

  @NgModule({
    imports: [
      RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
  })

  export class ReportsRoutingModule {}