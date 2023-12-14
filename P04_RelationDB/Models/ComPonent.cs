using System.ComponentModel.DataAnnotations;

namespace P04_RelationDB.Models
{
    public class ComPonent
    {
        //[Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int FeatureID {  get; set; }
        public Feature Feature { get; set; }
    }
}
