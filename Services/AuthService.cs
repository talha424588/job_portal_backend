using AutoMapper;
using JobPortal.Context;
using JobPortal.DTO.User.RequestBody;
using JobPortal.DTO.User.ResponseBody;
using JobPortal.Models;
using JobPortal.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        //private readonly Mapper mapper;

        public AuthService(DatabaseContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
            //this.mapper = mapper;
        }

        public async Task<LoginResponseBody> loginUser(LoginRequestBody requestBody)
        {
            var user = await context.Users.FirstOrDefaultAsync(u=>u.email == requestBody.email);
            if(user != null)
            {
               // return user;
            }
            throw new NotImplementedException();
        }

        public async Task<RegisterResponseBody> saveUser(RegisterRequestBody registerRequest)
        {
            var user = await context.Users.FirstOrDefaultAsync(u=>u.email == registerRequest.email);
            if (user != null)
            {
                throw new Exception("user already exist");
            }
                var newUser = mapper.Map<User>(registerRequest);
                newUser.roleId = new Guid("E7FAC944-C656-4786-4E00-08DC69AEFC95");
                try
                {
                    context.Users.AddAsync(newUser);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex) {
                    throw new Exception("something went wrong",ex);
                }

                RegisterResponseBody responseBody = mapper.Map<RegisterResponseBody>(newUser);
                return responseBody;
        }
    }
}
