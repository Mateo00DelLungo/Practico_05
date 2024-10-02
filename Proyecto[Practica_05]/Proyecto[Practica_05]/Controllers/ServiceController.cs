using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Practica_05_.App;
using Proyecto_Practica_05_.Interfaces;
using Proyecto_Practica_05_.Models;



namespace Practico_04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IApp app;
        public ServiceController(IApp aplication)
        {
            app = aplication;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var value = await app.servicioManager.GetAll();
                if(null == value) { return NotFound("No hay registros"); }
                return Ok(value);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("/api/[controller]/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var obj = await app.servicioManager.GetById(id);
                if(null == obj)
                {
                    return NotFound("No se encontro el ID del objeto");
                }
                return Ok(obj.ToString());
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ServicioDTO obj)
        {
            if (!obj.Validate())
            {
                return BadRequest("Error de validacion, revise los campos ingresados");
            }
            try
            {
                if (!await app.servicioManager.Save(obj))
                {
                    return StatusCode(500, "Error al insertar en la base de datos");
                }
                return Ok("Objeto registrado exitosamente");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpPut("/api/[controller]/{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] ServicioDTO obj)
        {
            if (!obj.Validate()) 
            { return BadRequest("Error de validacion, revise los campos ingresados; El ID debe ser uno existente"); }
            try
            {
                if(!await app.servicioManager.Update(id, obj))
                {
                    return NotFound("No se encontro el ID del objeto que se desea actualizar");
                }
                return Ok("Objeto actualizado exitosamente");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpDelete("/api/[controller]/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                if(!await app.servicioManager.Delete(id)) 
                { return NotFound("No se encontro el ID del objeto"); }
                return Ok("Objeto eliminado exitosamente");
            }
            catch (Exception)
            {
                return StatusCode(500,"Internal Server Error");
            }
        }
    }
}
