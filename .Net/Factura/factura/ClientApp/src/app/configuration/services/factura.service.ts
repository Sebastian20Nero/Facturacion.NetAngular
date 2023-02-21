import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { Resultado } from '../modelos/resultado';
import { Factura } from '../modelos/factura';
import { map } from 'rxjs/operators';



@Injectable
  ({
    providedIn: 'root'
  })

export class FacturaService
{
  url: string = 'https://localhost:7236/API/factura/';


  constructor(private peticion: HttpClient)
  {

  }

  damefacturas(idcliente: number): Observable<Resultado>
  {
    return this.peticion.get<Resultado>(this.url+ idcliente); 
  }

  agregarfactura(factura: Factura): Observable<Resultado>
  {
    return this.peticion.post<Resultado>(this.url, factura);
  }

}
