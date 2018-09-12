using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Timesheets.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here

            userIdentity.AddClaim(new Claim("FirstName", string.IsNullOrEmpty(this.FirstName) ? " " : this.FirstName));

            userIdentity.AddClaim(new Claim("LastName", string.IsNullOrEmpty(this.LastName) ? " " : this.LastName));

            userIdentity.AddClaim(new Claim("PrimaryClient", string.IsNullOrEmpty(this.PrimaryClient) ? " " : this.PrimaryClient));

            userIdentity.AddClaim(new Claim("EmployeeId", string.IsNullOrEmpty(this.EmployeeId) ? " " : this.EmployeeId));


            return userIdentity;
        }


        public string FirstName
        { get; set; }


        public string LastName
        { get; set; }


        public string PrimaryClient
        { get; set; }

        public string EmployeeId
        { get; set; }



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
    }
}