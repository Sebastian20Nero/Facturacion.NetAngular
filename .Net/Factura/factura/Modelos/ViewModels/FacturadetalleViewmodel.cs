namespace factura.Modelos.ViewModels
{
    public class FacturadetalleViewmodel
    {
        public int idfactura { get; set; }
        public int idcliente { get; set; }
        public string nombre { get; set; } = null!;
        public string modopago { get; set; } = null!;
        public DateTime fecharegistro { get; set; }
        public List<DetalleproductoViewmodel> detallesproducto { get; set; }

        public FacturadetalleViewmodel()
        {
            this.detallesproducto = new List<DetalleproductoViewmodel>();
        }


    }
    public class DetalleproductoViewmodel
    {
        public int cantidad { get; set; }
        public string producto { get; set; } = null!;
        public decimal precio { get; set; }
        public int stock { get; set; }

    }
}
