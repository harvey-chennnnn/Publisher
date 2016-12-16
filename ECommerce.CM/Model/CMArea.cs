using System;
namespace ECommerce.CM.Model
{
	/// <summary>
	/// CMArea:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CMArea
	{
		public CMArea()
		{}
		#region Model
		private int? _aid;
		private string _areaid;
		/// <summary>
		/// 
		/// </summary>
		public int? AId
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AreaId
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		#endregion Model

	}
}

