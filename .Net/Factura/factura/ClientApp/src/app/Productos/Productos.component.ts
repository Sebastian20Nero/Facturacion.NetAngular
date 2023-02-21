import { Component, OnInit, ViewChild, TemplateRef} from '@angular/core';
import { Producto } from '../configuration/modelos/producto';
import { ProductoService } from '../configuration/services/producto.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-Productos-component',
  templateUrl: './Productos.component.html'
})

export class ProductoComponent implements OnInit {

 
  public listaProductos!: any[];
  resultadoPeticion!: string;
  @ViewChild("myModalInfo", { static: false }) myModalInfo!: TemplateRef<any>;
   
  constructor(private servicioProducto: ProductoService, private modalService: NgbModal ) {
    
  }
  
  ngOnInit(): void {
    this.dameProductos();
  }
 
  dameProductos() {
    this.servicioProducto.dameProductos().subscribe(res => {
      this.listaProductos = res.objetoGenerico;
    });
  }

  cambiarProducto(idproducto: number, indice: number)
  {
    let producto: Producto =
    {
      idproducto: idproducto,
      producto: (<HTMLInputElement>document.getElementById("txtproducto_" + indice)).value,
      precio: parseFloat((<HTMLInputElement>document.getElementById("txtprecio_" + indice)).value),
      stock: parseInt((<HTMLInputElement>document.getElementById("txtstock_" + indice)).value)
      
    };

    this.servicioProducto.modificarProducto(producto).subscribe(res =>
      {
       if (res.error != null && res.error != '')
         this.resultadoPeticion = res.texto;
       else
         this.resultadoPeticion = "Producto modificado con exito";
        
     });  
     //this.modalService.open(this.myModalInfo); //Validacion
  }
  
  eliminarProducto(indice: number){
    
    this.servicioProducto.bajaProducto(indice).subscribe(res =>
      {
       if (res.error != null && res.error != ''){
        console.log(res);
        this.resultadoPeticion = res.texto;
       }else
         this.resultadoPeticion = "Producto eliminado con exito";
        
        this.dameProductos();         
         
     });  this.modalService.open(this.myModalInfo);
     
  }
  saldonegativo()
  {
     let filtronegativo = this.listaProductos.filter(res => res.stock <= 10)
     this.listaProductos = filtronegativo;
     console.log(filtronegativo)
  }
}
