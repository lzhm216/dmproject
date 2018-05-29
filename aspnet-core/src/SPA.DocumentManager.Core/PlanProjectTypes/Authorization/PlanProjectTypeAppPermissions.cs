using SPA.DocumentManager.PlanProjectTypes;

namespace SPA.DocumentManager.PlanProjectTypes.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="PlanProjectTypeAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class PlanProjectTypeAppPermissions
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION

        /// <summary>
        /// PlanProjectType管理权限_自带查询授权
        /// </summary>
        public const string PlanProjectType = "Pages.PlanProjectType";

        /// <summary>
        /// PlanProjectType创建权限
        /// </summary>
        public const string PlanProjectType_CreatePlanProjectType = "Pages.PlanProjectType.CreatePlanProjectType";
        /// <summary>
        /// PlanProjectType修改权限
        /// </summary>
        public const string PlanProjectType_EditPlanProjectType = "Pages.PlanProjectType.EditPlanProjectType";
        /// <summary>
        /// PlanProjectType删除权限
        /// </summary>
        public const string PlanProjectType_DeletePlanProjectType = "Pages.PlanProjectType.DeletePlanProjectType";

        /// <summary>
        /// PlanProjectType批量删除权限
        /// </summary>
        public const string PlanProjectType_BatchDeletePlanProjectTypes = "Pages.PlanProjectType.BatchDeletePlanProjectTypes";

    }

}

