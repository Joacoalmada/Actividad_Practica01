using Problema_1._5.Datos.Utilidades;
using Problema_1._5.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._5.Datos
{
    public class FormaPagoRepositorioDAO : IFormaPagoRepositorio
    {
        public List<FormaPago> GetAll()
        {
            var FP = new List<FormaPago>();
            DataTable table = DataHelper.GetInstance().EjecutarPA("SP_MOSTRAR_FORMA_PAGO");
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    FormaPago fp = new FormaPago()
                    {
                        Id_FormaPago = Convert.ToInt32(row["id_FormaPago"]),
                        TipoPago = Convert.ToString(row["nombre"])

                    };
                  
                    FP.Add(fp);
                }
            }
            return FP;
        }
    }
}
