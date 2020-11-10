using JobPortal.Models.Contract;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models.Implementation
{
    public class Company : Entity, ICompany
    {
        public string UserId { get; set; }
        public string LicenseNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string CompanyEmail { get; set; }
        [DataType("NVARCHAR")]
        [StringLength(80)]

        public virtual string Name { get; set; }
        [DataType("NVARCHAR")]
        [StringLength(255)]
        public virtual string Location { get; set; }
        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; }
        [DataType(DataType.MultilineText)]
        public string AdditionalInformation { get; set; }
        public string ProfileImageUri { get; set; } = "~/assets/images/job/4.png";
        [DisplayName("Phone Number")]
        public virtual string ContactNumberOne { get; set; }
        [DisplayName("Alternate Phone Number")]
        public virtual string ContactNumberTwo { get; set; }
        public string WebsiteUrl { get; set; }
        public string TwitterUrl { get; set; }

        public virtual IList<Job> Jobs { get; set; }
    }
}
