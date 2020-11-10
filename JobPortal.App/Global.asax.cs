using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using System.Web.Optimization;
using System.Web.Routing;
using JobPortal.Models.Implementation;
using JobPortal.Services.Contract;
using JobPortal.Services.Implementation;
using JobPortal.Repository.Implementation;
using JobPortal.Repository.Contract;
using SimpleInjector.Integration.Web.Mvc;
using JobPortal.App.Models;
using JobPortal.Data.implementation;
using JobPortal.Models;
using JobPortal.Data.Contact;
using System.Configuration;
using JobPortal.Extinsion;

namespace JobPortal.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //private readonly String conString = System.Configuration.ConfigurationManager.AppSettings["JobConnection"];
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);



            var container = new SimpleInjector.Container();

            string conString = ConfigurationManager.ConnectionStrings["JobConnection"].ConnectionString;
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Options.ResolveUnregisteredConcreteTypes = true;
            container.Register<System.Data.Entity.DbContext>(() => new JobPortal.Models.ApplicationDbContext(), Lifestyle.Scoped);


            container.Register<IUserStore<User>, MyUserStore>(Lifestyle.Scoped);
            container.Register<UserManager<User>, ApplicationUserManager>(Lifestyle.Scoped);

            container.Register<IAuthenticationManagerFactory, AuthenticationManagerFactory>();
            container.Register<IAuthenticationManager>(
                    () => HttpContext.Current.GetOwinContext().Authentication);



            //Registering Repository Interfaces

            container.Register<ICompanyRepository, CompanyRepository>(Lifestyle.Scoped);
            container.Register<IJobApplicationRepository, JobApplicationRepository>(Lifestyle.Scoped);
            container.Register<IJobRepository, JobRepository>(Lifestyle.Scoped);
            container.Register<IJobCategoryRepository, JobCategoryRepository>(Lifestyle.Scoped);
            container.Register<IWorkExperienceRepository, WorkExperienceRepository>(Lifestyle.Scoped);
            container.Register<IEducationBackgroundRepository, EducationBackgroundRepository>(Lifestyle.Scoped);
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<IResumeRepository, ResumeRepository>(Lifestyle.Scoped);
            container.Register<ILanguageRepository, LanguageRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);


            //Registering Service Interfaces
            container.Register<IJobApplicationService, JobApplicationService>(Lifestyle.Scoped);
            container.Register<IJobService, JobService>(Lifestyle.Scoped);
            //container.Register<IJobSubscriptionService, JobSubscriptionService>(Lifestyle.Scoped);
            container.Register<IResumeService, ResumeService>(Lifestyle.Scoped);
            container.Register<IUtilityService, UtilityService>(Lifestyle.Scoped);



            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            //container.Verify();



        }
    }
}
