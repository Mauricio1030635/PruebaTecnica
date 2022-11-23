using Proyecto.Infraestructura.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Core.DTO
{
    public  class PersonaDTO
    {        
        public string NombresPersona { get; set; } = null!;
        public string ApellidosPersona { get; set; } = null!;
        public string NumIdentificacionPersona { get; set; } = null!;
        public string EmailPersona { get; set; } = null!;
        public string TipoIdentificacionPersona { get; set; } = null!;
        public DateTime? FechaCreacion { get; set; }
    }
}
