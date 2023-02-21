import { Component, OnInit, ViewChild, TemplateRef} from '@angular/core';
import { ProductoService } from '../configuration/services/producto.service';
import { ClienteService } from '../configuration/services/cliente.service';
import { FacturaService } from '../configuration/services/factura.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {Router} from '@angular/router'

import { Factura } from '../configuration/modelos/factura';
import { Detalles } from '../configuration/modelos/detalles';
@Component({
  selector: 'app-compra-component',
  templateUrl: './compra.component.html'
})

export class CompraComponent implements OnInit {

  pedido!: Factura;
  lineasPedido!: Detalles[];
  public listaProductos!: any[];
  public listaCliente!: any[];
  resultadoPeticion!: string;
  opcionSeleccionado: string  = '0';

  @ViewChild("myModalInfo", { static: false }) myModalInfo!: TemplateRef<any>;
   
  constructor(private serviciofactura: FacturaService,private servicioProducto: ProductoService,private servicioCliente: ClienteService, private modalService: NgbModal, private router: Router ) {
    
  }
  
  ngOnInit(): void {
    this.dameProductos();
    this.dameClientes();
  }
 
  dameProductos() {
    this.servicioProducto.dameProductos().subscribe(res => {
      this.listaProductos = res.objetoGenerico;
    });
  }
  
  dameClientes() {
    this.servicioCliente.dameclientes().subscribe(res => {
      this.listaCliente = res.objetoGenerico;
    });
  }

  agregarfactura(indice: number, cantidad: number) {
    let modo =  (<HTMLInputElement>document.getElementById("txtmodo")).value;
    let cant = Number((<HTMLInputElement>document.getElementById("txtstock_" + indice)).value);
    let idc=Number(this.opcionSeleccionado)

    if(cantidad-cant<=5){
      this.resultadoPeticion = "No se pueden solicitar productos cuyo valor en el inventario es menor a 5";
      this.modalService.open(this.myModalInfo);
      return
    }
    if (typeof this.pedido == "undefined") {
      this.lineasPedido = [];
      let lineaPedido: Detalles;
      lineaPedido = { Idproducto: this.listaProductos[indice].idproducto, Cantidad: Number(cant)};
      this.lineasPedido.push(lineaPedido);
    }
    else
    {
      let lineaPedido: Detalles;
      this.lineasPedido.forEach(e => {
        if(this.listaProductos[indice].idproducto==e.Idproducto){
          e.Cantidad=0;
        }
      });
      lineaPedido = { Idproducto: this.listaProductos[indice].idproducto, Cantidad: Number(cant) }
      this.lineasPedido.push(lineaPedido);
    }

    this.pedido = { idcliente:idc, Modopago: modo, detalles: this.lineasPedido };
    console.log(this.pedido);
  }

  generarfactura()
  {
    let modo =  (<HTMLInputElement>document.getElementById("txtmodo")).value;
    let idc=Number(this.opcionSeleccionado)
    this.pedido = { idcliente:idc, Modopago: modo, detalles: this.lineasPedido };
    console.log(this.pedido)
    this.serviciofactura.agregarfactura(this.pedido).subscribe(res =>
      {
       if (res.error != null && res.error != '')
         this.resultadoPeticion = res.texto;
       else
         this.resultadoPeticion = "Factura Generada con exito";
     });
     this.modalService.open(this.myModalInfo);
     this.router.navigate(['/factura/',idc]);
  }

}
