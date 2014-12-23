/**  版本信息模板在安装目录下，可自行修改。
* t_OrdersGoods.cs
*
* 功 能： N/A
* 类 名： t_OrdersGoods
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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TTGB.DAL
{
	/// <summary>
	/// 数据访问类:t_OrdersGoods
	/// </summary>
	public partial class t_OrdersGoods
	{
		public t_OrdersGoods()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("OG_ID", "t_OrdersGoods"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int OG_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_OrdersGoods");
			strSql.Append(" where OG_ID="+OG_ID+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TTGB.Model.t_OrdersGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.O_ID != null)
			{
				strSql1.Append("O_ID,");
				strSql2.Append(""+model.O_ID+",");
			}
			if (model.G_ID != null)
			{
				strSql1.Append("G_ID,");
				strSql2.Append(""+model.G_ID+",");
			}
			if (model.GB_ID != null)
			{
				strSql1.Append("GB_ID,");
				strSql2.Append(""+model.GB_ID+",");
			}
			if (model.OG_Quantity != null)
			{
				strSql1.Append("OG_Quantity,");
				strSql2.Append(""+model.OG_Quantity+",");
			}
			if (model.OG_TotalPrice != null)
			{
				strSql1.Append("OG_TotalPrice,");
				strSql2.Append(""+model.OG_TotalPrice+",");
			}
			strSql.Append("insert into t_OrdersGoods(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			strSql.Append(";select @@IDENTITY");
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(TTGB.Model.t_OrdersGoods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_OrdersGoods set ");
			if (model.O_ID != null)
			{
				strSql.Append("O_ID="+model.O_ID+",");
			}
			if (model.G_ID != null)
			{
				strSql.Append("G_ID="+model.G_ID+",");
			}
			if (model.GB_ID != null)
			{
				strSql.Append("GB_ID="+model.GB_ID+",");
			}
			if (model.OG_Quantity != null)
			{
				strSql.Append("OG_Quantity="+model.OG_Quantity+",");
			}
			if (model.OG_TotalPrice != null)
			{
				strSql.Append("OG_TotalPrice="+model.OG_TotalPrice+",");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where OG_ID="+ model.OG_ID+"");
			int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int OG_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OrdersGoods ");
			strSql.Append(" where OG_ID="+OG_ID+"" );
			int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string OG_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OrdersGoods ");
			strSql.Append(" where OG_ID in ("+OG_IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TTGB.Model.t_OrdersGoods GetModel(int OG_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" OG_ID,O_ID,G_ID,GB_ID,OG_Quantity,OG_TotalPrice ");
			strSql.Append(" from t_OrdersGoods ");
			strSql.Append(" where OG_ID="+OG_ID+"" );
			TTGB.Model.t_OrdersGoods model=new TTGB.Model.t_OrdersGoods();
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TTGB.Model.t_OrdersGoods DataRowToModel(DataRow row)
		{
			TTGB.Model.t_OrdersGoods model=new TTGB.Model.t_OrdersGoods();
			if (row != null)
			{
				if(row["OG_ID"]!=null && row["OG_ID"].ToString()!="")
				{
					model.OG_ID=int.Parse(row["OG_ID"].ToString());
				}
				if(row["O_ID"]!=null && row["O_ID"].ToString()!="")
				{
					model.O_ID=int.Parse(row["O_ID"].ToString());
				}
				if(row["G_ID"]!=null && row["G_ID"].ToString()!="")
				{
					model.G_ID=int.Parse(row["G_ID"].ToString());
				}
				if(row["GB_ID"]!=null && row["GB_ID"].ToString()!="")
				{
					model.GB_ID=int.Parse(row["GB_ID"].ToString());
				}
				if(row["OG_Quantity"]!=null && row["OG_Quantity"].ToString()!="")
				{
					model.OG_Quantity=int.Parse(row["OG_Quantity"].ToString());
				}
				if(row["OG_TotalPrice"]!=null && row["OG_TotalPrice"].ToString()!="")
				{
					model.OG_TotalPrice=int.Parse(row["OG_TotalPrice"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select OG_ID,O_ID,G_ID,GB_ID,OG_Quantity,OG_TotalPrice ");
			strSql.Append(" FROM t_OrdersGoods ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" OG_ID,O_ID,G_ID,GB_ID,OG_Quantity,OG_TotalPrice ");
			strSql.Append(" FROM t_OrdersGoods ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_OrdersGoods ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.OG_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_OrdersGoods T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		*/

		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

