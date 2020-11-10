using JobPortal.Models.Contract;
using JobPortal.Models.Enums;
using System;

namespace JobPortal.Models.Implementation
{
    [Serializable]
    public class JobApplication : Entity, IJobApplication
    {
        public string pitchLocation;

        public virtual User User { get; set; }
        public virtual Job job { get; set; }
        public virtual ApplicationStatus applicationStatus { get; set; }
    }
}
