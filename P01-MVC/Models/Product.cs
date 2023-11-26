using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace P01_MVC.Models
{
    public class Product
    {
        [Display(Name = "รหัส")]
        [Required(ErrorMessage = "กรุณากรอกรหัส")]
        public int id { get; set; }

        [Display(Name = "ชื่อสินค้า")]
        [Required(ErrorMessage = "กรุณากรอกชื่อ")]
        [StringLength(100,MinimumLength =3)]
        public string name { get; set; }

        [Display(Name = "ราคา")]
        [Range(5,double.MaxValue,ErrorMessage ="กรอกขั้นต่ำ {1}")]
        public double price { get; set; }

        [Display(Name = "จำนวน")]
        [Range(1,100,ErrorMessage ="อย่างน้อย {1} ไม่เกิน {2}")]
        public int amout { get; set; }
    }
}