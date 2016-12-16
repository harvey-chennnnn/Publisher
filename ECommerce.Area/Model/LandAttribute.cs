using System;
namespace ECommerce.Area.Model
{
	/// <summary>
	/// LandAttribute:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LandAttribute
	{
		public LandAttribute()
		{}
		#region Model
		private int _laid;
		private string _laname;
		private int? _status;
		/// <summary>
		/// 
		/// </summary>
		public int LAId
		{
			set{ _laid=value;}
			get{return _laid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LAName
		{
			set{ _laname=value;}
			get{return _laname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

