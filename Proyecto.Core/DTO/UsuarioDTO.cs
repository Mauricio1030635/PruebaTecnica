using Proyecto.Infraestructura.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Core.DTO
{
    public class UsuarioDTO
    {
        public string Usuario { get; set; } = null!;
        public string PassUsuario { get; set; } = null!;

        
    }

    public class UsuarioDTOEntity
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; } = null!;
        public string PassUsuario { get; set; } = null!;
    }

    


}
