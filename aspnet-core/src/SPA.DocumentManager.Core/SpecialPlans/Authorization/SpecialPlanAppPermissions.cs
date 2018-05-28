namespace SPA.DocumentManager.SpecialPlans.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="SpecialPlanAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class SpecialPlanAppPermissions
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION

        /// <summary>
        /// SpecialPlan管理权限_自带查询授权
        /// </summary>
        public const string SpecialPlan = "Pages.SpecialPlan";

        /// <summary>
        /// SpecialPlan创建权限
        /// </summary>
        public const string SpecialPlan_CreateSpecialPlan = "Pages.SpecialPlan.CreateSpecialPlan";
        /// <summary>
        /// SpecialPlan修改权限
        /// </summary>
        public const string SpecialPlan_EditSpecialPlan = "Pages.SpecialPlan.EditSpecialPlan";
        /// <summary>
        /// SpecialPlan删除权限
        /// </summary>
        public const string SpecialPlan_DeleteSpecialPlan = "Pages.SpecialPlan.DeleteSpecialPlan";

        /// <summary>
        /// SpecialPlan批量删除权限
        /// </summary>
        public const string SpecialPlan_BatchDeleteSpecialPlans = "Pages.SpecialPlan.BatchDeleteSpecialPlans";

    }

}

