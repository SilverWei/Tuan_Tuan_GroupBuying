/**  版本信息模板在安装目录下，可自行修改。
* t_GroupBuying.cs
*
* 功 能： N/A
* 类 名： t_GroupBuying
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/11 11:26:47   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace TTGB.Model
{
	/// <summary>
	/// t_GroupBuying:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_GroupBuying
	{
		public t_GroupBuying()
		{}
		#region Model
		private int _gb_id;
		private string _gb_name;
		private int? _gs2_id;
		private string _gb_brand;
		private int? _gb_marketprice;
		private int? _gb_groupprice;
		private DateTime? _gb_offerdate;
		private int? _gb_totalnumber;
		private int? _gb_participantsnumber;
		private bool _gb_state;
		private string _gb_pictureurl;
		private string _gb_text;
		private string _gb_note;
		/// <summary>
		/// 
		/// </summary>
		public int GB_ID
		{
			set{ _gb_id=value;}
			get{return _gb_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GB_Name
		{
			set{ _gb_name=value;}
			get{return _gb_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? GS2_ID
		{
			set{ _gs2_id=value;}
			get{return _gs2_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GB_Brand
		{
			set{ _gb_brand=value;}
			get{return _gb_brand;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? GB_MarketPrice
		{
			set{ _gb_marketprice=value;}
			get{return _gb_marketprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? GB_GroupPrice
		{
			set{ _gb_groupprice=value;}
			get{return _gb_groupprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? GB_OfferDate
		{
			set{ _gb_offerdate=value;}
			get{return _gb_offerdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? GB_TotalNumber
		{
			set{ _gb_totalnumber=value;}
			get{return _gb_totalnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? GB_participantsNumber
		{
			set{ _gb_participantsnumber=value;}
			get{return _gb_participantsnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool GB_State
		{
			set{ _gb_state=value;}
			get{return _gb_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GB_PictureUrl
		{
			set{ _gb_pictureurl=value;}
			get{return _gb_pictureurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GB_Text
		{
			set{ _gb_text=value;}
			get{return _gb_text;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GB_Note
		{
			set{ _gb_note=value;}
			get{return _gb_note;}
		}
		#endregion Model

	}
}

