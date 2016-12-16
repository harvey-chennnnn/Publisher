using System;
namespace ECommerce.CM.Model
{
	/// <summary>
	/// CMAttchment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CMAttchment
	{
		public CMAttchment()
		{}
		#region Model
		private int _attid;
		private int? _aid;
		private int? _type;
		private string _attname;
		private int? _status;
		/// <summary>
		/// 
		/// </summary>
		public int AttId
		{
			set{ _attid=value;}
			get{return _attid;}
		}
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
		public int? Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AttName
		{
			set{ _attname=value;}
			get{return _attname;}
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

