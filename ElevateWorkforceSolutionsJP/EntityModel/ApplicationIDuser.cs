using Microsoft.AspNetCore.Identity;

namespace ElevateWorkforceSolutionsJP.EntityModel
{
    public class ApplicationIDuser: IdentityUser
    {
        public int? OrgId { get; set; }
    }
}
