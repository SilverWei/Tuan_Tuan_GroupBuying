/**  版本信息模板在安装目录下，可自行修改。
* t_GoodsPicture.cs
*
* 功 能： N/A
* 类 名： t_GoodsPicture
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
	public partial class t_GoodsPicture
	{
		public t_GoodsPicture()
		{}
		#region Model
		private int _gp_id;
		private int _g_id;
		private string _gp_url;
		/// <summary>
		/// 
		/// </summary>
		public int GP_ID
		{
			set{ _gp_id=value;}
			get{return _gp_id;}
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
		public string GP_Url
		{
			set{ _gp_url=value;}
			get{return _gp_url;}
		}
		#endregion Model

	}
}

