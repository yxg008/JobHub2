using System.ComponentModel.DataAnnotations;

namespace JobHub.Models
{
    public class JobSeeker
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "firstName is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "lastName is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "JobTitle is required")]
        [StringLength(100, ErrorMessage = "Job title cannot be longer than 100 characters.")]
        public string JobTitle { get; set; }
    }
}
