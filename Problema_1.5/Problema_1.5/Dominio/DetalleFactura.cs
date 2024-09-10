using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._5.Dominio
{
    public class DetalleFactura
    {
        public int id_DetalleFactura {  get; set; }
        public int Cantidad { get; set; }
        public Articulo Articulo { get; set; }

        public double PrecioUnitario { get; set; }

        public Factura Factura { get; set; }

    }
}
