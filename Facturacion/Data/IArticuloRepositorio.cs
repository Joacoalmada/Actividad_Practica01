using Facturacion.Data;
using Facturacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Data
{
    public interface IArticuloRepositorio
    {
        List<Articulo> GetAll();
        bool add(Articulo articulo);

        bool Delete(int id);
    }
}
