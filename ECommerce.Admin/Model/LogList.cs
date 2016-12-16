﻿using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// LogList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LogList
	{
		public LogList()
		{}
		#region Model
		private long _llid;
		private int? _emplid;
		private int? _pid;
		private string _tname;
		private DateTime? _mdate= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public long LLID
		{
			set{ _llid=value;}
			get{return _llid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmplId
		{
			set{ _emplid=value;}
			get{return _emplid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PId
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TName
		{
			set{ _tname=value;}
			get{return _tname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? MDate
		{
			set{ _mdate=value;}
			get{return _mdate;}
		}
		#endregion Model

	}
}

