using AutoMapper;
using JobPortal.Context;
using JobPortal.DTO.User.RequestBody;
using JobPortal.DTO.User.ResponseBody;
using JobPortal.Models;
using JobPortal.Repositories;
using Microsoft.EntityFrameworkCore;
using UserManagement.Utils;

namespace JobPortal.Services
{
    public class EmployerService : IEmployerRepository
    {
        private readonly JWT jwt;
        private readonly DatabaseContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;

        public EmployerService(JWT jwt, DatabaseContext context, IHttpContextAccessor httpContextAccessor,IMapper mapper)
        {
            this.jwt = jwt;
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
        }
        public async Task<EmployerResponseBody> addEmployerCompany(EmployerRequestBody requestBody)
        {
            if (jwt.isTokenValid(httpContextAccessor.HttpContext.Request.Headers["Authorization"]) == true)
            {
                var email = jwt.GetEmailFromJwt();
                if (email != null)
                {
                    var user = await context.Users.FirstOrDefaultAsync(u => u.email == email);
                    if(user != null)
                    {
                        var employer = mapper.Map<Employer>(requestBody);
                        employer.userId = user.id;
                        try
                        {
                            context.Employers.AddAsync(employer);
                            context.SaveChangesAsync();
                        }
                        catch(Exception ex)
                        {
                            throw new Exception("Something Went Wrong");
                        }

                        EmployerResponseBody employerResponseBody = mapper.Map<EmployerResponseBody>(employer);
                        return employerResponseBody;
                    }
                }
            }
            throw new NotImplementedException();
        }
    }
}
