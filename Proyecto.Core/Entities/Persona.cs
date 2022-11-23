using System;
using System.Collections.Generic;

namespace Proyecto.Infraestructura.Core
{
    public partial class Persona
    {
        public int IdPersona { get; set; }
        public string NombresPersona { get; set; } = null!;
        public string ApellidosPersona { get; set; } = null!;
        public string NumIdentificacionPersona { get; set; } = null!;
        public string EmailPersona { get; set; } = null!;
        public string TipoIdentificacionPersona { get; set; } = null!;
        public DateTime? FechaCreacion { get; set; }
        public string FullIdentificacion { get; set; } = null!;
        public string NombreCompletoPersona { get; set; } = null!;
    }
}
