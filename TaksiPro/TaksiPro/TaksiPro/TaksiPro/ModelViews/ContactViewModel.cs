namespace TaksiPro.ModelViews
{
	using System.ComponentModel.DataAnnotations;

	public class ContactViewModel
	{
		[Required(ErrorMessage = "Ism field is required.")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters are allowed in the name.")]
		public string Ism { get; set; }

		[Required(ErrorMessage = "Email field is required.")]
		[EmailAddress(ErrorMessage = "Invalid email format.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Phone number field is required.")]
		[RegularExpression(@"^\d+$", ErrorMessage = "Only numbers are allowed in the phone number.")]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Message field is required.")]
		[StringLength(999999, MinimumLength = 20, ErrorMessage = "The message must be at least 20 characters long.")]
		public string Message { get; set; }
	}

}
