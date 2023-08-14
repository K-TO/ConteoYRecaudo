import { Component, OnInit } from '@angular/core';
import { ReportService } from 'src/app/core/services/report.service';
import { Subject } from 'rxjs';
import { ADTSettings } from 'angular-datatables/src/models/settings';
import { Report } from 'src/app/core/models/report';
import { RecaudoReport } from 'src/app/core/models/recaudoReport';
import { Recaudo } from 'src/app/core/models/recaudo';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-recaudo-report',
  templateUrl: './recaudo-report.component.html',
  styleUrls: ['./recaudo-report.component.css'],
})

export class RecaudoReportComponent implements OnInit {
  reportData: Report;
  recaudo: Recaudo[];
  filterYears: number[];
  loading = true;
  form: FormGroup = new FormGroup({
    anio: new FormControl(''),
    estacion: new FormControl(''),
  });
  submitted = false;
  selectedYear: number = 2021;
  tittle = `Reporte de recaudo calculado por año. (${this.selectedYear}).`;

  dtOptions: ADTSettings = {};

  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private reportService: ReportService,
    private formBuilder: FormBuilder,
    ) {
    this.recaudo = [new Recaudo('', 0, '', 0, 0)];
    this.reportData = new Report(0, 0, [
      new RecaudoReport('', 0, 0, this.recaudo),
    ]);
    this.filterYears = [];
  }

  loadRecaudoReport(anio: number, estacion: string) {
    return this.reportService
      .getRecaudoReport(anio, estacion)
      .subscribe((data: Report) => {
        this.reportData = data;
      });
  }

  loadFilterYear(){
    for(let i = 0; i < 10; i++) {
      this.filterYears.push((new Date()).getFullYear() - i);
    }
  }

  ngOnInit() {
    this.loadRecaudoReport(2021, '');
    this.loadFilterYear();
    this.form = this.formBuilder.group({
      anio: [
        '',
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(4),
        ],
      ],
      estacion: [
        '',
        [
          Validators.minLength(4),
          Validators.maxLength(50),
        ],
      ],
    });

    this.loading = false;
  }

  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }

  filter(): void {
    this.submitted = true;
    console.log(`filtrando => ${this.form.value.anio}, ${this.form.value.estacion}`)
    if (this.form.invalid) {
      return;
    } else{
      this.loadRecaudoReport(this.form.value.anio, this.form.value.estacion)
    }
  }

  ngAfterViewInit() {
    setTimeout(() => {
      this.loading = false;
    }, 0);
  }
}
