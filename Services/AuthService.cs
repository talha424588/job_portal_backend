using AutoMapper;
using JobPortal.Context;
using JobPortal.DTO.User.RequestBody;
using JobPortal.DTO.User.ResponseBody;
using JobPortal.Exceptions;
using JobPortal.Models;
using JobPortal.Repositories;
using Microsoft.EntityFrameworkCore;
using UserManagement.Utils;

namespace JobPortal.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;
        private readonly JWT jwt;

        //private readonly Mapper mapper;

        public AuthService(DatabaseContext context, IMapper mapper,JWT jwt) {
            this.context = context;
            this.mapper = mapper;
            this.jwt = jwt;
        }
        public async Task<LoginResponseBody> loginUser(LoginRequestBody requestBody)
        {
            var user = await context.Users.
                Include(u=>u.role).FirstOrDefaultAsync(u=>u.email == requestBody.email);
            if (user != null)   
            {
                if(BCrypt.Net.BCrypt.Verify(requestBody.password, user.password))
                {
                    LoginResponseBody loginResponse = mapper.Map<LoginResponseBody>(user);
                    loginResponse.token = jwt.generateToken(user.email,user.role.name);
                    return loginResponse;
                }
                else
                {
                    throw new InvalidCredential();
                }
            }
            else
            {
                throw new NotFound();
            }
        }

        public async Task<RegisterResponseBody> saveUser(RegisterRequestBody registerRequest)
        {
            var user = await context.Users.FirstOrDefaultAsync(u=>u.email == registerRequest.email);
            if (user != null)
            {
                throw new Exception("user already exist");
            }
                var newUser = mapper.Map<User>(registerRequest);
                newUser.password = BCrypt.Net.BCrypt.HashPassword(newUser.password);
                newUser.roleId = new Guid("E7FAC944-C656-4786-4E00-08DC69AEFC97");
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
