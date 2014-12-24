/**  版本信息模板在安装目录下，可自行修改。
* t_GoodsSort1st.cs
*
* 功 能： N/A
* 类 名： t_GoodsSort1st
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
	public partial class t_GoodsSort1st
	{
		public t_GoodsSort1st()
		{}
		#region Model
		private int _gs1_id;
		private string _gs1_name;
		/// <summary>
		/// 
		/// </summary>
		public int GS1_ID
		{
			set{ _gs1_id=value;}
			get{return _gs1_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GS1_Name
		{
			set{ _gs1_name=value;}
			get{return _gs1_name;}
		}
		#endregion Model

	}
}

