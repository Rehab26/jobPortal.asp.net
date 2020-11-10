using JobPortal.Models.Contract;
using JobPortal.Models.Enums;

namespace JobPortal.Models.Implementation
{
    public class Language : Entity, ILanguage
    {
        public string Name { get; set; }
        public ExperienceLevel Rating { get; set; }
        public virtual long ResumeId { get; set; }
    }
}
