using JobPortal.Models.Contract;
using System;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models.Implementation
{
    public class WorkExperience : Entity, IWorkExperience
    {
        public long? JobSeekerID { get; set; }
        [DataType("NVARCHAR")]
        [StringLength(50)]
        public string CompanyName { get; set; }
        [DataType("NVARCHAR")]
        [StringLength(50)]
        public string Designation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [DataType("NVARCHAR")]
        [StringLength(255)]
        public string JobDescription { get; set; }
        public virtual JobSeeker  JobSeeker { get; set; }
    }
}
