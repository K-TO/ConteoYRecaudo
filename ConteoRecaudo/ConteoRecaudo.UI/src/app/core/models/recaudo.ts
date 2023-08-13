export class Recaudo {
    estacion: string;
    anio: number;
    mes: string;
    cantidad: number;
    valor: number;

    constructor(estacion: string, anio: number, mes: string, cantidad: number, valor: number) {
        this.estacion = estacion;
        this.anio = anio;
        this.mes = mes;
        this.cantidad = cantidad;
        this.valor = valor;
    }
}

