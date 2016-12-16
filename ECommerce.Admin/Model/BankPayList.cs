﻿using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// BankPayList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BankPayList
	{
		public BankPayList()
		{}
		#region Model
		private int _payid;
		private string _accountno;
		private string _orderno;
		private decimal? _fee;
		private int? _paytype;
		private DateTime? _paytime;
		private int? _status;
		private string _caccountno;
		/// <summary>
		/// 
		/// </summary>
		public int PayId
		{
			set{ _payid=value;}
			get{return _payid;}
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
		public string OrderNO
		{
			set{ _orderno=value;}
			get{return _orderno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Fee
		{
			set{ _fee=value;}
			get{return _fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PayType
		{
			set{ _paytype=value;}
			get{return _paytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PayTime
		{
			set{ _paytime=value;}
			get{return _paytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CAccountNo
		{
			set{ _caccountno=value;}
			get{return _caccountno;}
		}
		#endregion Model

	}
}

