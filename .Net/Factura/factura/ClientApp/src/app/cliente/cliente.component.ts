import { Component, Input, OnInit, ViewChild, TemplateRef} from '@angular/core';
import { Cliente } from '../configuration/modelos/cliente';
import { ClienteService } from '../configuration/services/cliente.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {Router} from '@angular/router'

@Component({ 
  selector: 'app-cliente-component',
  templateUrl: './cliente.component.html'
})


export class ClienteComponent implements OnInit {

  public listaCliente!: any[];
  resultadoPeticion!: string;
  @ViewChild("myModalInfo", { static: false }) myModalInfo!: TemplateRef<any>;
   
  constructor(private servicioCliente: ClienteService,private modalService: NgbModal, private router: Router ) {
    
  }
  
  ngOnInit(): void {
    this.dameClientes();
  }
 
  dameClientes() {
    this.servicioCliente.dameclientes().subscribe(res => {
      this.listaCliente = res.objetoGenerico;
    });
  }

  cambiarProducto(idcliente: number, indice: number)
  {
    
    const date = new Date((<HTMLInputElement>document.getElementById("txtfecha_" + indice)).value);
    let cliente: Cliente =
    {
      idcliente: idcliente,
      nombre: (<HTMLInputElement>document.getElementById("txtnombre_" + indice)).value,
      fechanacimiento: date
    };

    this.servicioCliente.modificarCliente(cliente).subscribe(res =>
      {
       if (res.error != null && res.error != '')
         this.resultadoPeticion = res.texto;
       else
         this.resultadoPeticion = "Cliente modificado con exito";
     });  
     //this.modalService.open(this.myModalInfo); //Validacion
  }
  
  eliminarProducto(indice: number){
    
    this.servicioCliente.bajaCliente(indice).subscribe(res =>
      {
       if (res.error != null && res.error != '')
         this.resultadoPeticion = res.texto;
       else
         this.resultadoPeticion = "Cliente eliminado con exito";
        
        this.dameClientes();         
         
     });  this.modalService.open(this.myModalInfo);
     
  }

  FacturaCliente(indice: number){
    this.router.navigate(['/factura/',indice]); 
  } 
  
}
