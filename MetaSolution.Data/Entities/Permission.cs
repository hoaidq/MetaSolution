namespace MetaSolution.Data.Entities
{
    public class Permission
    {
        public Guid RoleId { get; set; }
        public Role? Role { get; set; }
        public int ModuleId { get; set; }
        public Module? Module { get; set; }
        public int ActionId { get; set; }
        public Action? Action { get; set; }
    }
}