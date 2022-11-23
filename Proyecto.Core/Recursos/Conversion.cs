using Proyecto.Core.DTO;
using Proyecto.Infraestructura.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Core.Recursos
{
    public class Conversion
    {
        public Persona ConversionDTOaEntity(PersonaDTO personaDto)
        {
            Persona persona = new Persona();
            persona.NombresPersona = personaDto.NombresPersona;
            persona.ApellidosPersona = personaDto.ApellidosPersona;
            persona.NumIdentificacionPersona = personaDto.NumIdentificacionPersona;
            persona.EmailPersona = personaDto.EmailPersona;
            persona.TipoIdentificacionPersona = personaDto.TipoIdentificacionPersona;
            persona.FechaCreacion = personaDto.FechaCreacion;
            return persona;
        }


        public Usuario UsuarioDTOtoEntity(UsuarioDTO user)
        {
            Usuario usuario = new Usuario();
            usuario.Usuario1 = user.Usuario;
            usuario.PassUsuario = user.PassUsuario;
            return usuario;
        }

        public Usuario UsuarioDTOEntitytoEntity(UsuarioDTOEntity user)
        {
            Usuario usuario = new Usuario();
            usuario.IdUsuario = user.IdUsuario;
            usuario.Usuario1 = user.Usuario;
            usuario.PassUsuario = user.PassUsuario;
            return usuario;
        }

    }
}
