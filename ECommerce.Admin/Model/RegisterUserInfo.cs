﻿using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// RegisterUserInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RegisterUserInfo
	{
		public RegisterUserInfo()
		{}
		#region Model
		private int _ruid;
		private string _provinceid;
		private string _cityid;
		private string _districtid;
		private string _address;
		private string _phone;
		private DateTime? _addtime;
		private string _name;
		/// <summary>
		/// 
		/// </summary>
		public int RUID
		{
			set{ _ruid=value;}
			get{return _ruid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProvinceId
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CityId
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DistrictId
		{
			set{ _districtid=value;}
			get{return _districtid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model

	}
}

