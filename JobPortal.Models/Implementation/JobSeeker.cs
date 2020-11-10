using JobPortal.Models.Contract;
using JobPortal.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models.Implementation
{
    public class JobSeeker : Entity, IJobSeeker
    {
        public string UserID { get; set; }
        [DataType("NVARCHAR")]
        [StringLength(100)]
        public string FullName { get; set; }
        [DataType(DataType.MultilineText)]
        public string AdditionalInformation { get; set; }
        public string ProfileImageUri { get; set; }
        [DataType(DataType.MultilineText)]
        public string CareerObjective { get; set; }
        [DataType(DataType.MultilineText)]
        public string SkillsAndQualifications { get; set; }
        [DataType("NVARCHAR")]
        [StringLength(25)]
        public string FirstName { get; set; }
        [DataType("NVARCHAR")]
        [StringLength(25)]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [DataType("NVARCHAR")]
        [StringLength(20)]
        public string Nationality { get; set; }
        [DataType("NVARCHAR")]
        [StringLength(100)]
        public string Address { get; set; }
        public Gender Gender { get; set; }
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string CareerEmail { get; set; }
        public string ResumeURL { get; set; }
        public string TwitterURL { get; set; }
        public string LinkedIn { get; set; }
        //Rehab
        public virtual User User { get; set; }
        public virtual List<WorkExperience> WorkExperiences { get; set; }
        public virtual IList<EducationBackground> EducationBackgrounds { get; set; }
        public virtual IList<Language> Languages { get; set; }
        
    }
}
