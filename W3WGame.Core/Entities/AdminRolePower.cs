using System;
using WangFramework.ORM;
namespace W3WGame.Core.Entities
{
	/// <summary>
	/// AdminRolePower:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[TableName("AdminRolePower")]
	public class AdminRolePower
	{
		/// <summary>
		/// 
		/// </summary>
		public int RoleId{ get;set;}
		
		/// <summary>
		/// 
		/// </summary>
		public int PowerId{ get;set;}
		

	}
}
