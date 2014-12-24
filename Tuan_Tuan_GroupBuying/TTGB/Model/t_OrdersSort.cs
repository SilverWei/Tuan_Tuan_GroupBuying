/**  版本信息模板在安装目录下，可自行修改。
* t_OrdersSort.cs
*
* 功 能： N/A
* 类 名： t_OrdersSort
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/24 16:15:52   N/A    初版
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
	public partial class t_OrdersSort
	{
		public t_OrdersSort()
		{}
		#region Model
		private int _os_id;
		private string _os_name;
		private bool _os_b_y_n;
		/// <summary>
		/// 
		/// </summary>
		public int OS_ID
		{
			set{ _os_id=value;}
			get{return _os_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OS_Name
		{
			set{ _os_name=value;}
			get{return _os_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool OS_B_Y_N
		{
			set{ _os_b_y_n=value;}
			get{return _os_b_y_n;}
		}
		#endregion Model

	}
}

