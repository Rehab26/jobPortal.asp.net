using JobPortal.Models.Implementation;
using System;

namespace JobPortal.Models.Contract
{
    public interface IEducationBackground : IEntity
    {
        long? JobSeekerID { get; set; }
        string InstitutionName { get; set; }
        string DegreeAwarded { get; set; }
        string Description { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        JobSeeker JobSeeker { get; set; }
    }
}
