using JobPortal.Models.Implementation;
using System.Collections.Generic;

namespace JobPortal.Services.Contract
{
    public interface IJobService
    {
        void PostJob(Job job);

        IEnumerable<Job> FindJob(Dictionary<string, object> dict);
        void ChangeStatus(long jobId, int status);
    }
}
