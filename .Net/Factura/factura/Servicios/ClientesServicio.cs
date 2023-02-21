using factura.Modelos.ViewModels;
using factura.Modelos;

namespace factura.Servicios
{
    public class ClientesServicio: ICliente
    {
        private readonly IConfiguration configuration;

        public ClientesServicio(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public List<Cliente> DameClientes()
        {
            List<Cliente> lista;
            using (facturacionContext basedatos = new facturacionContext())
            {
                lista = basedatos.Clientes.ToList();
            }

            return lista;
        }
        public void AgregarCliente(ClienteViewmodel c)
        {
            using (facturacionContext basedatos = new facturacionContext())
            {

                Cliente cliente = new Cliente();
                cliente.Nombre = c.nombre;
                cliente.Fechanacimiento = c.fechaNacimiento;
                basedatos.Clientes.Add(cliente);
                basedatos.SaveChanges();
            }
        }
        public void EditarCliente(ClienteViewmodel c)
        {
            using (facturacionContext basedatos = new facturacionContext())
            {

                Cliente cliente = basedatos.Clientes.Single(cli => cli.Idcliente == c.idcliente);
                cliente.Nombre = c.nombre;
                cliente.Fechanacimiento = c.fechaNacimiento;
                basedatos.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                basedatos.SaveChanges();
            }
        }
        public void BorrarCliente(int Idcliente)
        {

            using (facturacionContext basedatos = new facturacionContext())
            {
                basedatos.Remove((Cliente)basedatos.Clientes.Single(cli => cli.Idcliente == Idcliente));
                basedatos.SaveChanges();
            }
        }

    }
}
