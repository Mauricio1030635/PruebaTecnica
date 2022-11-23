using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Core.DTO;
using Proyecto.Core.Interfaces;
using Proyecto.Core.Recursos;
using Proyecto.Infraestructura.Core;

namespace Proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonaController : ControllerBase
    {
        protected readonly IPersona _Con;
        public PersonaController(IPersona Con)
        {
            _Con = Con;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Respuestas Respuesta = new Respuestas();
            try
            {                
                Respuesta.Mensaje = "OK";
                Respuesta.Data=await _Con.ListarPersonas();
                }
            catch (Exception exc)
            {
                Respuesta.Estado = 0;
                Respuesta.Mensaje = exc.Message;
            }

            return Ok(Respuesta);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuestas Respuesta = new Respuestas();
            try
            {
                Respuesta.Mensaje = "OK";
                Respuesta.Data = await _Con.ObtenerPersona(id);                
            }
            catch (Exception exc)
            {

                Respuesta.Estado = 0;
                Respuesta.Mensaje = exc.Message;
            }
            return Ok(Respuesta);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonaDTO nuevaPersona)
        {
            Respuestas Respuesta = new Respuestas();
            try
            {
                Respuesta.Mensaje = "OK";
                Respuesta.Data = await _Con.CrearPersona(nuevaPersona);                
            }
            catch (Exception exc)
            {
                Respuesta.Estado = 0;
                Respuesta.Mensaje = exc.Message;
            }
            return Ok(Respuesta);
        }
        
        [HttpPut]
        public async Task Put( [FromBody] PersonaDTO Persona)
        {
            Respuestas Respuesta = new Respuestas();
            try
            {
                Respuesta.Mensaje = "OK";
                Respuesta.Data = await _Con.ActualizarPersona(Persona);
            }
            catch (Exception exc)
            {
                Respuesta.Estado = 0;
                Respuesta.Mensaje = exc.Message;
            }
        }
        
        [HttpDelete]
        public async Task Delete(int Identificacion)
        {
            Respuestas Respuesta = new Respuestas();
            try
            {
                Respuesta.Mensaje = "OK";
                Respuesta.Data = await _Con.EliminarPersona(Identificacion);
            }
            catch (Exception exc)
            {
                Respuesta.Estado = 0;
                Respuesta.Mensaje = exc.Message;
            }
        }

    }
}
