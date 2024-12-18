using System.ComponentModel.DataAnnotations;

namespace TaksiPro.Models
{
    public class Tariff
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tarif nomi majburiy.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Narx majburiy.")]
        [Range(0, double.MaxValue, ErrorMessage = "Narx musbat raqam bo'lishi kerak.")]
        public decimal Price { get; set; }
    }
}
