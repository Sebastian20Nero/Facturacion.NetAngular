import { Component, Input, OnInit, ViewChild, TemplateRef} from '@angular/core';
import { Producto } from '../../configuration/modelos/producto';
import { ProductoService } from '../../configuration/services/producto.service';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-formproducto-component',
  templateUrl: './formproducto.component.html'
})


export class FormProductoComponent implements OnInit {

  altaForm!: FormGroup;
  enviado = false;
  resultadoPeticion!: string;
  @ViewChild("myModalInfo", { static: false }) myModalInfo!: TemplateRef<any>;
  


  constructor(private servicioProducto: ProductoService, private formBuilder: FormBuilder,
    private modalService: NgbModal  )
  {
    
  }

  ngOnInit(): void
  {
    this.altaForm = this.formBuilder.group({
      producto: ['', Validators.required],
      precio: '',
      stock:''
    })

  }

  get f(): { [key: string]: AbstractControl } { 
    return this.altaForm.controls;
  }


  public Guardar()
  {
    
    if (this.altaForm.invalid) {
      return;
    }


    let producto: Producto =
    {
      producto: this.altaForm.controls['producto'].value,
      precio: this.altaForm.controls['precio'].value,
      stock: this.altaForm.controls['stock'].value
    };

    this.servicioProducto.agregarProducto(producto).subscribe(res =>
     {
      if (res.error != null && res.error != '')
        this.resultadoPeticion = res.texto;
      else
        this.resultadoPeticion = "Producto guardado con exito";
       
        
        
    });  this.modalService.open(this.myModalInfo);
  }
 

}
