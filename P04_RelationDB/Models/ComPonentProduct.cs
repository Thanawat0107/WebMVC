namespace P04_RelationDB.Models
{
    public class ComPonentProduct
    {

        public int ComponentId { get; set; }
        public ComPonent ComPonent { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
