namespace MetaSolution.Data.Entities
{
    public class AttributeValue
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public Attribute? Attribute { get; set; }
        public List<AttributeValueLanguage>? AttributeValueLanguages { get; set; }
        public List<AttributeValueInProduct>? AttributeValueInProducts { get; set; }
    }
}
