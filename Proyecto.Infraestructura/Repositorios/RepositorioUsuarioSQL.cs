using Microsoft.EntityFrameworkCore;
using Proyecto.Core.DTO;
using Proyecto.Core.Interfaces;
using Proyecto.Core.Recursos;
using Proyecto.Infraestructura.Core;
using Proyecto.Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Infraestructura.Repositorios
{
    public class RepositorioUsuarioSQL : IUsuario
    {

        protected readonly dbContext _Context;
        public RepositorioUsuarioSQL(dbContext Context)
        {
            _Context = Context;
        }

        public async Task<bool> ActualizarUsuario(UsuarioDTOEntity usuario)
        {
            try
            {
                Conversion conv = new Conversion();
                Encriptacion Enc = new Encriptacion();
                Usuario usuarios = conv.UsuarioDTOEntitytoEntity(usuario);
                usuarios.PassUsuario = Enc.Encriptar(usuarios.PassUsuario);
                _Context.Usuarios.Update(usuarios);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch (Exception exc)
            {
                throw new ArgumentException(String.Format("Error: {0}", exc));

            }
        }

        public async Task<UsuarioDTO> CrearUsuario(UsuarioDTO nuevaPersona)
        {
            try
            {
                Encriptacion Enc = new Encriptacion();
                Conversion conversion= new Conversion();
                nuevaPersona.PassUsuario = Enc.Encriptar(nuevaPersona.PassUsuario);
                Usuario data = conversion.UsuarioDTOtoEntity(nuevaPersona); 
                await _Context.Usuarios.AddAsync(data);
                await _Context.SaveChangesAsync();                                
                return nuevaPersona;


            }
            catch (Exception exc)
            {
                throw new ArgumentException(String.Format("Error: {0}", exc));

            }
        }
        public async Task<bool> EliminarUsuario(int Identificacion)
        {
            try
            {
                Usuario usuario = await _Context.Usuarios.Where(x => x.IdUsuario == Identificacion).FirstAsync();
                _Context.Usuarios.Remove(usuario);
                await _Context.SaveChangesAsync();
                return true;

            }
            catch (Exception exc)
            {
                throw new ArgumentException(String.Format("Error: {0}", exc));

            }
        }
        public async Task<IEnumerable<Usuario>> ListarUsuario()
        {
            try
            {
                return await _Context.Usuarios.ToListAsync();

            }
            catch (Exception exc)
            {
                throw new ArgumentException(String.Format("Error: {0}", exc));

            }
        }
        public async Task<UsuarioDTO> Login(UsuarioDTO usuario)
        {
            try
            {
                Encriptacion Enc = new Encriptacion();
                UsuarioDTO data = null;
                string clave = Enc.Encriptar(usuario.PassUsuario);
                data = await _Context.Usuarios.Where(x=>x.PassUsuario== clave && x.Usuario1== usuario.Usuario).Select(x=> new UsuarioDTO() { 
                    Usuario =x.Usuario1,
                    PassUsuario=x.PassUsuario
                }).FirstOrDefaultAsync();                                
                return data;
                
                
            }
            catch (Exception exc)
            {
                throw new ArgumentException(String.Format("Error: {0}", exc));

            }
        }
    }
}
