/**  版本信息模板在安装目录下，可自行修改。
* t_Users.cs
*
* 功 能： N/A
* 类 名： t_Users
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
	/// 数据访问类:t_Users
	/// </summary>
	public partial class t_Users
	{
		public t_Users()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("U_ID", "t_Users"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int U_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_Users");
			strSql.Append(" where U_ID="+U_ID+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TTGB.Model.t_Users model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.U_Name != null)
			{
				strSql1.Append("U_Name,");
				strSql2.Append("'"+model.U_Name+"',");
			}
			if (model.U_RealName != null)
			{
				strSql1.Append("U_RealName,");
				strSql2.Append("'"+model.U_RealName+"',");
			}
			if (model.U_Sex != null)
			{
				strSql1.Append("U_Sex,");
				strSql2.Append(""+(model.U_Sex? 1 : 0) +",");
			}
			if (model.U_Birthday != null)
			{
				strSql1.Append("U_Birthday,");
				strSql2.Append("'"+model.U_Birthday+"',");
			}
			if (model.U_Phone != null)
			{
				strSql1.Append("U_Phone,");
				strSql2.Append("'"+model.U_Phone+"',");
			}
			if (model.U_SignUP != null)
			{
				strSql1.Append("U_SignUP,");
				strSql2.Append("'"+model.U_SignUP+"',");
			}
			if (model.U_Email != null)
			{
				strSql1.Append("U_Email,");
				strSql2.Append("'"+model.U_Email+"',");
			}
			if (model.U_Rank != null)
			{
				strSql1.Append("U_Rank,");
				strSql2.Append(""+model.U_Rank+",");
			}
			if (model.U_Points != null)
			{
				strSql1.Append("U_Points,");
				strSql2.Append(""+model.U_Points+",");
			}
			if (model.U_Password != null)
			{
				strSql1.Append("U_Password,");
				strSql2.Append("'"+model.U_Password+"',");
			}
			if (model.U_Note != null)
			{
				strSql1.Append("U_Note,");
				strSql2.Append("'"+model.U_Note+"',");
			}
			strSql.Append("insert into t_Users(");
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
		public bool Update(TTGB.Model.t_Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_Users set ");
			if (model.U_Name != null)
			{
				strSql.Append("U_Name='"+model.U_Name+"',");
			}
			else
			{
				strSql.Append("U_Name= null ,");
			}
			if (model.U_RealName != null)
			{
				strSql.Append("U_RealName='"+model.U_RealName+"',");
			}
			else
			{
				strSql.Append("U_RealName= null ,");
			}
			if (model.U_Sex != null)
			{
				strSql.Append("U_Sex="+ (model.U_Sex? 1 : 0) +",");
			}
			else
			{
				strSql.Append("U_Sex= null ,");
			}
			if (model.U_Birthday != null)
			{
				strSql.Append("U_Birthday='"+model.U_Birthday+"',");
			}
			else
			{
				strSql.Append("U_Birthday= null ,");
			}
			if (model.U_Phone != null)
			{
				strSql.Append("U_Phone='"+model.U_Phone+"',");
			}
			else
			{
				strSql.Append("U_Phone= null ,");
			}
			if (model.U_SignUP != null)
			{
				strSql.Append("U_SignUP='"+model.U_SignUP+"',");
			}
			else
			{
				strSql.Append("U_SignUP= null ,");
			}
			if (model.U_Email != null)
			{
				strSql.Append("U_Email='"+model.U_Email+"',");
			}
			else
			{
				strSql.Append("U_Email= null ,");
			}
			if (model.U_Rank != null)
			{
				strSql.Append("U_Rank="+model.U_Rank+",");
			}
			else
			{
				strSql.Append("U_Rank= null ,");
			}
			if (model.U_Points != null)
			{
				strSql.Append("U_Points="+model.U_Points+",");
			}
			else
			{
				strSql.Append("U_Points= null ,");
			}
			if (model.U_Password != null)
			{
				strSql.Append("U_Password='"+model.U_Password+"',");
			}
			else
			{
				strSql.Append("U_Password= null ,");
			}
			if (model.U_Note != null)
			{
				strSql.Append("U_Note='"+model.U_Note+"',");
			}
			else
			{
				strSql.Append("U_Note= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where U_ID="+ model.U_ID+"");
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
		public bool Delete(int U_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_Users ");
			strSql.Append(" where U_ID="+U_ID+"" );
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
		public bool DeleteList(string U_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_Users ");
			strSql.Append(" where U_ID in ("+U_IDlist + ")  ");
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
		public TTGB.Model.t_Users GetModel(int U_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" U_ID,U_Name,U_RealName,U_Sex,U_Birthday,U_Phone,U_SignUP,U_Email,U_Rank,U_Points,U_Password,U_Note ");
			strSql.Append(" from t_Users ");
			strSql.Append(" where U_ID="+U_ID+"" );
			TTGB.Model.t_Users model=new TTGB.Model.t_Users();
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
		public TTGB.Model.t_Users DataRowToModel(DataRow row)
		{
			TTGB.Model.t_Users model=new TTGB.Model.t_Users();
			if (row != null)
			{
				if(row["U_ID"]!=null && row["U_ID"].ToString()!="")
				{
					model.U_ID=int.Parse(row["U_ID"].ToString());
				}
				if(row["U_Name"]!=null)
				{
					model.U_Name=row["U_Name"].ToString();
				}
				if(row["U_RealName"]!=null)
				{
					model.U_RealName=row["U_RealName"].ToString();
				}
				if(row["U_Sex"]!=null && row["U_Sex"].ToString()!="")
				{
					if((row["U_Sex"].ToString()=="1")||(row["U_Sex"].ToString().ToLower()=="true"))
					{
						model.U_Sex=true;
					}
					else
					{
						model.U_Sex=false;
					}
				}
				if(row["U_Birthday"]!=null && row["U_Birthday"].ToString()!="")
				{
					model.U_Birthday=DateTime.Parse(row["U_Birthday"].ToString());
				}
				if(row["U_Phone"]!=null)
				{
					model.U_Phone=row["U_Phone"].ToString();
				}
				if(row["U_SignUP"]!=null && row["U_SignUP"].ToString()!="")
				{
					model.U_SignUP=DateTime.Parse(row["U_SignUP"].ToString());
				}
				if(row["U_Email"]!=null)
				{
					model.U_Email=row["U_Email"].ToString();
				}
				if(row["U_Rank"]!=null && row["U_Rank"].ToString()!="")
				{
					model.U_Rank=int.Parse(row["U_Rank"].ToString());
				}
				if(row["U_Points"]!=null && row["U_Points"].ToString()!="")
				{
					model.U_Points=int.Parse(row["U_Points"].ToString());
				}
				if(row["U_Password"]!=null)
				{
					model.U_Password=row["U_Password"].ToString();
				}
				if(row["U_Note"]!=null)
				{
					model.U_Note=row["U_Note"].ToString();
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
			strSql.Append("select U_ID,U_Name,U_RealName,U_Sex,U_Birthday,U_Phone,U_SignUP,U_Email,U_Rank,U_Points,U_Password,U_Note ");
			strSql.Append(" FROM t_Users ");
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
			strSql.Append(" U_ID,U_Name,U_RealName,U_Sex,U_Birthday,U_Phone,U_SignUP,U_Email,U_Rank,U_Points,U_Password,U_Note ");
			strSql.Append(" FROM t_Users ");
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
			strSql.Append("select count(1) FROM t_Users ");
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
				strSql.Append("order by T.U_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_Users T ");
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

