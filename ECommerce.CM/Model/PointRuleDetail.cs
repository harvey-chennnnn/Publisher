using System;
namespace ECommerce.CM.Model
{
	/// <summary>
	/// PointRuleDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PointRuleDetail
	{
		public PointRuleDetail()
		{}
		#region Model
		private int _rdid;
		private int _rid;
		private int? _uid;
		private DateTime _addtime;
		private string _rxvalue;
		private string _ryvalue;
		/// <summary>
		/// 
		/// </summary>
		public int RDID
		{
			set{ _rdid=value;}
			get{return _rdid;}
		}
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
		public int? UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
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

