using JobPortal.Data.Contact;
using JobPortal.Data.implementation;
using JobPortal.Repository.Contract;
using JobPortal.Repository.Implementation;
using JobPortal.Services.Contract;
using JobPortal.Services.Implementation;
using SimpleInjector;
using SimpleInjector.Lifestyles;


namespace JobPortal.Extinsion
{
    public class ServiceLocator
    {
        SimpleInjector.Container container = new SimpleInjector.Container();
        
        public ServiceLocator(string conString)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();


            container.Register<IDbContext>(() => new DbContext(conString), Lifestyle.Scoped);

            //Registering Repository Interfaces
            container.Register<ICompanyRepository, CompanyRepository>(Lifestyle.Scoped);
            container.Register<IJobApplicationRepository, JobApplicationRepository>(Lifestyle.Scoped);
            container.Register<IJobRepository, JobRepository>(Lifestyle.Scoped);
            container.Register<IJobCategoryRepository, JobCategoryRepository>(Lifestyle.Scoped);

            //Registering Service Interfaces
            container.Register<IJobApplicationService, JobApplicationService>(Lifestyle.Scoped);
            container.Register<IJobService, JobService>(Lifestyle.Scoped);

            //string conString = ConfigurationManager.ConnectionStrings["PitchMeDBConnection"].ConnectionString;


            container.Verify();
        }

        public SimpleInjector.Container GetContainer()
        {
            return container;
        }
    }
}
