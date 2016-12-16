using System;
namespace ECommerce.Area.Model
{
	/// <summary>
	/// LandCustomer:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LandCustomer
	{
		public LandCustomer()
		{}
		#region Model
		private int _lcid;
		private int? _lid;
		private int? _cid;
		private string _zwname;
		private decimal? _area;
		/// <summary>
		/// 
		/// </summary>
		public int LCId
		{
			set{ _lcid=value;}
			get{return _lcid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LId
		{
			set{ _lid=value;}
			get{return _lid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CId
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ZwName
		{
			set{ _zwname=value;}
			get{return _zwname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Area
		{
			set{ _area=value;}
			get{return _area;}
		}
		#endregion Model

	}
}

