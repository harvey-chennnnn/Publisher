﻿using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// BankAccountOperateList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BankAccountOperateList
	{
		public BankAccountOperateList()
		{}
		#region Model
		private int _aoid;
		private string _accountno;
		private int? _optype;
		private DateTime? _time;
		private int? _emplid;
		/// <summary>
		/// 
		/// </summary>
		public int AOId
		{
			set{ _aoid=value;}
			get{return _aoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AccountNo
		{
			set{ _accountno=value;}
			get{return _accountno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OpType
		{
			set{ _optype=value;}
			get{return _optype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? time
		{
			set{ _time=value;}
			get{return _time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmplId
		{
			set{ _emplid=value;}
			get{return _emplid;}
		}
		#endregion Model

	}
}

