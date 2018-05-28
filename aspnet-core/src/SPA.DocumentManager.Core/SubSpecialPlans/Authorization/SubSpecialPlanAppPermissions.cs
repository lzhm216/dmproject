namespace SPA.DocumentManager.SubSpecialPlans.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="SubSpecialPlanAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class SubSpecialPlanAppPermissions
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION

        /// <summary>
        /// SubSpecialPlan管理权限_自带查询授权
        /// </summary>
        public const string SubSpecialPlan = "Pages.SubSpecialPlan";

        /// <summary>
        /// SubSpecialPlan创建权限
        /// </summary>
        public const string SubSpecialPlan_CreateSubSpecialPlan = "Pages.SubSpecialPlan.CreateSubSpecialPlan";
        /// <summary>
        /// SubSpecialPlan修改权限
        /// </summary>
        public const string SubSpecialPlan_EditSubSpecialPlan = "Pages.SubSpecialPlan.EditSubSpecialPlan";
        /// <summary>
        /// SubSpecialPlan删除权限
        /// </summary>
        public const string SubSpecialPlan_DeleteSubSpecialPlan = "Pages.SubSpecialPlan.DeleteSubSpecialPlan";

        /// <summary>
        /// SubSpecialPlan批量删除权限
        /// </summary>
        public const string SubSpecialPlan_BatchDeleteSubSpecialPlans = "Pages.SubSpecialPlan.BatchDeleteSubSpecialPlans";

    }

}

