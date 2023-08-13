using ConteoRecaudo.Data.Models;

namespace ConteoRecaudo.Data.Interface
{
    public interface IUsuarioRepository
    {
        void Register(Usuario usuario);
        Task<Usuario> Authenticate(string userName, string password);
    }
}
