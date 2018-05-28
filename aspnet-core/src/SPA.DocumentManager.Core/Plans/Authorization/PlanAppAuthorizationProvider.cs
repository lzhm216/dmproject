using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using SPA.DocumentManager.Authorization;

namespace SPA.DocumentManager.Plans.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="PlanAppPermissions"/> for all permission names.
    /// </summary>
    public class PlanAppAuthorizationProvider : AuthorizationProvider
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了Plan 的权限。
            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration)
                            ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            var plan = administration.CreateChildPermission(PlanAppPermissions.Plan, L("Plan"));
            plan.CreateChildPermission(PlanAppPermissions.Plan_CreatePlan, L("CreatePlan"));
            plan.CreateChildPermission(PlanAppPermissions.Plan_EditPlan, L("EditPlan"));
            plan.CreateChildPermission(PlanAppPermissions.Plan_DeletePlan, L("DeletePlan"));
            plan.CreateChildPermission(PlanAppPermissions.Plan_BatchDeletePlans, L("BatchDeletePlans"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, DocumentManagerConsts.LocalizationSourceName);
        }
    }

}