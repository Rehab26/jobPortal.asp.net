using JobPortal.Models.Contract;
using System;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models.Implementation
{
    public class EducationBackground : Entity, IEducationBackground
    {
        [DataType("NVARCHAR")]
        [StringLength(50)]
        public string InstitutionName { get; set; }
        public long? JobSeekerID { get; set; }
        public string DegreeAwarded { get; set; }
        [DataType("NVARCHAR")]
        [StringLength(255)]
        public string Description { get; set; }
        public virtual JobSeeker JobSeeker { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
