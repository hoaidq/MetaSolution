namespace MetaSolution.Data.Entities
{
    public class Action
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public List<ActionInModule>? ActionInModules { get; set; }
        public List<Permission>? Permissions { get; set; }
    }
}
