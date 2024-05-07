using JobPortal.DTO.User.RequestBody;
using JobPortal.DTO.User.ResponseBody;
using JobPortal.Models;
using JobPortal.Repositories;
using UserManagement.Utils;

namespace JobPortal.Services
{
    public class JobService : IJobRepository
    {
        private readonly JWT jwt;

        public JobService(JWT jwt)
        {
            this.jwt = jwt;
        }
        public Task<JobResponseBody> CreateJob(JobRequestBody requestBody)
        {
            throw new Exception();
        }
    }
}
