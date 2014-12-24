/**  版本信息模板在安装目录下，可自行修改。
* t_GroupBuyingPicture.cs
*
* 功 能： N/A
* 类 名： t_GroupBuyingPicture
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/24 16:15:50   N/A    初版
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
	public partial class t_GroupBuyingPicture
	{
		public t_GroupBuyingPicture()
		{}
		#region Model
		private int _gbp_id;
		private int _gb_id;
		private string _gbp_url;
		/// <summary>
		/// 
		/// </summary>
		public int GBP_ID
		{
			set{ _gbp_id=value;}
			get{return _gbp_id;}
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
		public string GBP_Url
		{
			set{ _gbp_url=value;}
			get{return _gbp_url;}
		}
		#endregion Model

	}
}

