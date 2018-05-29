using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using SPA.DocumentManager.Authorization;
using SPA.DocumentManager.PlanProjectTypes;

namespace SPA.DocumentManager.PlanProjectTypes.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="PlanProjectTypeAppPermissions"/> for all permission names.
    /// </summary>
    public class PlanProjectTypeAppAuthorizationProvider : AuthorizationProvider
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了PlanProjectType 的权限。
            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration)
                            ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            var planprojecttype = administration.CreateChildPermission(PlanProjectTypeAppPermissions.PlanProjectType, L("PlanProjectType"));
            planprojecttype.CreateChildPermission(PlanProjectTypeAppPermissions.PlanProjectType_CreatePlanProjectType, L("CreatePlanProjectType"));
            planprojecttype.CreateChildPermission(PlanProjectTypeAppPermissions.PlanProjectType_EditPlanProjectType, L("EditPlanProjectType"));
            planprojecttype.CreateChildPermission(PlanProjectTypeAppPermissions.PlanProjectType_DeletePlanProjectType, L("DeletePlanProjectType"));
            planprojecttype.CreateChildPermission(PlanProjectTypeAppPermissions.PlanProjectType_BatchDeletePlanProjectTypes, L("BatchDeletePlanProjectTypes"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, DocumentManagerConsts.LocalizationSourceName);
        }
    }

}