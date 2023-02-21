import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Cliente } from './configuration/modelos/cliente';
import { ClienteService } from './configuration/services/cliente.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
 
}
