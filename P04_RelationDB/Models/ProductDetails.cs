namespace P04_RelationDB.Models
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImggeUrl { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
