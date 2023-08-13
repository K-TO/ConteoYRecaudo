using ConteoRecaudo.Business.Interface;
using ConteoRecaudo.Infraestructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConteoRecaudo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        #region Members
        private readonly IConfiguration _configuration;
        private readonly IUsuarioBusiness _usuarioBusiness;
        #endregion

        #region Members
        public AuthController(IConfiguration configuration, IUsuarioBusiness usuarioBusiness)
        {
            _configuration = configuration;
            _usuarioBusiness = usuarioBusiness;
        }
        #endregion

        #region Members
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthenticateRequest authenticate)
        {
            AuthenticationResponse response = await _usuarioBusiness.Authenticate(authenticate);
            if (!string.IsNullOrEmpty(response.Token))
            {
                return Ok(response);
            }
            return Ok(response);
        }
        #endregion

    }
}
