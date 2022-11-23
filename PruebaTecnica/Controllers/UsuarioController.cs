using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Core.DTO;
using Proyecto.Core.Interfaces;
using Proyecto.Core.Recursos;
using Proyecto.Infraestructura.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto.API.Controllers
{
      [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        protected readonly IUsuario _Con;
        public UsuarioController(IUsuario Con)
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
                Respuesta.Data = await _Con.ListarUsuario();
            }
            catch (Exception exc)
            {
                Respuesta.Estado = 0;
                Respuesta.Mensaje = exc.Message;
            }

            return Ok(Respuesta);
        }       
       
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDTO nuevaPersona)
        {            
                Respuestas Respuesta = new Respuestas();
                try
                {
                    Respuesta.Mensaje = "OK";
                    Respuesta.Data = await _Con.CrearUsuario(nuevaPersona);
                }
                catch (Exception exc)
                {
                    Respuesta.Estado = 0;
                    Respuesta.Mensaje = exc.Message;
                }
                return Ok(Respuesta);
            
        }       

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]  UsuarioDTOEntity usuario)
        {
            Respuestas Respuesta = new Respuestas();
            try
            {
                Respuesta.Mensaje = "OK";
                Respuesta.Data = await _Con.ActualizarUsuario(usuario);
            }
            catch (Exception exc)
            {
                Respuesta.Estado = 0;
                Respuesta.Mensaje = exc.Message;
            }
            return Ok(Respuesta);
        }
        
        [HttpDelete]
        public async Task Delete(int Identificacion)
        {
            Respuestas Respuesta = new Respuestas();
            try
            {
                Respuesta.Mensaje = "OK";
                Respuesta.Data = await _Con.EliminarUsuario(Identificacion);
            }
            catch (Exception exc)
            {
                Respuesta.Estado = 0;
                Respuesta.Mensaje = exc.Message;
            }
        }
    }
}
