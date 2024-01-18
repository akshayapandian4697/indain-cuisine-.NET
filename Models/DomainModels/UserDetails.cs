using System.ComponentModel.DataAnnotations;

namespace IndainCuisine.Models.DomainModels
{
    public class UserDetails
    {
		public int Id { get; set; }
		[Required(ErrorMessage = "Please enter a first name.")]
		[StringLength(255)]
		public string? FirstName { get; set; }

		[Required(ErrorMessage = "Please enter a last name.")]
		[StringLength(255)]
		public string? LastName { get; set; }

		[Required(ErrorMessage = "Please enter a user email.")]
		[StringLength(255)]
		public string? Email { get; set; }

		[Required(ErrorMessage = "Please enter a address.")]
		[StringLength(255)]
		public string? Address { get; set; }


		[Required(ErrorMessage = "Please enter country.")]
		[StringLength(50)]
		public string? Country { get; set; }


		[Required(ErrorMessage = "Please enter card name.")]
		[StringLength(255)]
		public string? CardName { get; set; }


		[Required(ErrorMessage = "Please enter card number.")]
		[StringLength(255)]
		public string? CardNumber { get; set; }


		[Required(ErrorMessage = "Please enter expire date.")]
		[StringLength(40)]

		public string? ExpireDate { get; set; }


		[Required(ErrorMessage = "Please enter security number.")]
		[StringLength(3)]
		public string? SecurityNumber { get; set; }


		[Required(ErrorMessage = "Please enter username.")]
		[StringLength(255)]
		public string? UserName { get; set; }
	}
}
