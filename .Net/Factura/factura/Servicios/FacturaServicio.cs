using factura.Modelos.ViewModels;
using factura.Modelos;
using Microsoft.EntityFrameworkCore.Storage;

namespace factura.Servicios
{
    public class FacturaServicio: IFactura
    {
        private readonly IConfiguration configuration;

        public FacturaServicio(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Compra(FacturaViewmodel c)
        {
            using (facturacionContext basedatos = new facturacionContext())
            {
                {
                    Factura factura = new Factura
                    {
                        Idcliente = c.idcliente,
                        Modopago = c.modopago,
                        Fecharegistro = DateTime.Now
                    };
                    basedatos.Facturas.Add(factura);
                    basedatos.SaveChanges();

                    foreach (var e in c.detalles)
                    {
                        Detalle detalle = new Detalle
                        {
                            Idproducto = e.idproducto,
                            Cantidad = e.cantidad,
                            Fecharegistro = DateTime.Now,
                            Idfactura = factura.Idfactura
                        };
                        if (detalle.Cantidad != 0) 
                        basedatos.Detalles.Add(detalle);
                        basedatos.SaveChanges();
                        Descontar(e.cantidad, e.idproducto);
                    };
                }
                
            }
        }

        public void Descontar(int desc, int idproducto)
        {
            using (facturacionContext basedatos = new facturacionContext())
            {

                Producto producto = basedatos.Productos.Single(prod => prod.Idproducto== idproducto);
                producto.Stock = producto.Stock-desc;
                basedatos.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                basedatos.SaveChanges();
            }
        }

        public List<FacturadetalleViewmodel> DameFactura(int idcliente)
        {
            List<FacturadetalleViewmodel> lista = new List<FacturadetalleViewmodel>();

            using (facturacionContext basedatos = new facturacionContext())
            {
                var cliente = basedatos.Clientes.Single(cli => cli.Idcliente == idcliente);
                
                List<Factura> facturasCliente =(from f in basedatos.Facturas where 
                                        f.Idcliente == cliente.Idcliente
                                        select f).ToList();
                foreach (Factura f in facturasCliente) {
                    FacturadetalleViewmodel auxfactura = new FacturadetalleViewmodel();
                    auxfactura.modopago = f.Modopago;
                    auxfactura.idcliente = f.Idcliente;
                    auxfactura.idfactura = f.Idfactura;
                    auxfactura.nombre = cliente.Nombre;
                    auxfactura.fecharegistro = f.Fecharegistro;
                    List<Detalle> listaDetalle = (from d in basedatos.Detalles
                                                  where d.Idfactura==f.Idfactura
                                                  select d).ToList();
                    //lista.Add(auxfactura);
                    foreach (Detalle d in listaDetalle) {
                        DetalleproductoViewmodel deta = new DetalleproductoViewmodel();
                        deta.cantidad = d.Cantidad;
                        var detaux = basedatos.Productos.Single(p => p.Idproducto == d.Idproducto);
                        deta.producto = detaux.Producto1;
                        deta.precio = detaux.Precio;
                        deta.stock = detaux.Stock;
                        auxfactura.detallesproducto.Add(deta);
                    }
                    lista.Add(auxfactura);
                }
            }

            return lista;
        }
    }
}
