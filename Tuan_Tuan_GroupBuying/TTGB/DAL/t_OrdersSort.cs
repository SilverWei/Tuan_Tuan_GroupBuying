/**  版本信息模板在安装目录下，可自行修改。
* t_OrdersSort.cs
*
* 功 能： N/A
* 类 名： t_OrdersSort
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/11 11:26:50   N/A    初版
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
	/// 数据访问类:t_OrdersSort
	/// </summary>
	public partial class t_OrdersSort
	{
		public t_OrdersSort()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("OS_ID", "t_OrdersSort"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int OS_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_OrdersSort");
			strSql.Append(" where OS_ID="+OS_ID+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TTGB.Model.t_OrdersSort model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.OS_Name != null)
			{
				strSql1.Append("OS_Name,");
				strSql2.Append("'"+model.OS_Name+"',");
			}
			if (model.OS_B_Y_N != null)
			{
				strSql1.Append("OS_B_Y_N,");
				strSql2.Append(""+(model.OS_B_Y_N? 1 : 0) +",");
			}
			strSql.Append("insert into t_OrdersSort(");
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
		public bool Update(TTGB.Model.t_OrdersSort model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_OrdersSort set ");
			if (model.OS_Name != null)
			{
				strSql.Append("OS_Name='"+model.OS_Name+"',");
			}
			else
			{
				strSql.Append("OS_Name= null ,");
			}
			if (model.OS_B_Y_N != null)
			{
				strSql.Append("OS_B_Y_N="+ (model.OS_B_Y_N? 1 : 0) +",");
			}
			else
			{
				strSql.Append("OS_B_Y_N= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where OS_ID="+ model.OS_ID+"");
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
		public bool Delete(int OS_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OrdersSort ");
			strSql.Append(" where OS_ID="+OS_ID+"" );
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
		public bool DeleteList(string OS_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_OrdersSort ");
			strSql.Append(" where OS_ID in ("+OS_IDlist + ")  ");
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
		public TTGB.Model.t_OrdersSort GetModel(int OS_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" OS_ID,OS_Name,OS_B_Y_N ");
			strSql.Append(" from t_OrdersSort ");
			strSql.Append(" where OS_ID="+OS_ID+"" );
			TTGB.Model.t_OrdersSort model=new TTGB.Model.t_OrdersSort();
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
		public TTGB.Model.t_OrdersSort DataRowToModel(DataRow row)
		{
			TTGB.Model.t_OrdersSort model=new TTGB.Model.t_OrdersSort();
			if (row != null)
			{
				if(row["OS_ID"]!=null && row["OS_ID"].ToString()!="")
				{
					model.OS_ID=int.Parse(row["OS_ID"].ToString());
				}
				if(row["OS_Name"]!=null)
				{
					model.OS_Name=row["OS_Name"].ToString();
				}
				if(row["OS_B_Y_N"]!=null && row["OS_B_Y_N"].ToString()!="")
				{
					if((row["OS_B_Y_N"].ToString()=="1")||(row["OS_B_Y_N"].ToString().ToLower()=="true"))
					{
						model.OS_B_Y_N=true;
					}
					else
					{
						model.OS_B_Y_N=false;
					}
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
			strSql.Append("select OS_ID,OS_Name,OS_B_Y_N ");
			strSql.Append(" FROM t_OrdersSort ");
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
			strSql.Append(" OS_ID,OS_Name,OS_B_Y_N ");
			strSql.Append(" FROM t_OrdersSort ");
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
			strSql.Append("select count(1) FROM t_OrdersSort ");
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
				strSql.Append("order by T.OS_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_OrdersSort T ");
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

