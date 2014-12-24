/**  版本信息模板在安装目录下，可自行修改。
* t_GoodsSort2nd.cs
*
* 功 能： N/A
* 类 名： t_GoodsSort2nd
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/24 16:15:49   N/A    初版
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
	public partial class t_GoodsSort2nd
	{
		public t_GoodsSort2nd()
		{}
		#region Model
		private int _gs2_id;
		private string _gs2_name;
		private int _gs1_id;
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
		public string GS2_Name
		{
			set{ _gs2_name=value;}
			get{return _gs2_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int GS1_ID
		{
			set{ _gs1_id=value;}
			get{return _gs1_id;}
		}
		#endregion Model

	}
}

