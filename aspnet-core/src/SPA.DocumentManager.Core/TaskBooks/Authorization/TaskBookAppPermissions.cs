namespace SPA.DocumentManager.TaskBooks.Authorization
{
	 /// <summary>
	 /// 定义系统的权限名称的字符串常量。
	 /// <see cref="TaskBookAppAuthorizationProvider"/>中对权限的定义.
	 /// </summary>
	public static  class TaskBookAppPermissions
	{
		/// <summary>
		/// TaskBook管理权限_自带查询授权
		/// </summary>
		public const string TaskBook = "Pages.TaskBook";

		/// <summary>
		/// TaskBook创建权限
		/// </summary>
		public const string TaskBook_CreateTaskBook = "Pages.TaskBook.CreateTaskBook";

		/// <summary>
		/// TaskBook修改权限
		/// </summary>
		public const string TaskBook_EditTaskBook = "Pages.TaskBook.EditTaskBook";

		/// <summary>
		/// TaskBook删除权限
		/// </summary>
		public const string TaskBook_DeleteTaskBook = "Pages.TaskBook.DeleteTaskBook";

        /// <summary>
        /// TaskBook批量删除权限
        /// </summary>
		public const string TaskBook_BatchDeleteTaskBooks = "Pages.TaskBook.BatchDeleteTaskBooks";


		
		//// custom codes 
		
        //// custom codes end
    }
	
}

