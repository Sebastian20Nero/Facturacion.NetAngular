using System;
using System.Collections.Generic;

namespace factura.Modelos
{
    public partial class Factura
    {
        public Factura()
        {
            Detalles = new HashSet<Detalle>();
        }

        public int Idfactura { get; set; }
        public int Idcliente { get; set; }
        public string Modopago { get; set; } = null!;
        public DateTime Fecharegistro { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; } = null!;
        public virtual ICollection<Detalle> Detalles { get; set; }
    }
}
