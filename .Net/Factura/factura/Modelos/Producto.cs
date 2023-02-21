using System;
using System.Collections.Generic;

namespace factura.Modelos
{
    public partial class Producto
    {
        public Producto()
        {
            Detalles = new HashSet<Detalle>();
        }

        public int Idproducto { get; set; }
        public string Producto1 { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public virtual ICollection<Detalle> Detalles { get; set; }
    }
}
