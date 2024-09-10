using Problema_1._5.Datos;
using Problema_1._5.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1._5.Servicios
{
    public class FacturaGestor
    {
        IArticuloRepositorio articuloRepositorio;
        IFacturaRepositorio facturaRepositorio;
        IFormaPagoRepositorio formaPagoRepositorio;
        

        public FacturaGestor()
        {
            articuloRepositorio = new ArticuloRepositorioDAO();
            facturaRepositorio = new FacturaRepositorioDAO();
            formaPagoRepositorio = new FormaPagoRepositorioDAO();
            
        }

        public List<FormaPago> GetAllFormaPago()
        {
            return formaPagoRepositorio.GetAll();
        }

        public List<Articulo> GetAllArticulo()
        {
            return articuloRepositorio.GetAll();
        }
        public List<Factura> GetAllFactura() 
        {
            return facturaRepositorio.GetAll();
        }

        public bool addFactura(Factura factura) 
        {
            return facturaRepositorio.Add(factura);
        }
        public bool addArticulos(Articulo articulo) 
        {
            return articuloRepositorio.add(articulo);
        }
      
    }
}
