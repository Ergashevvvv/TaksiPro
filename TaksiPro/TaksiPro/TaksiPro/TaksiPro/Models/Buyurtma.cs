using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaksiPro.Models
{
    public class Buyurtma
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mijoz ismi majburiy.")]
        public string MijozIsm { get; set; }

        [Required(ErrorMessage = "Telefon raqam majburiy.")]
        [RegularExpression(@"^\d{9,15}$", ErrorMessage = "Telefon raqam noto'g'ri.")]
        public string TelefonRaqam { get; set; }

        [Required(ErrorMessage = "Boshlanish manzili majburiy.")]
        public string BoshlanishManzil { get; set; }

        [Required(ErrorMessage = "Tugash manzili majburiy.")]
        public string TugashManzil { get; set; }

        [Required(ErrorMessage = "Tarif tanlash majburiy.")]
        public int TariffId { get; set; }

        public Tariff Tariff { get; set; }
    }
}
