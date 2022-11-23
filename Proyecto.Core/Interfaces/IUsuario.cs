using Proyecto.Core.DTO;
using Proyecto.Infraestructura.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Core.Interfaces
{
    public  interface IUsuario
    {
        Task<UsuarioDTO> CrearUsuario(UsuarioDTO nuevaPersona);

        Task<IEnumerable<Usuario>> ListarUsuario();
        Task<bool> ActualizarUsuario(UsuarioDTOEntity Persona);
        Task<bool> EliminarUsuario(int Identificacion);

        Task<UsuarioDTO> Login(UsuarioDTO usuario);
        
    }
}
