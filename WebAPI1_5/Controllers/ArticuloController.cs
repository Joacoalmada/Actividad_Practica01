using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Facturacion.Entidades;
using Facturacion.Servicio;
using static System.Net.Mime.MediaTypeNames;

namespace WebAPI1_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private IAplicacion servicio;

        public ArticuloController() 
        { 
            servicio = new AplicacionServicio();
        }

        
        [HttpGet("Mostrar")]
        public IActionResult Get()
        {
            return Ok(servicio.GetArticulos());
        }


        [HttpPost]
        public IActionResult Post([FromBody] Articulo articulo)
        {
            try
            {
                if (articulo == null)
                {
                    return BadRequest("Se esperaba un Articulo");
                }
                if (servicio.AgregarOEditarArticulos(articulo))
                    return Ok("Articulo registrado");
                else
                    return StatusCode(500, "No se pudo registrar el Articulo");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intente nuevamente!");
            }
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = servicio.BorrarProducto(id);
            return Ok(result);
        }

    }
}
