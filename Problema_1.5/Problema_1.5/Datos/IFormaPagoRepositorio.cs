using Problema_1._5.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._5.Datos
{
    public interface IFormaPagoRepositorio
    {
        List<FormaPago> GetAll();
    }
}
