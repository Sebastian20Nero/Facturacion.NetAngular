using factura.Modelos;
using factura.Modelos.ViewModels;
using factura.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace factura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private IProducto productoServicio;
        public ProductosController(IProducto productoServicio)
        {
            this.productoServicio = productoServicio;
        }

        [HttpGet]
        public IActionResult DameProducto()
        {

            Resultado res = new Resultado();
            try
            {
                List<Producto> lista = productoServicio.DameProducto();
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
        public IActionResult AgregarProducto(ProductoViewmodel c)
        {

            Resultado res = new Resultado();
            try
            {
                productoServicio.AgregarProducto(c);
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al agregar: " + ex.ToString();
                res.Texto = "Se produjo un error al agregar. Intentalo de nuevo.";
            }

            return Ok(res);

        }

        [HttpPut]
        public IActionResult EditarProducto(ProductoViewmodel c)
        {
            Resultado res = new Resultado();
            try
            {
                productoServicio.EditarProducto(c);
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al Editar" + ex.ToString();
                res.Texto = "Se produjo un error al Editar. Intentalo de nuevo.";
            }

            return Ok(res);
        }

        [HttpDelete("{Idproducto}")]
        public IActionResult BorrarProducto(int Idproducto)
        {
            Resultado res = new Resultado();
            try
            {
                productoServicio.BorrarProducto(Idproducto);
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
