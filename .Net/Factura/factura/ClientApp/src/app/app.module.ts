import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ClienteComponent } from './cliente/cliente.component';
import { FormClienteComponent } from './cliente/formcliente/formcliente.component';
import { ProductoComponent } from './Productos/Productos.component';
import { FormProductoComponent } from './Productos/formproducto/formproducto.component';
import { FacturaComponent } from './factura/factura.component';
import { CompraComponent } from './compra/compra.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap'

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ClienteComponent,
    ProductoComponent,
    FacturaComponent,
    FormClienteComponent,
    FormProductoComponent,
    CompraComponent
  ],//NERO routes
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule, 
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    RouterModule.forRoot([
      { path: '', component: ProductoComponent, pathMatch: 'full' },
      { path: 'cliente', component: ClienteComponent },
      { path: 'formcliente', component: FormClienteComponent },
      { path: 'Productos', component: ProductoComponent },
      { path: 'formproducto', component: FormProductoComponent }, 
      { path: 'facturacompra', component: CompraComponent }, 
      { path: 'factura/:id', component: FacturaComponent }, 
    ])
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
