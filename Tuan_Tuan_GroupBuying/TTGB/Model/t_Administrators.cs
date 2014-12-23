/**  版本信息模板在安装目录下，可自行修改。
* t_Administrators.cs
*
* 功 能： N/A
* 类 名： t_Administrators
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/11 11:26:45   N/A    初版
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
	/// t_Administrators:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_Administrators
	{
		public t_Administrators()
		{}
		#region Model
		private int _ua_id;
		private string _ua _name;
		private string _ua _realname;
		private bool _ua _sex;
		private DateTime? _ua _birthday;
		private string _ua _phone;
		private DateTime? _ua _signup;
		private string _ua _email;
		private string _ua _password;
		private string _ua _note;
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
		public string UA _Name
		{
			set{ _ua _name=value;}
			get{return _ua _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UA _RealName
		{
			set{ _ua _realname=value;}
			get{return _ua _realname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool UA _Sex
		{
			set{ _ua _sex=value;}
			get{return _ua _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UA _Birthday
		{
			set{ _ua _birthday=value;}
			get{return _ua _birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UA _Phone
		{
			set{ _ua _phone=value;}
			get{return _ua _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UA _SignUP
		{
			set{ _ua _signup=value;}
			get{return _ua _signup;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UA _Email
		{
			set{ _ua _email=value;}
			get{return _ua _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UA _Password
		{
			set{ _ua _password=value;}
			get{return _ua _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UA _Note
		{
			set{ _ua _note=value;}
			get{return _ua _note;}
		}
		#endregion Model

	}
}

