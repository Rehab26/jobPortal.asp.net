using JobPortal.Models.Implementation;
using System;

namespace JobPortal.Models.Contract
{
    public interface IWorkExperience : IEntity
    {
        long? JobSeekerID { get; set; }
        string CompanyName { get; set; }
        string Designation { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string JobDescription { get; set; }
        JobSeeker JobSeeker { get; set; }
    }
}
