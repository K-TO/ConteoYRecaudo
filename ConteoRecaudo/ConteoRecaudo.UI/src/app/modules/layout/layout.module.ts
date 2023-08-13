import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './components/layout/layout.component';
import { BlankLayoutComponent } from './components/blank-layout/blank-layout.component';
import { RouterModule } from '@angular/router';
import { HomeModule } from '../home/home.module';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [
    LayoutComponent,
    BlankLayoutComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule,
    HomeModule
  ],
  exports: [
    LayoutComponent,
    BlankLayoutComponent
  ]
})

export class LayoutModule { }
