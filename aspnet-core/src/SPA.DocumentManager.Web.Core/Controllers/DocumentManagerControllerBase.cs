using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace SPA.DocumentManager.Controllers
{
    public abstract class DocumentManagerControllerBase: AbpController
    {
        protected DocumentManagerControllerBase()
        {
            LocalizationSourceName = DocumentManagerConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
