/**  版本信息模板在安装目录下，可自行修改。
* t_Goods.cs
*
* 功 能： N/A
* 类 名： t_Goods
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/24 16:15:48   N/A    初版
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
	/// 1
	/// </summary>
	[Serializable]
	public partial class t_Goods
	{
		public t_Goods()
		{}
		#region Model
		private int _g_id;
		private string _g_name;
		private int _gs2_id;
		private string _g_brand;
		private decimal _g_marketprice;
		private decimal _g_userprice;
		private int _g_buypoints;
		private DateTime _g_offerdate;
		private int _g_amount;
		private bool _g_state;
		private string _g_pictureurl;
		private string _g_text;
		private string _g_note;
		/// <summary>
		/// 
		/// </summary>
		public int G_ID
		{
			set{ _g_id=value;}
			get{return _g_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string G_Name
		{
			set{ _g_name=value;}
			get{return _g_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int GS2_ID
		{
			set{ _gs2_id=value;}
			get{return _gs2_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string G_Brand
		{
			set{ _g_brand=value;}
			get{return _g_brand;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal G_MarketPrice
		{
			set{ _g_marketprice=value;}
			get{return _g_marketprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal G_UserPrice
		{
			set{ _g_userprice=value;}
			get{return _g_userprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int G_BuyPoints
		{
			set{ _g_buypoints=value;}
			get{return _g_buypoints;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime G_OfferDate
		{
			set{ _g_offerdate=value;}
			get{return _g_offerdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int G_Amount
		{
			set{ _g_amount=value;}
			get{return _g_amount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool G_State
		{
			set{ _g_state=value;}
			get{return _g_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string G_PictureUrl
		{
			set{ _g_pictureurl=value;}
			get{return _g_pictureurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string G_Text
		{
			set{ _g_text=value;}
			get{return _g_text;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string G_Note
		{
			set{ _g_note=value;}
			get{return _g_note;}
		}
		#endregion Model

	}
}

