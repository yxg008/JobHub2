using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobHub.ViewModels
{
    public class RegisterJobSeekerViewModel : LoginJobSeekerViewModel
    {
        [Required(ErrorMessage = "You must enter a first name!")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "You must enter a last name!")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "You must enter an email address!")]
        [EmailAddress]
        [Display(Name = "Office Email")]
        public String OfficeEmail { get; set; }

        [Phone]
        [Display(Name = "Office Phone Number")]
        public String OfficePhone { get; set; }
    }
}
