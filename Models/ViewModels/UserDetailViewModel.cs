using System;
using System.ComponentModel.DataAnnotations;

namespace IndainCuisine.Models.ViewModels
{
    public class UserDetailViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "First name must be at least 3 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Last name must be at least 3 characters.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Please enter a user email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(255)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter an address.")]
        [StringLength(255)]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Please enter country.")]
        [StringLength(50)]
        public string? Country { get; set; }

        [Required(ErrorMessage = "Please enter card name.")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Card name must be at least 3 characters.")]
        public string? CardName { get; set; }

        [Required(ErrorMessage = "Please enter card number.")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Card number must be a 16-digit number.")]
        public string? CardNumber { get; set; }

        [Required(ErrorMessage = "Please enter expire date.")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/[0-9]{2}$", ErrorMessage = "Please enter a valid expiration date (MM/YY).")]
        [CustomDateValidation(ErrorMessage = "Expiration date should be greater than or equal to today.")]
        public string? ExpireDate { get; set; }

        [Required(ErrorMessage = "Please enter security number.")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Security number must be a 3-digit number.")]
        public string? SecurityNumber { get; set; }

        [Required(ErrorMessage = "Please enter username.")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Username must be at least 3 characters.")]
        [RegularExpression(@"^\S+$", ErrorMessage = "Username should not contain spaces.")]
        public string? UserName { get; set; }
    }

    public class CustomDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (DateTime.TryParse(value?.ToString(), out DateTime expirationDate))
            {
                if (expirationDate >= DateTime.Today)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
