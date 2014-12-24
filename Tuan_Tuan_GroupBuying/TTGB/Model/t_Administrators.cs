/**  版本信息模板在安装目录下，可自行修改。
* t_Administrators.cs
*
* 功 能： N/A
* 类 名： t_Administrators
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
	public partial class t_Administrators
	{
		public t_Administrators()
		{}
		#region Model
		private int _ua_id;
		private string _ua_name;
		private string _ua_realname;
		private bool _ua_sex;
		private DateTime? _ua_birthday;
		private string _ua_phone;
		private DateTime? _ua_signup;
		private string _ua_email;
		private string _ua_password;
		private string _ua_note;
		/// <summary>
		/// 
		/// </summary>
		public int UA_ID
		{
			set{ _ua_id=value;}
			get{return _ua_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UA_Name
		{
			set{ _ua_name=value;}
			get{return _ua_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UA_RealName
		{
			set{ _ua_realname=value;}
			get{return _ua_realname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool UA_Sex
		{
			set{ _ua_sex=value;}
			get{return _ua_sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UA_Birthday
		{
			set{ _ua_birthday=value;}
			get{return _ua_birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UA_Phone
		{
			set{ _ua_phone=value;}
			get{return _ua_phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UA_SignUP
		{
			set{ _ua_signup=value;}
			get{return _ua_signup;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UA_Email
		{
			set{ _ua_email=value;}
			get{return _ua_email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UA_Password
		{
			set{ _ua_password=value;}
			get{return _ua_password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UA_Note
		{
			set{ _ua_note=value;}
			get{return _ua_note;}
		}
		#endregion Model

	}
}

