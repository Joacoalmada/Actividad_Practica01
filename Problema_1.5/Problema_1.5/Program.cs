
using Problema_1._5.Dominio;
using Problema_1._5.Servicios;
using Problema_1._5.Datos.Utilidades;
using Problema_1._5.Datos;
using Problema_1._5;
using Problema_1._5.Dominio;
using Problema_1._5.Servicios;


FacturaGestor servicio = new FacturaGestor();

//Crear articulo

var CrearAritculo = new Articulo()
{
    
    Nombre_Art = "Pepsi",
    Precio = 500
};
bool ArticuloCreado = servicio.addArticulos(CrearAritculo);
Console.WriteLine("Articulo Creado" + ArticuloCreado);



//Mostrar Articulos

Console.WriteLine("Tipos de Articulos disponibles");
var articulos = servicio.GetAllArticulo();

List<Articulo> la = servicio.GetAllArticulo();
if (la.Count > 0)
{
    foreach (Articulo a in la)
    {
        Console.WriteLine(a);
    }
}
else
{
    Console.WriteLine("No hay Articulos...");
}



//Crear una nueva Factura

var crearFactura = new Factura
{
    Id_Factura = 2,
    Fecha = new DateTime(2024, 09, 10),
    Cliente = "Joaquin Almada",
    FormaPago = new FormaPago
    {
        Id_FormaPago = 1,

    }
};
bool FacturaCreada = servicio.addFactura(crearFactura);
Console.WriteLine("Cuenta creada: " + FacturaCreada);



//Mostrar Facturas

Console.WriteLine("Facturas Disponibles");
var Facturas = servicio.GetAllFactura();

List<Factura> Fa = servicio.GetAllFactura();
if (Fa.Count > 0)
{

    foreach(Factura f in Fa) 
    {
        Console.WriteLine(f);
    }
}
else
{
    Console.WriteLine("No hay Facturas...");
}

