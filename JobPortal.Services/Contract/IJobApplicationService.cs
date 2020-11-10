using JobPortal.Models.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Contract
{
    public interface IJobApplicationService
    {
        void PostJobApplication(JobApplication jobApplication);

        IEnumerable<JobApplication> FindJobApplication(Dictionary<string, object> dict);
        string GetMessage(string code);
    }
}
