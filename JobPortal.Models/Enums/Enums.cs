using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Models.Enums
{
    public enum JobType
    {
        [Description("دوام كامل")]
        FullTime,
        [Description("دوام جزئي")]
        PartTime,
        [Description("دوام بعقد")]
        Contract,
        [Description("عمل حر")]
        Freelance
    }
    public enum Qualification
    {
        [Description("ثانوي")]
        highSchool,
        [Description("دبلوم")]
        Diploma,
        [Description("دبلوم وطني عالي")]
        HND,
        [Description("بكالوريوس")]
        BSC,
        [Description("شهادة مهنية")]
        Professional_Certification,
        [Description("ماجستير")]
        MSC,
        [Description("دكتوراه")]
        Doctorate,
        [Description("بروفيسور")]
        Professor,
        [Description("أخرى")]
        Other
    }
    public enum ApplicationStatus
    {
        Pending,
        [Description("قبول")]
        Acepted,
        [Description("تفضيل")]
        Interested,
        [Description("رفض")]
        Rejected
    }
    public enum ExperienceLevel
    {
        [Description("متدرب")]
        Trainee,
        [Description("مبتدئ")]
        Junior,
        [Description("مستوى متوسط")]
        MidLevel,
        [Description("مستوى متوسط مرتفع")]
        MidSeniorLevel,
        [Description("مستوى مرتفع")]
        Senior,
        [Description("مستوى عالي")]
        TopLevel
    }
    public enum UserType {[Description("باحث عن عمل")] JobSeeker, [Description("شركة")] Company }
    public enum Gender {[Description("رجل")] Male, [Description("إمرأة")] Female }

    public enum JobStatus
    {
        [Description("شاغرة")]
        Vacant,
        [Description("شاغلة")]
        Filled,
        [Description("مغلقة")]
        Closed
    }

}
