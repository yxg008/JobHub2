using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobHub.ViewModels
{
    public class LoginJobSeekerViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User name is required!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "A password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool Remember { get; set; }
    }
}
