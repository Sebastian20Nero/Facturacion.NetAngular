import { Component, Input, OnInit, ViewChild, TemplateRef} from '@angular/core';
import { FacturaService } from '../configuration/services/factura.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute,Router} from '@angular/router'

@Component({ 
  selector: 'app-factura-component',
  templateUrl: './factura.component.html'
})


export class FacturaComponent implements OnInit {

  public listaFactura!: any[];
  resultadoPeticion!: string;
  @ViewChild("myModalInfo", { static: false }) myModalInfo!: TemplateRef<any>;
   
  constructor(private activatedRoute: ActivatedRoute, private servicioFactura: FacturaService,private modalService: NgbModal, private router: Router ) {
    
  }
  
  ngOnInit(){ 
    this.activatedRoute.params.subscribe( params => {
      this.dameFacturas(params['id'] )
    });
  }
 
  dameFacturas(idcliente: number) { 
    this.servicioFactura.damefacturas(idcliente).subscribe(res => {
      this.listaFactura = res.objetoGenerico;
    });
  }
  
}
