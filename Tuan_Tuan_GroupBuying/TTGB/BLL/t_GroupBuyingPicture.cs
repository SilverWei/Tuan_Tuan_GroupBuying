﻿/**  版本信息模板在安装目录下，可自行修改。
* t_GroupBuyingPicture.cs
*
* 功 能： N/A
* 类 名： t_GroupBuyingPicture
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
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using TTGB.Model;
namespace TTGB.BLL
{
	/// <summary>
	/// 1
	/// </summary>
	public partial class t_GroupBuyingPicture
	{
		private readonly TTGB.DAL.t_GroupBuyingPicture dal=new TTGB.DAL.t_GroupBuyingPicture();
		public t_GroupBuyingPicture()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int GBP_ID)
		{
			return dal.Exists(GBP_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(TTGB.Model.t_GroupBuyingPicture model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(TTGB.Model.t_GroupBuyingPicture model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int GBP_ID)
		{
			
			return dal.Delete(GBP_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string GBP_IDlist )
		{
			return dal.DeleteList(GBP_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TTGB.Model.t_GroupBuyingPicture GetModel(int GBP_ID)
		{
			
			return dal.GetModel(GBP_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public TTGB.Model.t_GroupBuyingPicture GetModelByCache(int GBP_ID)
		{
			
			string CacheKey = "t_GroupBuyingPictureModel-" + GBP_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(GBP_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TTGB.Model.t_GroupBuyingPicture)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TTGB.Model.t_GroupBuyingPicture> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TTGB.Model.t_GroupBuyingPicture> DataTableToList(DataTable dt)
		{
			List<TTGB.Model.t_GroupBuyingPicture> modelList = new List<TTGB.Model.t_GroupBuyingPicture>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TTGB.Model.t_GroupBuyingPicture model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

