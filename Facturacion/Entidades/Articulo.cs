using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Entidades
{
    public class Articulo
    {
        public int Id_Articulo { get; set; }
        public string Nombre_Art {  get; set; }
        public double Precio { get; set; }

        public Articulo(int id , string nombre , double precio) 
        {
            Id_Articulo = id;
            Nombre_Art = nombre;
            Precio = precio;
        }

        public Articulo() 
        {
            Id_Articulo = 0;
            Nombre_Art = "";
            Precio =0;
        }

    }
}
