using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using SPA.DocumentManager.Authorization;

namespace SPA.DocumentManager.SubSpecialPlans.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="SubSpecialPlanAppPermissions"/> for all permission names.
    /// </summary>
    public class SubSpecialPlanAppAuthorizationProvider : AuthorizationProvider
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了SubSpecialPlan 的权限。
            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration)
                            ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            var subspecialplan = administration.CreateChildPermission(SubSpecialPlanAppPermissions.SubSpecialPlan, L("SubSpecialPlan"));
            subspecialplan.CreateChildPermission(SubSpecialPlanAppPermissions.SubSpecialPlan_CreateSubSpecialPlan, L("CreateSubSpecialPlan"));
            subspecialplan.CreateChildPermission(SubSpecialPlanAppPermissions.SubSpecialPlan_EditSubSpecialPlan, L("EditSubSpecialPlan"));
            subspecialplan.CreateChildPermission(SubSpecialPlanAppPermissions.SubSpecialPlan_DeleteSubSpecialPlan, L("DeleteSubSpecialPlan"));
            subspecialplan.CreateChildPermission(SubSpecialPlanAppPermissions.SubSpecialPlan_BatchDeleteSubSpecialPlans, L("BatchDeleteSubSpecialPlans"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, DocumentManagerConsts.LocalizationSourceName);
        }
    }

}