namespace P04_RelationDB.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ComPonent ComPonent { get; set; }
    }
}
