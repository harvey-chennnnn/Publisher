using System;
namespace ECommerce.CM.Model
{
	/// <summary>
	/// CMPro:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CMPro
	{
		public CMPro()
		{}
		#region Model
		private int? _aid;
		private int? _pid;
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
		public int? PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		#endregion Model

	}
}

