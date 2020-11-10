using JobPortal.Models.Enums;
using JobPortal.Models.Implementation;

namespace JobPortal.Models.Contract
{
    public interface IJobApplication : IEntity
    {
        User User { get; set; }
        Job job { get; set; }
        ApplicationStatus applicationStatus { get; set; }
    }
}
