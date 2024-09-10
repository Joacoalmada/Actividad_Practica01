using Problema_1._5.Datos.Utilidades;
using Problema_1._5.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._5.Datos
{
    internal class ArticuloRepositorioDAO : IArticuloRepositorio
    {

        public bool add(Articulo articulo)
        {
            var parametros = new List<ParametrosSQL>
            {
                 new ParametrosSQL("id_articulo",articulo.Id_Articulo),
                 new ParametrosSQL("@Nombre",articulo.Nombre_Art),
                 new ParametrosSQL("@precio",articulo.Precio.ToString())
            };

            int filasAfectadas = DataHelper
                .GetInstance()
                .EjecutarSPDML("Crear_Articulo", parametros);

            return filasAfectadas > 0;
        }

        public List<Articulo> GetAll()
        {
            var articulos = new List<Articulo>();
            DataTable dt = DataHelper.GetInstance().EjecutarPA("Obtener_Articulos");
            if (dt != null)
            {
                foreach (DataRow filas in dt.Rows)
                {
                    Articulo articulo = new Articulo
                    {
                        Id_Articulo = Convert.ToInt32(filas["id_articulo"]),
                        Nombre_Art = filas["Nombre"].ToString(),
                        Precio = Convert.ToDouble(filas["precio"]),


                    };
                    articulos.Add(articulo);
                }
            }
            return articulos;
        }
    }
}
