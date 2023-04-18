using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<RequestResult<bool>> LogIn(LoginRequest login)
        {
            try
            {
                var logged = await _authService.LogIn(login.usuario, login.password, login.codigoEmisor);

                return new ()
                {
                    Error = "",
                    IsError = false,
                    Result = logged
                };

            }
            catch(Exception e)
            {
                return new()
                {
                    Error = e.Message,
                    IsError = true,
                    Result = false
                };
            }
        }
    }
}
