using System;
namespace ECommerce.CM.Model
{
	/// <summary>
	/// CMArticleType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CMArticleType
	{
		public CMArticleType()
		{}
		#region Model
		private int _atid;
		private string _atname;
		private string _displaycss;
		private string _colorvalue;
		/// <summary>
		/// 
		/// </summary>
		public int ATId
		{
			set{ _atid=value;}
			get{return _atid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ATName
		{
			set{ _atname=value;}
			get{return _atname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DisplayCss
		{
			set{ _displaycss=value;}
			get{return _displaycss;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ColorValue
		{
			set{ _colorvalue=value;}
			get{return _colorvalue;}
		}
		#endregion Model

	}
}

