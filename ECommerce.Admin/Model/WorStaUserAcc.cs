using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// WorStaUserAcc:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WorStaUserAcc
	{
		public WorStaUserAcc()
		{}
		#region Model
		private int? _emplid;
		private int? _cid;
		/// <summary>
		/// 
		/// </summary>
		public int? EmplId
		{
			set{ _emplid=value;}
			get{return _emplid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CId
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		#endregion Model

	}
}

