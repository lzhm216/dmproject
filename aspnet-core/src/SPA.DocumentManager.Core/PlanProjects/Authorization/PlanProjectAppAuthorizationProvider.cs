using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using SPA.DocumentManager.Authorization;

namespace SPA.DocumentManager.PlanProjects.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="PlanProjectAppPermissions"/> for all permission names.
    /// </summary>
    public class PlanProjectAppAuthorizationProvider : AuthorizationProvider
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了PlanProject 的权限。
            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration)
                            ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            var planproject = administration.CreateChildPermission(PlanProjectAppPermissions.PlanProject, L("PlanProject"));
            planproject.CreateChildPermission(PlanProjectAppPermissions.PlanProject_CreatePlanProject, L("CreatePlanProject"));
            planproject.CreateChildPermission(PlanProjectAppPermissions.PlanProject_EditPlanProject, L("EditPlanProject"));
            planproject.CreateChildPermission(PlanProjectAppPermissions.PlanProject_DeletePlanProject, L("DeletePlanProject"));
            planproject.CreateChildPermission(PlanProjectAppPermissions.PlanProject_BatchDeletePlanProjects, L("BatchDeletePlanProjects"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, DocumentManagerConsts.LocalizationSourceName);
        }
    }

}