using factura.Modelos;
using factura.Modelos.ViewModels;
using factura.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace factura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : Controller
    {
        private IFactura facturaServicio;
        public FacturaController(IFactura facturaServicio)
        {
            this.facturaServicio = facturaServicio;
        }
        [HttpGet("{idcliente}")]
        public IActionResult GetFactura(int idcliente)
        {

            Resultado res = new Resultado();
            try
            {
                using (facturacionContext basedatos = new facturacionContext())
                {
                    var lista = facturaServicio.DameFactura(idcliente);
                    res.ObjetoGenerico = lista;
                }
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al generar el listado: " + ex.ToString();
                res.Texto = "Se produjo un error al cargar la lista. Intentalo de nuevo.";
            }

            return Ok(res);

        }

        [HttpPost]
        public IActionResult CreateFactura(FacturaViewmodel c)
        {

            Resultado res = new Resultado();
            try
            {
                facturaServicio.Compra(c);
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al agregar: " + ex.ToString();
                res.Texto = "Se produjo un error al agregar. Intentalo de nuevo.";
            }

            return Ok(res);

        }
    }
}
