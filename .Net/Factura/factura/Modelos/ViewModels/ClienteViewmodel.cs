namespace factura.Modelos.ViewModels
{
    public class ClienteViewmodel
    {
        public int idcliente { get; set; }
        public string nombre { get; set; } = null!;
        public DateTime fechaNacimiento { get; set; }
    }
}
