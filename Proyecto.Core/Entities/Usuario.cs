using Proyecto.Core.DTO;
using System;
using System.Collections.Generic;

namespace Proyecto.Infraestructura.Core
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Usuario1 { get; set; } = null!;
        public string PassUsuario { get; set; } = null!;
        public DateTime? FechaCreacion { get; set; }

        
    }
}
