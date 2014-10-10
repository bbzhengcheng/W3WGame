using System;
using WangFramework.ORM;
namespace W3WGame.Core.Entities
{
	/// <summary>
	/// AdminUser:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[TableName("AdminUser")]
	[PrimaryKey("AdminUserId")]
	public class AdminUser
	{
		/// <summary>
		/// 
		/// </summary>
		public int AdminUserId{ get;set;}
		
		/// <summary>
		/// 
		/// </summary>
		public string UserName{ get;set;}
		
		/// <summary>
		/// 
		/// </summary>
		public string Password{ get;set;}
		
		/// <summary>
		/// 
		/// </summary>
		public bool IsLock{ get;set;}
		
		/// <summary>
		/// 
		/// </summary>
		public int RoleId{ get;set;}
		

	}
}
