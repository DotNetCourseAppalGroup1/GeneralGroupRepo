namespace ProductDatabase.Entity
{
    public class Product : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
