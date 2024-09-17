using Facturacion.Data;
using Facturacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Servicio
{
    public class AplicacionServicio : IAplicacion
    {
        private IArticuloRepositorio Respositorio;


        public AplicacionServicio() 
        {
            Respositorio = new ArticuloRepositorioDAO();
        }

        public bool AgregarOEditarArticulos(Articulo articulo)
        {
            return Respositorio.add(articulo);
        }

        public bool BorrarProducto(int id)
        {
            return Respositorio.Delete(id);
        }

        public List<Articulo> GetArticulos()
        {
            return Respositorio.GetAll();

        }
    }
}
