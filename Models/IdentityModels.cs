using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AplicationEPAC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Address { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<AplicationEPAC.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<AplicationEPAC.Models.Group> Groups { get; set; }

        public System.Data.Entity.DbSet<AplicationEPAC.Models.TeachingAssignments> TeachingAssignments { get; set; }

        public System.Data.Entity.DbSet<AplicationEPAC.Models.Enrolment> Enrolments { get; set; }

        public System.Data.Entity.DbSet<AplicationEPAC.Models.Evaluation> Evaluations { get; set; }
    }
}