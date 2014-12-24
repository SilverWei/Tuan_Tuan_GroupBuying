/**  版本信息模板在安装目录下，可自行修改。
* t_Announcement.cs
*
* 功 能： N/A
* 类 名： t_Announcement
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/24 16:15:47   N/A    初版
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
	public partial class t_Announcement
	{
		public t_Announcement()
		{}
		#region Model
		private int _a_id;
		private string _a_name;
		private int? _ua_id;
		private DateTime? _a_releasedate;
		private string _a_text;
		/// <summary>
		/// 
		/// </summary>
		public int A_ID
		{
			set{ _a_id=value;}
			get{return _a_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string A_Name
		{
			set{ _a_name=value;}
			get{return _a_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UA_ID
		{
			set{ _ua_id=value;}
			get{return _ua_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? A_ReleaseDate
		{
			set{ _a_releasedate=value;}
			get{return _a_releasedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string A_Text
		{
			set{ _a_text=value;}
			get{return _a_text;}
		}
		#endregion Model

	}
}

