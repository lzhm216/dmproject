using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using SPA.DocumentManager.Authorization;

namespace SPA.DocumentManager.UnitGroups.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="UnitGroupAppPermissions"/> for all permission names.
    /// </summary>
    public class UnitGroupAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
			//在这里配置了UnitGroup 的权限。
            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));
 
            var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

			var unitgroup = administration.CreateChildPermission(UnitGroupAppPermissions.UnitGroup , L("UnitGroup"));
            unitgroup.CreateChildPermission(UnitGroupAppPermissions.UnitGroup_CreateUnitGroup, L("CreateUnitGroup"));
            unitgroup.CreateChildPermission(UnitGroupAppPermissions.UnitGroup_EditUnitGroup, L("EditUnitGroup"));           
            unitgroup.CreateChildPermission(UnitGroupAppPermissions.UnitGroup_DeleteUnitGroup, L("DeleteUnitGroup"));
			unitgroup.CreateChildPermission(UnitGroupAppPermissions.UnitGroup_BatchDeleteUnitGroups , L("BatchDeleteUnitGroups"));


			
			//// custom codes 
			
			//// custom codes end
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, DocumentManagerConsts.LocalizationSourceName);
        }
    }
}