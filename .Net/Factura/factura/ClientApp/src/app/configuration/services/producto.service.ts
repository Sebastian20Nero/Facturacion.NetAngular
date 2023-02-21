import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Resultado } from '../modelos/resultado';
import { Producto } from '../modelos/producto';

@Injectable
  ({
    providedIn: 'root'
  })

export class ProductoService {

  url: string = 'https://localhost:7236/API/Productos/';
  
  constructor(private peticion: HttpClient) {

  }

  dameProductos(): Observable<Resultado> {
    
    return this.peticion.get<Resultado>(this.url);
  }

  agregarProducto(producto: Producto): Observable<Resultado>
  {
    return this.peticion.post<Resultado>(this.url, producto);
  }

  modificarProducto(producto: Producto): Observable<Resultado> {
    return this.peticion.put<Resultado>(this.url, producto);
  }

  bajaProducto(idproducto: number): Observable<Resultado> {
    return this.peticion.delete<Resultado>(this.url + idproducto);
  }

}
