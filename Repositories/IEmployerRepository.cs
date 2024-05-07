using JobPortal.DTO.User.RequestBody;
using JobPortal.DTO.User.ResponseBody;

namespace JobPortal.Repositories
{
    public interface IEmployerRepository
    {
        EmployerResponseBody addEmployerCompany(EmployerRequestBody requestBody);
    }
}
