using JobPortal.Models.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobPortal.Models.Implementation
{
    [Serializable]
    public class User : IdentityUser
    {
        public UserType UserType { get; set; }
        public virtual IList<JobApplication> jobApplications { get; set; }
        public virtual IList<Job> FavouriteJobs { get; set; }
        //public virtual JobSeeker JobSeeker { get; set; }

        public string checkId
        {
            get
            {
                return Id;
            }
            set { }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        
    }
}
