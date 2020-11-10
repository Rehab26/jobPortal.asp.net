using JobPortal.Models.Contract;
using System.Collections.Generic;

namespace JobPortal.Models.Implementation
{
    public class JobCategory : Entity, IJobCategory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IList<Job> Jobs { get; set; }
    }
}
