using AutoMapper;
using ConteoRecaudo.Business.Interface;
using ConteoRecaudo.Data.Interface;
using ConteoRecaudo.Data.Models;
using ConteoRecaudo.Infraestructure.Authorization;
using ConteoRecaudo.Infraestructure.Models;

namespace ConteoRecaudo.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        #region Members
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IJwtUtils _jwtUtils;
        #endregion

        #region Ctor
        public UsuarioBusiness(IUsuarioRepository usuarioRepository, IMapper mapper, IJwtUtils jwtUtils)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }
        #endregion

        #region Methods
        public string Register(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Register(usuario);
                return "Registro exitoso.";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                throw;
            }
        }

        public async Task<AuthenticationResponse> Authenticate(AuthenticateRequest authenticate)
        {
            AuthenticationResponse response = new();
            Usuario usuario = await _usuarioRepository.Authenticate(authenticate.UserName, authenticate.Password);
            if (usuario != null)
            {
                response = _mapper.Map<AuthenticationResponse>(usuario);
                response.Token = _jwtUtils.GenerateToken(usuario);
            }
            else
            {
                response.ErrorMessage = "El usuario y/o la contraseña, no son validos.";
            }
            return response;
        }
        #endregion
    }
}
