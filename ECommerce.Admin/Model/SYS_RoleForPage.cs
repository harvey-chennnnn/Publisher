﻿using System;

namespace ECommerce.Admin.Model
{
	/// <summary>
	/// SYS_RoleForPage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SYS_RoleForPage
	{
		public SYS_RoleForPage()
		{}
		#region Model
		private int _rfp_id;
		private int? _role_id;
		private int? _pc_id;
		/// <summary>
		/// 
		/// </summary>
		public int RFP_Id
		{
			set{ _rfp_id=value;}
			get{return _rfp_id;}
		}
		/// <summary>
		/// 可以给用户、角色、部门等设置功能，登录时根据三者的设置进行功能合并
		/// </summary>
		public int? Role_Id
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PC_Id
		{
			set{ _pc_id=value;}
			get{return _pc_id;}
		}
		#endregion Model

	}
}

