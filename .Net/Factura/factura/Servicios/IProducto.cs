using factura.Modelos.ViewModels;
using factura.Modelos;

namespace factura.Servicios
{
    public interface IProducto
    {
        public List<Producto> DameProducto();
        public void AgregarProducto(ProductoViewmodel c);
        public void EditarProducto(ProductoViewmodel c);
        public void BorrarProducto(int Idproducto);
    }
}
