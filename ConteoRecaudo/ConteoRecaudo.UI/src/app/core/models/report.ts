import { RecaudoReport } from './recaudoReport';

export class Report {
  totalValor: number;
  totalCantidad: number;
  sPRecaudoYearReport: RecaudoReport[];

  constructor(
    totalValor: number,
    totalCantidad: number,
    sPRecaudoYearReport: RecaudoReport[]
  ) {
    this.totalValor = totalValor;
    this.totalCantidad = totalCantidad;
    this.sPRecaudoYearReport = sPRecaudoYearReport;
  }

}
