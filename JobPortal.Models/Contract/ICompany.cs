using JobPortal.Models.Implementation;
using System.Collections.Generic;

namespace JobPortal.Models.Contract
{
    public interface ICompany : IEntity
    {
        string LicenseNumber { get; set; }
        string Name { get; set; }
        string Location { get; set; }
        string CompanyEmail { get; set; }
        string Description { get; set; }
        string ProfileImageUri { get; set; }
        string AdditionalInformation { get; set; }
        string ContactNumberOne { get; set; }
        string ContactNumberTwo { get; set; }
        string WebsiteUrl { get; set; }
        string TwitterUrl { get; set; }
        IList<Job> Jobs { get; set; }
    }
}
