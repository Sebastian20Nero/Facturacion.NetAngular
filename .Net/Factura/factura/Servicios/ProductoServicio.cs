using factura.Modelos.ViewModels;
using factura.Modelos;

namespace factura.Servicios
{
    public class ProductoServicio : IProducto
    {
        private readonly IConfiguration configuration;

        public ProductoServicio(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public List<Producto> DameProducto()
        {
            List<Producto> lista;
            using (facturacionContext basedatos = new facturacionContext())
            {
                lista = basedatos.Productos.ToList();
            }

            return lista;
        }
        public void AgregarProducto(ProductoViewmodel c)
        {
            using (facturacionContext basedatos = new facturacionContext())
            {

                Producto producto = new Producto();
                producto.Producto1 = c.producto;
                producto.Precio = c.precio;
                producto.Stock = c.stock;
                basedatos.Productos.Add(producto);
                basedatos.SaveChanges();
            }
        }
        public void EditarProducto(ProductoViewmodel c)
        {
            using (facturacionContext basedatos = new facturacionContext())
            {

                Producto producto = basedatos.Productos.Single(cli => cli.Idproducto == c.idproducto);
                producto.Producto1 = c.producto;
                producto.Precio = c.precio;
                producto.Stock = c.stock;
                basedatos.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                basedatos.SaveChanges();
            }
        }
        public void BorrarProducto(int Idproducto)
        {

            using (facturacionContext basedatos = new facturacionContext())
            {
                basedatos.Remove((Producto)basedatos.Productos.Single(cli => cli.Idproducto == Idproducto));
                basedatos.SaveChanges();
            }
        }
    }
}
