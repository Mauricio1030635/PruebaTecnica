using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Proyecto.Core.DTO;
using Proyecto.Core.Interfaces;
using Proyecto.Core.Recursos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        protected readonly IUsuario _Con;
        protected readonly IConfiguration _Conf;
        public LoginController(IUsuario Con, IConfiguration Conf)
        {
            _Con = Con;
            _Conf = Conf;
        }        
        

        

        [HttpPost]
        public async Task<IActionResult> Get(UsuarioDTO usuario)
        {
            Respuestas Respuesta = new Respuestas();
            try
            {
                UsuarioDTO ResUsuario = await _Con.Login(usuario);
                if (ResUsuario != null)
                {
                    Respuesta.Mensaje = GenerateTokenJwt(usuario);
                    Respuesta.Data = await _Con.Login(usuario);
                }
                else {
                    Respuesta.Estado = 0;
                    Respuesta.Mensaje = "Usuario No Encontrado";
                }
            }
            catch (Exception exc)
            {
                Respuesta.Estado = 0;
                Respuesta.Mensaje = exc.Message;
            }

            return Ok(Respuesta);
        }



        private string GenerateTokenJwt(UsuarioDTO usuario)
        {
            var claims = new[] {
                new Claim (ClaimTypes.Name, usuario.Usuario)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Conf.GetSection("JWT:key").Value));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: signingCredentials);

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return jwtToken;
        }

    }
    
}
