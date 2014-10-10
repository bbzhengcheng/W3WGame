using System;
using WangFramework.ORM;
namespace W3WGame.Core.Entities
{
	/// <summary>
	/// AdminRoleMenu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[TableName("AdminRoleMenu")]
	public class AdminRoleMenu
	{
		/// <summary>
		/// 
		/// </summary>
		public int RoleId{ get;set;}
		
		/// <summary>
		/// 
		/// </summary>
		public int MenuId{ get;set;}
		

	}
}
