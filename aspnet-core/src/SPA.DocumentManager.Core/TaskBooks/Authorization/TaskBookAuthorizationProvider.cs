using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using SPA.DocumentManager.Authorization;

namespace SPA.DocumentManager.TaskBooks.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="TaskBookAppPermissions"/> for all permission names.
    /// </summary>
    public class TaskBookAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
			//在这里配置了TaskBook 的权限。
            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));
 
            var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

			var taskbook = administration.CreateChildPermission(TaskBookAppPermissions.TaskBook , L("TaskBook"));
            taskbook.CreateChildPermission(TaskBookAppPermissions.TaskBook_CreateTaskBook, L("CreateTaskBook"));
            taskbook.CreateChildPermission(TaskBookAppPermissions.TaskBook_EditTaskBook, L("EditTaskBook"));           
            taskbook.CreateChildPermission(TaskBookAppPermissions.TaskBook_DeleteTaskBook, L("DeleteTaskBook"));
			taskbook.CreateChildPermission(TaskBookAppPermissions.TaskBook_BatchDeleteTaskBooks , L("BatchDeleteTaskBooks"));


			
			//// custom codes 
			
			//// custom codes end
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, DocumentManagerConsts.LocalizationSourceName);
        }
    }
}