namespace SPA.DocumentManager.Plans.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="PlanAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class PlanAppPermissions
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION

        /// <summary>
        /// Plan管理权限_自带查询授权
        /// </summary>
        public const string Plan = "Pages.Plan";

        /// <summary>
        /// Plan创建权限
        /// </summary>
        public const string Plan_CreatePlan = "Pages.Plan.CreatePlan";
        /// <summary>
        /// Plan修改权限
        /// </summary>
        public const string Plan_EditPlan = "Pages.Plan.EditPlan";
        /// <summary>
        /// Plan删除权限
        /// </summary>
        public const string Plan_DeletePlan = "Pages.Plan.DeletePlan";

        /// <summary>
        /// Plan批量删除权限
        /// </summary>
        public const string Plan_BatchDeletePlans = "Pages.Plan.BatchDeletePlans";

    }

}

