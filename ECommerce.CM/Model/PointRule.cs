using System;
namespace ECommerce.CM.Model
{
	/// <summary>
	/// PointRule:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PointRule
	{
		public PointRule()
		{}
		#region Model
		private int _rid;
		private string _rname;
		private string _rxvalue;
		private string _ryvalue;
		/// <summary>
		/// 
		/// </summary>
		public int RID
		{
			set{ _rid=value;}
			get{return _rid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RName
		{
			set{ _rname=value;}
			get{return _rname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RxValue
		{
			set{ _rxvalue=value;}
			get{return _rxvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RyValue
		{
			set{ _ryvalue=value;}
			get{return _ryvalue;}
		}
		#endregion Model

	}
}

