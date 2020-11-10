using JobPortal.Models.Contract;
using JobPortal.Models.Enums;
using System;
using System.Linq;
using System.Text;

namespace JobPortal.Models.Implementation
{
    [Serializable]
    public class Job : Entity, IJob
    {
        public virtual int NumberOfApplicants { get; set; }

        public virtual string Title { get; set; }
        public virtual string Location { get; set; }
        public virtual string Description { get; set; }
        public decimal MinimumSalary { get; set; }
        public decimal MaximumSalary { get; set; }
        public virtual string RequiredSkills { get; set; }
        public virtual string Responsibilities { get; set; }
        public virtual long YearsOfExperience { get; set; }
        public virtual string Specialization { get; set; }
        public virtual long JobCategoryId { get; set; }
        public virtual JobCategory JobCategory { get; set; }

        public DateTime DatePosted { get; set; }
        public virtual DateTime ApplicationDeadline { get; set; }
        public virtual JobType Type { get; set; }
        public virtual ExperienceLevel ExperienceLevel { get; set; }
        public virtual JobStatus JobStatus { get; set; }

        public virtual long CompanyId { get; set; }
        public virtual Company Company { get; set; }

    }
}
