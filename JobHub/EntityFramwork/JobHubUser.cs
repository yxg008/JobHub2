using Microsoft.AspNetCore.Identity;
namespace ASPProject.EntityFramework
{
    public class JobHubUser : IdentityUser
    {
        public string? CompanyName { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
