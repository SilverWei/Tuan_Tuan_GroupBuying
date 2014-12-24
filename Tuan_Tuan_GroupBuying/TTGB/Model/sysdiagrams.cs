/**  版本信息模板在安装目录下，可自行修改。
* sysdiagrams.cs
*
* 功 能： N/A
* 类 名： sysdiagrams
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/24 16:15:46   N/A    初版
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
	public partial class sysdiagrams
	{
		public sysdiagrams()
		{}
		#region Model
		private string _name;
		private int _principal_id;
		private int _diagram_id;
		private int? _version;
		private byte[] _definition;
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int principal_id
		{
			set{ _principal_id=value;}
			get{return _principal_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int diagram_id
		{
			set{ _diagram_id=value;}
			get{return _diagram_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? version
		{
			set{ _version=value;}
			get{return _version;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] definition
		{
			set{ _definition=value;}
			get{return _definition;}
		}
		#endregion Model

	}
}

