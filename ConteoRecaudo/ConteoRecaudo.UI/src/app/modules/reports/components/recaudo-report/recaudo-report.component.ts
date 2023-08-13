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
  loading = true;
  tittle = 'Reporte de recaudo calculado por año.';
  form: FormGroup = new FormGroup({
    anio: new FormControl(''),
    estacion: new FormControl(''),
  });
  submitted = false;

  dtOptions: ADTSettings = {};

  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private reportService: ReportService,
    private formBuilder: FormBuilder,
    ) {
    this.recaudo = [new Recaudo('', 0, '', 0, 0)];
    this.reportData = new Report(0, 0, [
      new RecaudoReport('', 0, 0, this.recaudo),
    ]);
  }

  loadRecaudoReport() {
    return this.reportService
      .getRecaudoReport(2021, '')
      .subscribe((data: Report) => {
        console.log('data');
        console.log(data);
        this.reportData = data;
      });
  }

  ngOnInit() {
    this.loadRecaudoReport();

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

  onSubmit(): void {
    this.submitted = true;
    if (this.form.invalid) {
      return;
    }
    // this.login(this.form.value.username, this.form.value.password);
  }

  ngAfterViewInit() {
    setTimeout(() => {
      this.loading = false;
    }, 0);
  }
}
