import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Cliente } from '../configuration/modelos/cliente';
import { ClienteService } from '../configuration/services/cliente.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  cliente!: Cliente;
  logado!: boolean;

  constructor(public servicioCliente: ClienteService,private router:Router)
  {
    
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

}
