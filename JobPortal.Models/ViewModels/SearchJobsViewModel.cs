using JobPortal.Models.Implementation;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Models.ViewModels
{
    public class HomePageJobsViewModel
    {
        public virtual List<Job> AllJobs { get; set; }
        public virtual List<Job> PopularJobs { get; set; }
        public virtual List<Job> HotJobs { get; set; }
    }
    public class JobSearchModel
    {
        public string SearchString { get; set; }
        public string Category { get; set; }
        public string State { get; set; }
        public string JobType { get; set; }
        public string ExpLevel { get; set; }
        public string Company { get; set; }
        public string DateRange { get; set; }
        public Decimal MinimumSalary { get; set; }
        public Decimal MaximumSalary { get; set; }
        public DateTime DatePosted { get; set; }
    }
    public class JobSearchViewModel
    {
        public string SearchString { get; set; }
        public string Location { get; set; }
        public string JobType { get; set; }
        public string ExpLevel { get; set; }
        public string Company { get; set; }
        public Decimal MinimumSalary { get; set; }
        public Decimal MaximumSalary { get; set; }
        public DateTime DatePosted { get; set; }
    }
    public class JobListVM
    {
        public JobSearchViewModel JobSearchViewModel { get; set; }
        public IPagedList<Job> Jobs { get; set; }
    }
}
