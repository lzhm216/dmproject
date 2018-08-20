
using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using SPA.DocumentManager.Authorization;

namespace SPA.DocumentManager.SpecialPlans.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="SpecialPlanAppPermissions" /> for all permission names. SpecialPlan
    ///</summary>
    public class SpecialPlanAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了SpecialPlan 的权限。
            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            var specialplan = administration.CreateChildPermission(SpecialPlanAppPermissions.SpecialPlan, L("SpecialPlan"));
            specialplan.CreateChildPermission(SpecialPlanAppPermissions.SpecialPlan_CreateSpecialPlan, L("CreateSpecialPlan"));
            specialplan.CreateChildPermission(SpecialPlanAppPermissions.SpecialPlan_EditSpecialPlan, L("EditSpecialPlan"));
            specialplan.CreateChildPermission(SpecialPlanAppPermissions.SpecialPlan_DeleteSpecialPlan, L("DeleteSpecialPlan"));
            specialplan.CreateChildPermission(SpecialPlanAppPermissions.SpecialPlan_BatchDeleteSpecialPlans, L("BatchDeleteSpecialPlans"));



            //// custom codes

            //// custom codes end
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, DocumentManagerConsts.LocalizationSourceName);
        }
    }
}