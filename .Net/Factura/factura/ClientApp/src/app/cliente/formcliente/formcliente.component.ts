import { Component, Input, OnInit, ViewChild, TemplateRef} from '@angular/core';
import { Cliente } from '../../configuration/modelos/cliente';
import { ClienteService } from '../../configuration/services/cliente.service';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-formcliente-component',
  templateUrl: './formcliente.component.html'
})


export class FormClienteComponent implements OnInit {

  altaForm!: FormGroup;
  enviado = false;
  resultadoPeticion!: string;
  @ViewChild("myModalInfo", { static: false }) myModalInfo!: TemplateRef<any>;
  


  constructor(private servicioCliente: ClienteService, private formBuilder: FormBuilder,
    private modalService: NgbModal  )
  {
    
  }

  ngOnInit(): void
  {
    this.altaForm = this.formBuilder.group({
      nombre: ['', Validators.required],
      fechanacimiento: ''
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


    let cliente: Cliente =
    {
      nombre: this.altaForm.controls['nombre'].value,
      fechanacimiento: this.altaForm.controls['fechanacimiento'].value
    };

    this.servicioCliente.agregarCliente(cliente).subscribe(res =>
     {
      if (res.error != null && res.error != '')
        this.resultadoPeticion = res.texto;
      else
        this.resultadoPeticion = "Cliente guardado con exito";
       
        
        
    });  this.modalService.open(this.myModalInfo);
  }
 

}
