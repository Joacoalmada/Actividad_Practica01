using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Entidades
{
    public class Factura
    {
        public int Id_Factura { get; set; }
        public string Cliente { get; set; }
        public FormaPago FormaPago { get; set; }
        public DateTime Fecha { get; set; }

        public List<Factura> Facturas { get; set; } = new List<Factura>();

        public override string? ToString()
        {
            return "Factura:"+Id_Factura + "--" + Cliente +  "--"+ Fecha + "--"+ FormaPago;
        }
    }
}
