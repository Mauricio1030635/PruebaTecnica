using Microsoft.EntityFrameworkCore;
using Proyecto.Core.DTO;
using Proyecto.Core.Interfaces;
using Proyecto.Core.Recursos;
using Proyecto.Infraestructura.Core;
using Proyecto.Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Infraestructura.Repositorios
{
    public class RepositorioPersonaSQL : IPersona
    {        

       protected readonly dbContext _Context;        
        public RepositorioPersonaSQL(dbContext Context)
        {
            _Context = Context;
        }
        public async Task<bool> ActualizarPersona(PersonaDTO Personas)
        {
            try
            {
                Conversion conv = new Conversion();
                Persona Persona = conv.ConversionDTOaEntity(Personas);
                _Context.Personas.Update(Persona);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception exc)
            {
                throw new ArgumentException(String.Format("Error: {0}", exc));
                
            }
        }

        public async Task<Persona> CrearPersona(PersonaDTO nuevaPersona)
        {
            try
            {
                Conversion conv = new Conversion();
                Persona Persona = conv.ConversionDTOaEntity(nuevaPersona);
                await _Context.Personas.AddAsync(Persona);
                await _Context.SaveChangesAsync();
                return Persona;
            }
            catch (Exception exc)
            {
                throw new ArgumentException(String.Format("Error: {0}", exc));

            }
        }

        public async Task<bool> EliminarPersona(int Identificacion)
        {
            try
            {
                Persona persona = await _Context.Personas.Where(x => x.IdPersona == Identificacion).FirstAsync();
                _Context.Personas.Remove(persona);
                await _Context.SaveChangesAsync();
                return true;
                
            }
            catch (Exception exc)
            {
                throw new ArgumentException(String.Format("Error: {0}", exc));

            }
        }

        public async Task<IEnumerable<Persona>> ListarPersonas() {
            try
            {                
                return await _Context.Personas.ToListAsync();

            }
            catch (Exception exc)
            {
                throw new ArgumentException(String.Format("Error: {0}", exc));

            }
        } 



        public  async Task<Persona> ObtenerPersona(int Identificacion)
        {
            try
            {
                 Persona persona = await _Context.Personas.Where(x => x.IdPersona == Identificacion).FirstAsync();                
                return persona;

            }
            catch (Exception exc)
            {
                throw new ArgumentException(String.Format("Error: {0}", exc));

            }
        }
    }
}
