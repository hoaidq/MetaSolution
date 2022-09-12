namespace MetaSolution.Data.Entities
{
    public class Attribute
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<AttributeValue>? AttributeValue { get; set; }
    }
}
