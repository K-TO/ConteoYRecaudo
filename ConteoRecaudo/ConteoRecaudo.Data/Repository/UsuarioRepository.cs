using ConteoRecaudo.Data.Context;
using ConteoRecaudo.Data.Interface;
using ConteoRecaudo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Bcr = BCrypt.Net;

namespace ConteoRecaudo.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        #region Members
        private readonly ConteoRecaudoContext _context;
        private readonly DbSet<Usuario> _usuarioTable;
        #endregion

        #region Ctor
        public UsuarioRepository(ConteoRecaudoContext context)
        {
            _context = context;
            _usuarioTable = _context.Set<Usuario>();
        }
        #endregion

        #region Methods
        public void Register(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid().ToString();
            if (_context.Usuario.Any(x => x.UserName == usuario.UserName))
                throw new Exception($"El usuario ya esta en uso, inicia sesión.");
            
            usuario.Password = Bcr.BCrypt.HashPassword(usuario.Password);

            _usuarioTable.Add(usuario);
            _context.SaveChanges();
        }

        public async Task<Usuario> Authenticate(string userName, string password)
        {
            Usuario user = _usuarioTable.Where(x => x.UserName.Equals(userName)).FirstOrDefault();
            if (user != null && Bcr.BCrypt.Verify(password, user.Password))
            {
                return user;
            }
            return null;
        }
        #endregion
    }
}
