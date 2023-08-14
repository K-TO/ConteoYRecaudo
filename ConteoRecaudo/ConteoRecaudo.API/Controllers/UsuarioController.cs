using AutoMapper;
using ConteoRecaudo.API.Models;
using ConteoRecaudo.Business.Interface;
using ConteoRecaudo.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConteoRecaudo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        #region Members
        private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public UsuarioController(IUsuarioBusiness usuarioBusiness, IMapper mapper)
        {
            _usuarioBusiness = usuarioBusiness;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(Register register)
        {
            Usuario usuario = _mapper.Map<Usuario>(register);
            string result = _usuarioBusiness.Register(usuario);
            return Ok(new { message = result });
        }

        #endregion
    }
}
