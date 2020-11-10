using JobPortal.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.App.Models
{
    public class PostJobViewModel
    {
        public long Id { get; set; }

        [Required]
        [RegularExpression("^[ a-zA-Z0-9]+$", ErrorMessage = "Invaild characters!")]
        public string Title { get; set; }

        [Required]
        [RegularExpression("^[ a-zA-Z0-9]+$", ErrorMessage = "Invaild characters!")]
        public string Description { get; set; }

        public virtual string Location { get; set; }

        public virtual string State { get; set; }
        public virtual string Country { get; set; }
        public decimal MinimumSalary { get; set; }
        public decimal MaximumSalary { get; set; }
        public bool IsSalaryNegotiable { get; set; }

        [Required]
        //[RegularExpression("^[ a-zA-Z0-9]+$", ErrorMessage ="Invaild characters!")]
        public virtual string RequiredSkills { get; set; }

        [Required]
        //[RegularExpression("^[ a-zA-Z0-9]+$", ErrorMessage = "Invaild characters!")]
        public virtual string Responsibilities { get; set; }
        public virtual long YearsOfExperience { get; set; }

        [DataType(DataType.DateTime)]
        public virtual DateTime ApplicationDeadline { get; set; }

        public JobType JobType { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }
    }
}