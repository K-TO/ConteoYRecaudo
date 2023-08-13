import { Recaudo } from "./recaudo";

export class RecaudoReport {
  estacion: string;
  subTotalValor: number;
  subTotalCantidad: number;
  values: Recaudo[];

  constructor(estacion: string, subTotalValor: number, subTotalCantidad: number,values: Recaudo[]) {
    this.estacion = estacion;
    this.subTotalCantidad = subTotalCantidad;
    this.subTotalValor = subTotalValor;
    this.values = values;
  }
}
