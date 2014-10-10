using System;
using WangFramework.ORM;
namespace W3WGame.Core.Entities
{
	/// <summary>
	/// AdminPower:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[TableName("AdminPower")]
	[PrimaryKey("PowerId")]
	public class AdminPower
	{
		/// <summary>
		/// 
		/// </summary>
		public int PowerId{ get;set;}
		
		/// <summary>
		/// 
		/// </summary>
		public string PowerName{ get;set;}
		
		/// <summary>
		/// 
		/// </summary>
		public string Action{ get;set;}
		
		/// <summary>
		/// 
		/// </summary>
		public string Controller{ get;set;}
		
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDate{ get;set;}
		
		/// <summary>
		/// 
		/// </summary>
		public string PowerCode{ get;set;}
		
		/// <summary>
		/// 
		/// </summary>
		public int MenuId{ get;set;}
		

	}
}
