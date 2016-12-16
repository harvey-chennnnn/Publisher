﻿using System;

namespace ECommerce.Admin.Model
{
	/// <summary>
	/// OrgWorkStation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrgWorkStation
	{
		public OrgWorkStation()
		{}
		#region Model
		private int _wid;
		private long? _orgid;
		private string _size;
		private string _area;
		private string _manager;
		private string _managerphone;
		private DateTime? _starttime;
		private string _toolsmemo;
		/// <summary>
		/// 
		/// </summary>
		public int WId
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? OrgId
		{
			set{ _orgid=value;}
			get{return _orgid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Size
		{
			set{ _size=value;}
			get{return _size;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Area
		{
			set{ _area=value;}
			get{return _area;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Manager
		{
			set{ _manager=value;}
			get{return _manager;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ManagerPhone
		{
			set{ _managerphone=value;}
			get{return _managerphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ToolsMemo
		{
			set{ _toolsmemo=value;}
			get{return _toolsmemo;}
		}
		#endregion Model

	}
}

