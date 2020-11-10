using JobPortal.Models.Enums;
using JobPortal.Models.Implementation;
using System;
using System.Collections.Generic;

namespace JobPortal.Models.Contract
{
    interface IJobSeeker : IEntity
    {
        string UserID { get; set; }

        string AdditionalInformation { get; set; }
        string ProfileImageUri { get; set; }
        string TwitterURL { get; set; }
        string LinkedIn { get; set; }
        string CareerEmail { get; set; }
        string CareerObjective { get; set; }
        string SkillsAndQualifications { get; set; }

        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DateOfBirth { get; set; }
        string Nationality { get; set; }
        Gender Gender { get; set; }
        User User { get; set; }
        List<WorkExperience> WorkExperiences { get; set; }
        IList<EducationBackground> EducationBackgrounds { get; set; }
        IList<Language> Languages { get; set; }
        string ResumeURL { get; set; }
    }
}
