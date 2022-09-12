﻿namespace MetaSolution.Data.Entities
{
    public class Module
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public int Level { get; set; }
        public int Order { get; set; }
        public int ParentId { get; set; }
        public List<ActionInModule>? ActionInModules { get; set; }
        public List<Permission>? Permissions { get; set; }
    }
}
