using System;
using System.Collections.Generic;

namespace factura.Modelos
{
    public partial class Detalle
    {
        public int Numdetalle { get; set; }
        public int Idfactura { get; set; }
        public int Idproducto { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecharegistro { get; set; }

        public virtual Factura IdfacturaNavigation { get; set; } = null!;
        public virtual Producto IdproductoNavigation { get; set; } = null!;
    }
}
