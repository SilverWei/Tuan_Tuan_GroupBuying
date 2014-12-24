/**  版本信息模板在安装目录下，可自行修改。
* t_Users.cs
*
* 功 能： N/A
* 类 名： t_Users
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/24 16:15:53   N/A    初版
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
	public partial class t_Users
	{
		public t_Users()
		{}
		#region Model
		private int _u_id;
		private string _u_name;
		private string _u_realname;
		private bool _u_sex;
		private DateTime? _u_birthday;
		private string _u_phone;
		private DateTime _u_signup;
		private string _u_email;
		private int _u_rank=0;
		private int _u_points=0;
		private string _u_password;
		private string _u_note;
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
		public string U_Name
		{
			set{ _u_name=value;}
			get{return _u_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string U_RealName
		{
			set{ _u_realname=value;}
			get{return _u_realname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool U_Sex
		{
			set{ _u_sex=value;}
			get{return _u_sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? U_Birthday
		{
			set{ _u_birthday=value;}
			get{return _u_birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string U_Phone
		{
			set{ _u_phone=value;}
			get{return _u_phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime U_SignUP
		{
			set{ _u_signup=value;}
			get{return _u_signup;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string U_Email
		{
			set{ _u_email=value;}
			get{return _u_email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int U_Rank
		{
			set{ _u_rank=value;}
			get{return _u_rank;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int U_Points
		{
			set{ _u_points=value;}
			get{return _u_points;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string U_Password
		{
			set{ _u_password=value;}
			get{return _u_password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string U_Note
		{
			set{ _u_note=value;}
			get{return _u_note;}
		}
		#endregion Model

	}
}

