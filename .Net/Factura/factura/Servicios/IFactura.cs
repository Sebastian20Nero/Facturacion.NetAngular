using factura.Modelos.ViewModels;
using factura.Modelos;

namespace factura.Servicios
{
    public interface IFactura
    {
        public void Compra(FacturaViewmodel c);
        public List<FacturadetalleViewmodel> DameFactura(int idcliente);
    }
}
