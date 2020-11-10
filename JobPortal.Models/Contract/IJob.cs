using JobPortal.Models.Enums;
using JobPortal.Models.Implementation;
using System;

namespace JobPortal.Models.Contract
{
    public interface IJob : IEntity
    {
        int NumberOfApplicants { get; set; }
        string Title { get; set; }
        string RequiredSkills { get; set; }
        string Description { get; set; }
        long JobCategoryId { get; set; }
        JobCategory JobCategory { get; set; }
        string Location { get; set; }
        string Responsibilities { get; set; }
        DateTime DatePosted { get; set; }
        DateTime ApplicationDeadline { get; set; }

        JobType Type { get; set; }
        ExperienceLevel ExperienceLevel { get; set; }
        long CompanyId { get; set; }
        Company Company { get; set; }

        long YearsOfExperience { get; set; }
        string Specialization { get; set; }
    }

}
