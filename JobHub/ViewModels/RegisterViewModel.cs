using JobHub.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace JobHub.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required(ErrorMessage = "You must enter a first name!")]
        [Display(Name = "Company Name")]
        public String CompanyName { get; set; }

        [Required(ErrorMessage = "You must enter an email address!")]
        [EmailAddress]
        [Display(Name = "Office Email")]
        public String OfficeEmail { get; set; }

        [Phone]
        [Display(Name = "Office Phone Number")]
        public String OfficePhone { get; set; }
    }
}
