using System.ComponentModel.DataAnnotations.Schema;

namespace P04_RelationDB.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int Amount { get; set; }
        public ProductExtend ProductExtend { get; set; }

        public int CategoryID { get; set; } //คีย์นอกที่เชื่อมที่ไปยังไฟล์ Category
        //[ForeignKey("TestID")]

        //public int TestID { get; set; }
        //[ForeignKey("TestID")]
        public Category Category { get; set; }
    }
}
