namespace SPA.DocumentManager.PlanProjects.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="PlanProjectAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class PlanProjectAppPermissions
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION

        /// <summary>
        /// PlanProject管理权限_自带查询授权
        /// </summary>
        public const string PlanProject = "Pages.PlanProject";

        /// <summary>
        /// PlanProject创建权限
        /// </summary>
        public const string PlanProject_CreatePlanProject = "Pages.PlanProject.CreatePlanProject";
        /// <summary>
        /// PlanProject修改权限
        /// </summary>
        public const string PlanProject_EditPlanProject = "Pages.PlanProject.EditPlanProject";
        /// <summary>
        /// PlanProject删除权限
        /// </summary>
        public const string PlanProject_DeletePlanProject = "Pages.PlanProject.DeletePlanProject";

        /// <summary>
        /// PlanProject批量删除权限
        /// </summary>
        public const string PlanProject_BatchDeletePlanProjects = "Pages.PlanProject.BatchDeletePlanProjects";

    }

}

