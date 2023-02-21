import { Component, OnInit } from '@angular/core';
import 'devextreme/data/odata/store';
import { ClienteService } from 'src/app/configuration/services/cliente.service';
import notify from "devextreme/ui/notify";

@Component({
  templateUrl: 'clientes.component.html'
})

export class ClientesComponent implements OnInit
{
  public listaclientes!: any[];    
  
  /**Codigo anterior */
  dataSource: any;
  events: Array<string> = [];
  constructor(private api:ClienteService) {
    
    /* Codigo anterior */
    
  }

  ngOnInit(): void {
    this.dameClientes();
  }

  dameClientes() {
    this.api.dameclientes().subscribe(res => {
      this.listaclientes = res.objetoGenerico;
      this.dataSource = {
        store: this.listaclientes
      };
    });
  }
  EventGuardar(){
    console.log("ok")
  }
  confirmarGuardar(){
  }
  
}
