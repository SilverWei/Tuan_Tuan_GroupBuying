/**  版本信息模板在安装目录下，可自行修改。
* t_Announcement.cs
*
* 功 能： N/A
* 类 名： t_Announcement
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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TTGB.DAL
{
	/// <summary>
	/// 数据访问类:t_Announcement
	/// </summary>
	public partial class t_Announcement
	{
		public t_Announcement()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("A_ID", "t_Announcement"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int A_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_Announcement");
			strSql.Append(" where A_ID="+A_ID+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TTGB.Model.t_Announcement model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.A_Name != null)
			{
				strSql1.Append("A_Name,");
				strSql2.Append("'"+model.A_Name+"',");
			}
			if (model.UA_ID != null)
			{
				strSql1.Append("UA_ID,");
				strSql2.Append(""+model.UA_ID+",");
			}
			if (model.A_ReleaseDate != null)
			{
				strSql1.Append("A_ReleaseDate,");
				strSql2.Append("'"+model.A_ReleaseDate+"',");
			}
			if (model.A_Text != null)
			{
				strSql1.Append("A_Text,");
				strSql2.Append("'"+model.A_Text+"',");
			}
			strSql.Append("insert into t_Announcement(");
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
		public bool Update(TTGB.Model.t_Announcement model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_Announcement set ");
			if (model.A_Name != null)
			{
				strSql.Append("A_Name='"+model.A_Name+"',");
			}
			else
			{
				strSql.Append("A_Name= null ,");
			}
			if (model.UA_ID != null)
			{
				strSql.Append("UA_ID="+model.UA_ID+",");
			}
			else
			{
				strSql.Append("UA_ID= null ,");
			}
			if (model.A_ReleaseDate != null)
			{
				strSql.Append("A_ReleaseDate='"+model.A_ReleaseDate+"',");
			}
			else
			{
				strSql.Append("A_ReleaseDate= null ,");
			}
			if (model.A_Text != null)
			{
				strSql.Append("A_Text='"+model.A_Text+"',");
			}
			else
			{
				strSql.Append("A_Text= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where A_ID="+ model.A_ID+"");
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
		public bool Delete(int A_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_Announcement ");
			strSql.Append(" where A_ID="+A_ID+"" );
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
		public bool DeleteList(string A_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_Announcement ");
			strSql.Append(" where A_ID in ("+A_IDlist + ")  ");
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
		public TTGB.Model.t_Announcement GetModel(int A_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" A_ID,A_Name,UA_ID,A_ReleaseDate,A_Text ");
			strSql.Append(" from t_Announcement ");
			strSql.Append(" where A_ID="+A_ID+"" );
			TTGB.Model.t_Announcement model=new TTGB.Model.t_Announcement();
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
		public TTGB.Model.t_Announcement DataRowToModel(DataRow row)
		{
			TTGB.Model.t_Announcement model=new TTGB.Model.t_Announcement();
			if (row != null)
			{
				if(row["A_ID"]!=null && row["A_ID"].ToString()!="")
				{
					model.A_ID=int.Parse(row["A_ID"].ToString());
				}
				if(row["A_Name"]!=null)
				{
					model.A_Name=row["A_Name"].ToString();
				}
				if(row["UA_ID"]!=null && row["UA_ID"].ToString()!="")
				{
					model.UA_ID=int.Parse(row["UA_ID"].ToString());
				}
				if(row["A_ReleaseDate"]!=null && row["A_ReleaseDate"].ToString()!="")
				{
					model.A_ReleaseDate=DateTime.Parse(row["A_ReleaseDate"].ToString());
				}
				if(row["A_Text"]!=null)
				{
					model.A_Text=row["A_Text"].ToString();
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
			strSql.Append("select A_ID,A_Name,UA_ID,A_ReleaseDate,A_Text ");
			strSql.Append(" FROM t_Announcement ");
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
			strSql.Append(" A_ID,A_Name,UA_ID,A_ReleaseDate,A_Text ");
			strSql.Append(" FROM t_Announcement ");
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
			strSql.Append("select count(1) FROM t_Announcement ");
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
				strSql.Append("order by T.A_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_Announcement T ");
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

