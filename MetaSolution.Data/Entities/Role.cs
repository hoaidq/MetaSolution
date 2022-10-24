using Microsoft.AspNetCore.Identity;

namespace MetaSolution.Data.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public string? Description { get; set; }
        public List<Permission>? Permissions { get; set; }
    }
}