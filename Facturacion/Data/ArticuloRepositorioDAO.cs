using Facturacion.Data;
using Facturacion.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Data
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

        public bool Delete(int id)
        {
            var parameters = new List<ParametrosSQL>();
            parameters.Add(new ParametrosSQL("@id_articulo", id));
            int rows = DataHelper.GetInstance().EjecutarSPDML("borrar_articulo", parameters);
            return rows == 1;
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
