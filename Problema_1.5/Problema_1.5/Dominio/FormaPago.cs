using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._5.Dominio
{
    public class FormaPago
    {
        public int Id_FormaPago { get; set; }
        public string TipoPago { get; set; }

        public override string ToString()
        {
            return "- ID de forma de pago: " + Id_FormaPago ;
        }
    }

}
