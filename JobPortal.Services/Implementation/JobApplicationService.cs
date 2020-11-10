using JobPortal.Models.Enums;
using JobPortal.Models.Implementation;
using JobPortal.Repository.Contract;
using JobPortal.Services.Contract;
using JobPortal.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JobPortal.Services.Implementation
{
    public class JobApplicationService : IJobApplicationService
    {
        //private JobApplicationRepository _jobApplicationRepository; //Get instance from container
        private IUnitOfWork uow;
        public JobApplicationService(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        /// <summary>
        /// Post a new job application entry
        /// </summary>
        /// <param name="jobApplication"></param>
        /// <returns></returns>
        public void PostJobApplication(JobApplication jobApplication)
        {
            uow.jobApplicationRepository.Add(jobApplication);
            jobApplication.job.NumberOfApplicants++;
            uow.jobRepository.Update(jobApplication.job);
            uow.Save();
        }


        /// <summary>
        /// Searches for job applications using the dictionary filters
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public IEnumerable<JobApplication> FindJobApplication(Dictionary<string, object> dict)
        {
            Expression<Func<JobApplication, bool>> predicate = PredicateBuilder.True<JobApplication>();

            predicate = predicate.And(x => x.User.checkId == dict["UsercheckId"].ToString());
            //if (dict.Keys.Contains("Company")) predicate = predicate.And(x => x.Company.ID == Convert.ToInt64(dict["CompanyID"]));
            if (dict.Keys.Contains("Job")) predicate = predicate.And(x => x.job.ID == Convert.ToInt64(dict["jobID"]));
            if (dict.Keys.Contains("applicationStatus"))
            {
                var status = Enum.Parse(typeof(ApplicationStatus), dict["applicationStatus"].ToString());
                predicate = predicate.And(x => x.applicationStatus == (ApplicationStatus)status);
            }
            return uow.jobApplicationRepository.Find(predicate);
        }


        public string GetMessage(string code)
        {
            switch (code)
            {
                case "aa":
                    return "You have already applied for this job";
                case "sa":
                    return "You have successfully applied for this job";
                case "sb":
                    return "Job successfully added to favourites";
                case "er":
                    return "An error occured while processing your request, please try again";
                case "jc":
                    return "Sorry, this job has been closed.";
                case "jf":
                    return "Sorry, the maximum applicant for this job has already been reached.";
                default:
                    return "";
            }
        }
    }
}
