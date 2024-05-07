using JobPortal.DTO.User.RequestBody;
using JobPortal.DTO.User.ResponseBody;
using JobPortal.Repositories;
using UserManagement.Utils;

namespace JobPortal.Services
{
    public class EmployerService : IEmployerRepository
    {
        private readonly JWT jwt;

        public EmployerService(JWT jwt)
        {
            this.jwt = jwt;
        }
        public EmployerResponseBody addEmployerCompany(EmployerRequestBody requestBody)
        {
            jwt.isTokenValid(requestBody.jwt);
            throw new NotImplementedException();
        }
    }
}
