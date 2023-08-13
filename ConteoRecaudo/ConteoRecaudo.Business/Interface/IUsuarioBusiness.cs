using ConteoRecaudo.Data.Models;
using ConteoRecaudo.Infraestructure.Models;

namespace ConteoRecaudo.Business.Interface
{
    public interface IUsuarioBusiness
    {
        void Register(Usuario usuario);
        Task<AuthenticationResponse> Authenticate(AuthenticateRequest authenticate);
    }
}
