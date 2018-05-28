using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using SPA.DocumentManager.Authorization;

namespace SPA.DocumentManager.SubPlanProjects.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="SubPlanProjectAppPermissions"/> for all permission names.
    /// </summary>
    public class SubPlanProjectAppAuthorizationProvider : AuthorizationProvider
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了SubPlanProject 的权限。
            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration)
                            ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            var subplanproject = administration.CreateChildPermission(SubPlanProjectAppPermissions.SubPlanProject, L("SubPlanProject"));
            subplanproject.CreateChildPermission(SubPlanProjectAppPermissions.SubPlanProject_CreateSubPlanProject, L("CreateSubPlanProject"));
            subplanproject.CreateChildPermission(SubPlanProjectAppPermissions.SubPlanProject_EditSubPlanProject, L("EditSubPlanProject"));
            subplanproject.CreateChildPermission(SubPlanProjectAppPermissions.SubPlanProject_DeleteSubPlanProject, L("DeleteSubPlanProject"));
            subplanproject.CreateChildPermission(SubPlanProjectAppPermissions.SubPlanProject_BatchDeleteSubPlanProjects, L("BatchDeleteSubPlanProjects"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, DocumentManagerConsts.LocalizationSourceName);
        }
    }

}