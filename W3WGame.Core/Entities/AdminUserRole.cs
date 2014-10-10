using System;
using WangFramework.ORM;
namespace W3WGame.Core.Entities
{
	/// <summary>
	/// AdimnUserRole:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    [TableName("AdminUserRole")]
	[PrimaryKey("RoleId")]
	public class AdminUserRole
	{
		/// <summary>
		/// 
		/// </summary>
		public int RoleId{ get;set;}
		
		/// <summary>
		/// 
		/// </summary>
		public string RoleName{ get;set;}
		

	}
}
