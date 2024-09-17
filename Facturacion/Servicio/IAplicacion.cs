using Facturacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Servicio
{
    public interface IAplicacion
    {
        List<Articulo> GetArticulos();
        bool AgregarOEditarArticulos(Articulo articulo);
        bool BorrarProducto(int id);
    }
}
