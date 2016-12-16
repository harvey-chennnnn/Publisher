using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// SWCompany:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SWCompany
	{
		public SWCompany()
		{}
		#region Model
		private int? _sworgid;
		private int? _corgid;
		/// <summary>
		/// 
		/// </summary>
		public int? SWOrgId
		{
			set{ _sworgid=value;}
			get{return _sworgid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? COrgId
		{
			set{ _corgid=value;}
			get{return _corgid;}
		}
		#endregion Model

	}
}

