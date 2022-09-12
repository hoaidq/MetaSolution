namespace MetaSolution.Data.Entities
{
    public class ActionInModule
    {
        public int ModuleId { get; set; }
        public Module? Module { get; set; }
        public int ActionId { get; set; }
        public Action? Action { get; set; }
    }
}