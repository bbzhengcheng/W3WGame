using System;
using WangFramework.ORM;
namespace W3WGame.Core.Entities
{
	/// <summary>
	/// AdminMenu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[TableName("AdminMenu")]
	[PrimaryKey("MenuId")]
	public class AdminMenu
	{
		/// <summary>
		/// 
		/// </summary>
		public int MenuId{ get;set;}
		
		/// <summary>
		/// 
		/// </summary>
		public string MenuName{ get;set;}
		
		/// <summary>
		/// 
		/// </summary>
		public string LinkUrl{ get;set;}
		
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDate{ get;set;}
		
		/// <summary>
		/// 
		/// </summary>
		public int ParentId{ get;set;}
		
		/// <summary>
		/// 
		/// </summary>
		public int SortOrder{ get;set;}
		

	}
}
