/**  版本信息模板在安装目录下，可自行修改。
* t_OrdersGoods.cs
*
* 功 能： N/A
* 类 名： t_OrdersGoods
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/11 11:26:49   N/A    初版
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
	/// t_OrdersGoods:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_OrdersGoods
	{
		public t_OrdersGoods()
		{}
		#region Model
		private int _og_id;
		private int _o_id;
		private int _g_id;
		private int _gb_id;
		private int _og_quantity;
		private int _og_totalprice;
		/// <summary>
		/// 
		/// </summary>
		public int OG_ID
		{
			set{ _og_id=value;}
			get{return _og_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int O_ID
		{
			set{ _o_id=value;}
			get{return _o_id;}
		}
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
		public int GB_ID
		{
			set{ _gb_id=value;}
			get{return _gb_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OG_Quantity
		{
			set{ _og_quantity=value;}
			get{return _og_quantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OG_TotalPrice
		{
			set{ _og_totalprice=value;}
			get{return _og_totalprice;}
		}
		#endregion Model

	}
}

