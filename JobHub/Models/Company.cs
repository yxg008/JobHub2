using System;
using System.ComponentModel.DataAnnotations;

namespace JobHub.Models
{
 
    public enum Skills
    {
        [Display(Name = "Python Programming")]
        Python,

        [Display(Name = "R Programming")]
        R,

        [Display(Name = "Java Programming")]
        Java,

        [Display(Name = "C# Programming")]
        CSharp,

        [Display(Name = "AWS Skills")]
        Aws,

        [Display(Name = "SQL Database")]
        Sql,

        [Display(Name = "Docker Containers")]
        Docker,

        [Display(Name = "HTML Coding")]
        Html,

        [Display(Name = "CSS Styling")]
        Css,

        [Display(Name = "JavaScript Programming")]
        Javascript,

        [Display(Name = "Swift Programming")]
        Swift
    }

    public class Company
    {
        //[Required]
        //[Range(1, int.MaxValue, ErrorMessage = "ID must be a positive integer.")]
        //[Display(Name = "ID:  ")]
        public int ID { get; set; }

        [Required]
        [NameMustBeCapitalized]
        [Display(Name = "Name:  ")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Open Position:  ")]
        public string? OpenPosition { get; set; }

        [Required]
        [Range(0, 50)]
        [Display(Name = "Experience Required (Years):  ")]
        public int YearRequirement { get; set; }

        [Required]
        [Range(30000, 500000)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [Display(Name = "Annual Salary:  ")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "You must choose a skill")]
        [Display(Name = "Skill:  ")]
        public Skills Skill { get; set; }

        [Required]
        [LocationMustBeInUS]
        [Display(Name = "Location:  ")]
        public string? Location { get; set; }

        [Required]
        [MustBeInYear(2023)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Posted:  ")]
        public DateTimeOffset? PostDate { get; set; }

        [Display(Name = "Company photo: ")]
        public byte[]? CorporateLogoData {get ; set;}
    }
}


