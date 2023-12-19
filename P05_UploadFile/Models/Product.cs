using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace P05_UploadFile.Models
{
    public class Product
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Please enter information")]
        public string Name { get; set; }

        [DisplayName("Monny")]
        [Range(1,999,ErrorMessage ="{1} in {2}")]
        [Required(ErrorMessage = "Please enter information")]
        public double Price { get; set; }

        [DisplayName("Amount")]
        [Range(1, 99, ErrorMessage = "{1} in {2}")]
        [Required(ErrorMessage = "Please enter information")]
        public int Amount { get; set; }

        [DisplayName("Photo")]
        public string? Image { get; set; } = string.Empty; 
    }
}
