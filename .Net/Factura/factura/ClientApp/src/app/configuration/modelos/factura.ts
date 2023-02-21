import { Detalles } from "./detalles";

export interface Factura {
  idcliente: number;
  Modopago: string;
  detalles?: Detalles[]
}
