using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._5.Datos.Utilidades
{
    public class ParametrosSQL
    {
        public ParametrosSQL(string nombre, object value)
        {
            Nombre = nombre;
            Value = value;
        }
        public string Nombre
        {
            get; set; 
        }
        public object Value
        {
            get; set;
        }
    }
}
