namespace SPA.DocumentManager.SubPlanProjects.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="SubPlanProjectAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class SubPlanProjectAppPermissions
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION

        /// <summary>
        /// SubPlanProject管理权限_自带查询授权
        /// </summary>
        public const string SubPlanProject = "Pages.SubPlanProject";

        /// <summary>
        /// SubPlanProject创建权限
        /// </summary>
        public const string SubPlanProject_CreateSubPlanProject = "Pages.SubPlanProject.CreateSubPlanProject";
        /// <summary>
        /// SubPlanProject修改权限
        /// </summary>
        public const string SubPlanProject_EditSubPlanProject = "Pages.SubPlanProject.EditSubPlanProject";
        /// <summary>
        /// SubPlanProject删除权限
        /// </summary>
        public const string SubPlanProject_DeleteSubPlanProject = "Pages.SubPlanProject.DeleteSubPlanProject";

        /// <summary>
        /// SubPlanProject批量删除权限
        /// </summary>
        public const string SubPlanProject_BatchDeleteSubPlanProjects = "Pages.SubPlanProject.BatchDeleteSubPlanProjects";

    }

}

