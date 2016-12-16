using System;
namespace ECommerce.Admin.Model
{
	/// <summary>
	/// OrgArea:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrgArea
	{
		public OrgArea()
		{}
		#region Model
		private string _areaid;
		private string _areaname;
		private int? _arealevel;
		private string _parentid;
		private int? _status=0;
		/// <summary>
		/// 
		/// </summary>
		public string AreaId
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AreaName
		{
			set{ _areaname=value;}
			get{return _areaname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AreaLevel
		{
			set{ _arealevel=value;}
			get{return _arealevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
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

