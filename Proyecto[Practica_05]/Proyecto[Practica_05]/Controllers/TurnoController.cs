using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Practica_05_.App;
using Proyecto_Practica_05_.Interfaces;
using Proyecto_Practica_05_.Models;

namespace Proyecto_Practica_05_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly IApp app;
        public TurnoController(IApp aplication)
        {
            app = aplication;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var value = await app.turnoManager.GetAll();
                if ( null == value) { return NotFound("No hay registros"); }
                return Ok(value);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("/api/[controller]/{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            if(id <= 0) { return BadRequest("Ingrese un ID valido"); }
            try
            {
                var value = await app.turnoManager.GetById(id);
                if (null == value) 
                { return NotFound("No hay turnos para el id ingresado"); }
                return Ok(value.ToString());
            }
            catch (Exception)
            {
                return StatusCode(500,"Internal Server Error");
            }
        }
        [HttpGet("/api/[controller]/filters")]
        public async Task<IActionResult> Get([FromBody] DateTime fecha)
        {
            if(fecha < DateTime.MinValue || fecha > DateTime.MaxValue) 
            { return BadRequest("Ingrese una fecha valida por favor."); }
            try
            {
                var value = app.turnoManager.GetByDate(fecha);
                if (value == null) { return NotFound("No hay turnos para esa fecha"); }
                return Ok(value);
            }
            catch (Exception)
            {
                return StatusCode(500,"Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TurnoDTO obj)
        {
            if (!obj.Validate())
            {
                return BadRequest("Error de validacion, verifique los campos ingresados, " +
                    "la fecha del turno no puede ser superar los 45 dias a partir de la actual");
            }
            try
            {
                if (!await app.turnoManager.Save(obj))
                {
                    return StatusCode(500, "Error al insertar en la base de datos, " +
                        "chequee que no exista un turno registrado para la fecha ingresada");
                }
                return Ok("Objeto registrado exitosamente");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpPut("/api/[controller]/{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] TurnoDTO obj)
        {
            if(!obj.Validate()) 
            { return BadRequest("Error de validacion, revise los campos ingresados"); }
            try
            {
                if(!await app.turnoManager.Update(id, obj)) 
                { return BadRequest("No se pudo actualizar el objeto, verifique que el id exista"); }
                return Ok("Objeto actualizado exitosamente");
            }
            catch (Exception)
            {
                return StatusCode(500,"internal server error");
            }
        }
        [HttpDelete("/api/[controller]/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(id <= 0 ) { return BadRequest("Ingrese un ID valido"); }
            try
            {
                if (!await app.turnoManager.Delete(id))
                { return NotFound("Error al eliminar, verifique que el id exista"); }
                return Ok("Objeto eliminado");
            }
            catch (Exception)
            {
                return StatusCode(500,"Internal Server Error");
            }
        }
    }
}
