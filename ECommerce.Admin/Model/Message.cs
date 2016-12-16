﻿using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// Message:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Message
	{
		public Message()
		{}
		#region Model
		private int _mid;
		private string _mecontent;
		private DateTime? _datetime;
		private int? _adminid;
		private int? _status;
		private int? _modefyaid;
		/// <summary>
		/// 
		/// </summary>
		public int MID
		{
			set{ _mid=value;}
			get{return _mid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MeContent
		{
			set{ _mecontent=value;}
			get{return _mecontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Datetime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AdminID
		{
			set{ _adminid=value;}
			get{return _adminid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ModefyAID
		{
			set{ _modefyaid=value;}
			get{return _modefyaid;}
		}
		#endregion Model

	}
}

