using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._5.Dominio
{
    public class Articulo
    {
        public int Id_Articulo { get; set; }
        public string Nombre_Art {  get; set; }
        public double Precio { get; set; }

        public List<Articulo> Articulos { get; set; } = new List<Articulo>();
        public override string ToString()
        {
            return "El ID del Articulo es: " + Id_Articulo + " - El nombre del Articulo es: " + Nombre_Art + " - El precio unitario del Articulo es: " + Precio;
        }

    }
}
