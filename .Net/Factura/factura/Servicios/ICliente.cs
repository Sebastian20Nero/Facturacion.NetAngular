using factura.Modelos.ViewModels;
using factura.Modelos;

namespace factura.Servicios
{
    public interface ICliente
    {
        public List<Cliente> DameClientes();
        public void AgregarCliente(ClienteViewmodel c);
        public void EditarCliente(ClienteViewmodel c);
        public void BorrarCliente(int Idcliente);
    }
}
