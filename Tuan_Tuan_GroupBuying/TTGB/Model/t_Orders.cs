/**  版本信息模板在安装目录下，可自行修改。
* t_Orders.cs
*
* 功 能： N/A
* 类 名： t_Orders
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
	public partial class t_Orders
	{
		public t_Orders()
		{}
		#region Model
		private int _o_id;
		private int _u_id;
		private DateTime _o_buydate;
		private string _o_cnsignee;
		private string _o_zipcode;
		private string _o_address;
		private string _o_phone;
		private int _osm_id;
		private int _os_id;
		private bool _o_gb_y_n;
		private string _o_message;
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
		public int U_ID
		{
			set{ _u_id=value;}
			get{return _u_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime O_buyDate
		{
			set{ _o_buydate=value;}
			get{return _o_buydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string O_Cnsignee
		{
			set{ _o_cnsignee=value;}
			get{return _o_cnsignee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string O_ZipCode
		{
			set{ _o_zipcode=value;}
			get{return _o_zipcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string O_Address
		{
			set{ _o_address=value;}
			get{return _o_address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string O_Phone
		{
			set{ _o_phone=value;}
			get{return _o_phone;}
		}
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
		public int OS_ID
		{
			set{ _os_id=value;}
			get{return _os_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool O_GB_Y_N
		{
			set{ _o_gb_y_n=value;}
			get{return _o_gb_y_n;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string O_Message
		{
			set{ _o_message=value;}
			get{return _o_message;}
		}
		#endregion Model

	}
}

