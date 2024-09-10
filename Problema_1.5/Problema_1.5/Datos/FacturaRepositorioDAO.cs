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
    internal class FacturaRepositorioDAO : IFacturaRepositorio
    {
        public bool Add(Factura factura)
        {
           var parametro = new List<ParametrosSQL>
           {
                new ParametrosSQL("@id_factura",factura.Id_Factura),
                new ParametrosSQL("@fecha",factura.Fecha == DateTime.MinValue ? DBNull.Value : factura.Fecha),
                new ParametrosSQL("@id_forma_pago",factura.FormaPago.Id_FormaPago),
                new ParametrosSQL("@cliente",factura.Cliente.ToString()),
           };
            int filasAfectadas = DataHelper.GetInstance().EjecutarSPDML("Crear_Factura", parametro);
            return filasAfectadas > 0;

        }

        public List<Factura> GetAll()
        {
            var Factura = new List<Factura>();
            DataTable table = DataHelper.GetInstance().EjecutarPA("Obtener_Facturas");
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    Factura f = new Factura
                    {
                        Id_Factura = Convert.ToInt32(row["id_factura"]),
                        Fecha = Convert.ToDateTime(row["fecha"]),
                        FormaPago = new FormaPago
                        {
                            Id_FormaPago = Convert.ToInt32(row["id_forma_pago"]),
                            

                        },
                        Cliente = Convert.ToString(row["cliente"].ToString())

                    };
                    Factura.Add(f);
                }
            }
            return Factura;
        }

    }
}
