using System.ComponentModel.DataAnnotations;

namespace TaksiPro.Models
{
	public class Contact
	{
		public int Id { get; set; }
		public string Ism { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Message { get; set; }
	}
}
