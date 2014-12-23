/**  版本信息模板在安装目录下，可自行修改。
* t_OrdersShippingMethod.cs
*
* 功 能： N/A
* 类 名： t_OrdersShippingMethod
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
	/// t_OrdersShippingMethod:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_OrdersShippingMethod
	{
		public t_OrdersShippingMethod()
		{}
		#region Model
		private int _osm_id;
		private string _osm_name;
		/// <summary>
		/// 
		/// </summary>
		public int OSM_ID
		{
			set{ _osm_id=value;}
			get{return _osm_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OSM_Name
		{
			set{ _osm_name=value;}
			get{return _osm_name;}
		}
		#endregion Model

	}
}

