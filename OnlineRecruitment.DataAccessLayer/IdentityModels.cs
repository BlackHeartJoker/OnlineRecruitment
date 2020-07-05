using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using OnlineRecruitment.DataAccessLayer.Models;

namespace OnlineRecruitment.DataAccessLayer
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Skill> SkillsTable { get; set; }
        public virtual DbSet<Project> ProjectTable { get; set; }
        public virtual DbSet<Education> EducationTable { get; set; }
        public virtual DbSet<Stack> StackTable { get; set; }
        public virtual DbSet<Post> PostTable { get; set; }
        public virtual DbSet<Person> PersonTable { get; set; }
        public virtual DbSet<Employer> EmployerTable { get; set; }
        public virtual DbSet<Employee> EmployeeTable { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}