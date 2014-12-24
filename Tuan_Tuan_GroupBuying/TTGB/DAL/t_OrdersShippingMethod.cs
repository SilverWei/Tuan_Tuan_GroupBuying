/**  版本信息模板在安装目录下，可自行修改。
* t_OrdersShippingMethod.cs
*
* 功 能： N/A
* 类 名： t_OrdersShippingMethod
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/24 16:15:51   N/A    初版
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
	/// 数据访问类:t_OrdersShippingMethod
	/// </summary>
	public partial class t_OrdersShippingMethod
	{
		public t_OrdersShippingMethod()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("OSM_ID", "t_OrdersShippingMethod"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int OSM_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_OrdersShippingMethod");
			strSql.Append(" where OSM_ID="+OSM_ID+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TTGB.Model.t_OrdersShippingMethod model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.OSM_Name != null)
			{
				strSql1.Append("OSM_Name,");
				strSql2.Append("'"+model.OSM_Name+"',");
			}
			strSql.Append("insert into t_OrdersShippingMethod(");
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
		public bool Update(TTGB.Model.t_OrdersShippingMethod model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_OrdersShippingMethod set ");
			if (model.OSM_Name != null)
			{
				strSql.Append("OSM_Name='"+model.OSM_Name+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where OSM_ID="+ model.OSM_ID+"");
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
		public bool Delete(int OSM_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OrdersShippingMethod ");
			strSql.Append(" where OSM_ID="+OSM_ID+"" );
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
		public bool DeleteList(string OSM_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OrdersShippingMethod ");
			strSql.Append(" where OSM_ID in ("+OSM_IDlist + ")  ");
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
		public TTGB.Model.t_OrdersShippingMethod GetModel(int OSM_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" OSM_ID,OSM_Name ");
			strSql.Append(" from t_OrdersShippingMethod ");
			strSql.Append(" where OSM_ID="+OSM_ID+"" );
			TTGB.Model.t_OrdersShippingMethod model=new TTGB.Model.t_OrdersShippingMethod();
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
		public TTGB.Model.t_OrdersShippingMethod DataRowToModel(DataRow row)
		{
			TTGB.Model.t_OrdersShippingMethod model=new TTGB.Model.t_OrdersShippingMethod();
			if (row != null)
			{
				if(row["OSM_ID"]!=null && row["OSM_ID"].ToString()!="")
				{
					model.OSM_ID=int.Parse(row["OSM_ID"].ToString());
				}
				if(row["OSM_Name"]!=null)
				{
					model.OSM_Name=row["OSM_Name"].ToString();
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
			strSql.Append("select OSM_ID,OSM_Name ");
			strSql.Append(" FROM t_OrdersShippingMethod ");
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
			strSql.Append(" OSM_ID,OSM_Name ");
			strSql.Append(" FROM t_OrdersShippingMethod ");
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
			strSql.Append("select count(1) FROM t_OrdersShippingMethod ");
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
				strSql.Append("order by T.OSM_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_OrdersShippingMethod T ");
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

