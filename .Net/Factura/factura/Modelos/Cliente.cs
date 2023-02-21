using System;
using System.Collections.Generic;

namespace factura.Modelos
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public int Idcliente { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime Fechanacimiento { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
