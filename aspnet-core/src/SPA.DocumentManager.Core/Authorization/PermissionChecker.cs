using Abp.Authorization;
using SPA.DocumentManager.Authorization.Roles;
using SPA.DocumentManager.Authorization.Users;

namespace SPA.DocumentManager.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
