using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using JobPortal.Models.Implementation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobPortal.App.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        
        public ApplicationDbContext()
            : base("JobConnection", throwIfV1Schema: false)
        {
            
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            //modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            //modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            //modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }

        //public System.Data.Entity.DbSet<Pitchme.Models.Implementation.JobSubscription> JobSubscriptions { get; set; }
        public DbSet<Company> Companies { get; set; }

        public System.Data.Entity.DbSet<Job> Jobs { get; set; }
        //public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<EducationBackground> EducationBackgrounds { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
       // public DbSet<Subscription> Subscriptions { get; set; }

        
    }
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext1 : IdentityDbContext<ApplicationUser> 
    {
        public ApplicationDbContext1()
            : base("JobConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext1 Create()
        {
            return new ApplicationDbContext1();
        }
    }
}