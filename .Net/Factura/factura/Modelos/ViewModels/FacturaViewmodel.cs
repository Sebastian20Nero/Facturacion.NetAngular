namespace factura.Modelos.ViewModels
{
    public class FacturaViewmodel
    {
        public int idcliente { get; set; }
        public string modopago { get; set; } = null!;
        public DateTime Fecharegistro { get; set; }
        public List<DetalleViewModel> detalles { get;set; }

        public FacturaViewmodel() 
        { 
            this.detalles = new List<DetalleViewModel>();
        }


    }
    public class DetalleViewModel
    {
        public int idproducto { get; set; }
        public int cantidad { get; set; }
    }
}
