using JobPortal.Models.Implementation;
using System.Collections.Generic;

namespace JobPortal.Models.Contract
{
    public interface IJobCategory : IEntity
    {
        string Name { get; set; }
        string Description { get; set; }
        IList<Job> Jobs { get; set; }
    }
}
