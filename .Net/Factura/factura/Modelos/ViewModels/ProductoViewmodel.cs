namespace factura.Modelos.ViewModels
{
    public class ProductoViewmodel
    {
        public int idproducto { get; set; }
        public string producto { get; set; } = null!;
        public int precio { get; set; }
        public int stock{ get; set; }
    }
}
