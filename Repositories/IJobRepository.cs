using JobPortal.DTO.User.RequestBody;
using JobPortal.DTO.User.ResponseBody;

namespace JobPortal.Repositories
{
    public interface IJobRepository
    {
        public Task<JobResponseBody> CreateJob(JobRequestBody requestBody);
    }
}
