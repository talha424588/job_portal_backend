using JobPortal.DTO.User.RequestBody;
using JobPortal.DTO.User.ResponseBody;

namespace JobPortal.Repositories
{
    public interface IAuthRepository
    {
        public Task<LoginResponseBody> loginUser(LoginRequestBody requestBody);
        public Task<RegisterResponseBody> saveUser(RegisterRequestBody registerRequest);
    }
}
