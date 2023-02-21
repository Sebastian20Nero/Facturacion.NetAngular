using factura.Modelos;
using factura.Modelos.ViewModels;
using factura.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace factura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ICliente clientesServicio;
        public ClienteController(ICliente clientesServicio)
        {
            this.clientesServicio = clientesServicio;
        }

        [HttpGet]
        public IActionResult DameClientes() 
        {
            
            Resultado res = new Resultado();
            try
            {
                List<Cliente> lista = clientesServicio.DameClientes();
                res.ObjetoGenerico = lista;
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al cargar listado: " + ex.ToString();
                res.Texto = "Se produjo un error al cargar la lista. Intentalo de nuevo.";
            }

            return Ok(res);

        }
        [HttpPost]
        public IActionResult AgregarCliente(ClienteViewmodel c)
        {
            
            Resultado res = new Resultado();
            try
            {
                clientesServicio.AgregarCliente(c);
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al agregar: " + ex.ToString();
                res.Texto = "Se produjo un error al agregar. Intentalo de nuevo.";
            }

            return Ok(res);

        }

        [HttpPut]
        public IActionResult EditarCliente(ClienteViewmodel c)
        {
            Resultado res = new Resultado();
            try
            {
                clientesServicio.EditarCliente(c);
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al Editar" + ex.ToString();
                res.Texto = "Se produjo un error al Editar. Intentalo de nuevo.";
            }

            return Ok(res);
        }

        [HttpDelete("{IdCliente}")]
        public IActionResult BorrarCliente(int IdCliente)
        {
            Resultado res = new Resultado();
            try
            {
                clientesServicio.BorrarCliente(IdCliente);
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al eliminar " + ex.ToString();
                res.Texto = "Se produjo un error al eliminar. Intentalo de nuevo.";
            }

            return Ok(res);
        }
    }
}
