using JobPortal.DTO.User.RequestBody;
using JobPortal.DTO.User.ResponseBody;
using JobPortal.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }

        [HttpPost("register")]
        public Task<RegisterResponseBody> Register(RegisterRequestBody requestBody)
        {
            return authRepository.saveUser(requestBody);
        }

        [HttpPost("login")]
        public Task<LoginResponseBody> Login(LoginRequestBody requestBody)
        {
            return authRepository.loginUser(requestBody);
        }
    }
}
