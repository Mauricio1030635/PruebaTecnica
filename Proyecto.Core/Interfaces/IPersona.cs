using Proyecto.Core.DTO;
using Proyecto.Infraestructura.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Core.Interfaces
{
    public  interface IPersona
    {
        Task<IEnumerable<Persona>> ListarPersonas();
        Task<Persona> ObtenerPersona(int Identificacion);
        Task<Persona> CrearPersona(PersonaDTO nuevaPersona);
        Task<bool> ActualizarPersona(PersonaDTO Persona);
        Task<bool> EliminarPersona(int Identificacion);
    }
}
