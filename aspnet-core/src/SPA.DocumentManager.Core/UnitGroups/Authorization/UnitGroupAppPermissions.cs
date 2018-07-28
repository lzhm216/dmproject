namespace SPA.DocumentManager.UnitGroups.Authorization
{
	 /// <summary>
	 /// 定义系统的权限名称的字符串常量。
	 /// <see cref="UnitGroupAppAuthorizationProvider"/>中对权限的定义.
	 /// </summary>
	public static  class UnitGroupAppPermissions
	{
		/// <summary>
		/// UnitGroup管理权限_自带查询授权
		/// </summary>
		public const string UnitGroup = "Pages.UnitGroup";

		/// <summary>
		/// UnitGroup创建权限
		/// </summary>
		public const string UnitGroup_CreateUnitGroup = "Pages.UnitGroup.CreateUnitGroup";

		/// <summary>
		/// UnitGroup修改权限
		/// </summary>
		public const string UnitGroup_EditUnitGroup = "Pages.UnitGroup.EditUnitGroup";

		/// <summary>
		/// UnitGroup删除权限
		/// </summary>
		public const string UnitGroup_DeleteUnitGroup = "Pages.UnitGroup.DeleteUnitGroup";

        /// <summary>
        /// UnitGroup批量删除权限
        /// </summary>
		public const string UnitGroup_BatchDeleteUnitGroups = "Pages.UnitGroup.BatchDeleteUnitGroups";


		
		//// custom codes 
		
        //// custom codes end
    }
	
}

