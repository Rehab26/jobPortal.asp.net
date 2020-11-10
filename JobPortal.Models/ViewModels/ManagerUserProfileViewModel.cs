using JobPortal.Models.Enums;
using JobPortal.Models.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Models.ViewModels
{
    public class EditResumeViewModel
    {

        public string Rating { get; set; }
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
        public string SecondName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [DataType("NVARCHAR")]
        [StringLength(20)]
        public string Nationality { get; set; }
        public Gender Gender { get; set; }
        [DataType("NVARCHAR")]
        [StringLength(100)]
        public string Address { get; set; }
        public List<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>() { new WorkExperience() };
        public IList<EducationBackground> EducationBackgrounds { get; set; } = new List<EducationBackground>() { new EducationBackground() };
        public IList<Language> Languages { get; set; } = new List<Language>() { new Language() };

    }

    public class ManageProfileViewModel
    {

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
