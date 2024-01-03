using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace JobHub.Models
{
    // Ensures ID is a positive integer
    public class IDMustBePositiveAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int id && id > 0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("ID must be a positive integer.");
        }
    }

    // Ensures the first letter of the name is capitalized
    public class NameMustBeCapitalizedAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string name = value as string;
            if (name != null && char.IsUpper(name.FirstOrDefault()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("The first letter of the name must be capitalized.");
        }
    }

    // Ensures the location is in the United States
    public class LocationMustBeInUSAttribute : ValidationAttribute
    {
        private static readonly HashSet<string> ValidStates = new HashSet<string>
    {
        "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA",
        "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD",
        "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ",
        "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
        "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"
    };

        public LocationMustBeInUSAttribute()
        {
            ErrorMessage = "The location must be a valid U.S. state.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return ValidationResult.Success;
            }

            string location = value.ToString().ToUpper();

            // Extract the state part from the location string
            var statePart = location.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Last();

            if (ValidStates.Contains(statePart))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }



    // Ensures the date falls within a specific year
    public class MustBeInYearAttribute : ValidationAttribute
    {
        private readonly int _targetYear;

        public MustBeInYearAttribute(int targetYear)
        {
            _targetYear = targetYear;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTimeOffset dateValue && dateValue.Year == _targetYear)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult($"Date must be in the year {_targetYear}.");
        }
    }
}
