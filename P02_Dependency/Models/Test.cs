namespace P02_Dependency.Models
{
    public class Test : ITest
    {
        public Data Data { get; set; }

        public Test()
        {
            Data = new Data();
            GenrateData();
        }
        public Data GenrateData()
        {
            Data.Id = GetHashCode();
            Data.Message = "Test";

            return Data;
        }
    }
}
