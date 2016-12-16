using System;

namespace ECommerce.Admin.Model
{
	/// <summary>
	/// SYS_DepartmentInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SYS_DepartmentInfo
	{
		public SYS_DepartmentInfo()
		{}
		#region Model
		private int _dpt_id;
		private string _dpt_name;
		private int? _dpt_parentid;
		private int? _dpt_level;
		private string _dpt_securityid;
		/// <summary>
		/// 
		/// </summary>
		public int Dpt_Id
		{
			set{ _dpt_id=value;}
			get{return _dpt_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Dpt_Name
		{
			set{ _dpt_name=value;}
			get{return _dpt_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Dpt_ParentId
		{
			set{ _dpt_parentid=value;}
			get{return _dpt_parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Dpt_Level
		{
			set{ _dpt_level=value;}
			get{return _dpt_level;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Dpt_SecurityID
		{
			set{ _dpt_securityid=value;}
			get{return _dpt_securityid;}
		}
		#endregion Model

	}
}

