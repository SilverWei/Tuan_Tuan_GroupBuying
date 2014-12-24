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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TTGB.DAL
{
	/// <summary>
	/// 数据访问类:t_Administrators
	/// </summary>
	public partial class t_Administrators
	{
		public t_Administrators()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("UA_ID", "t_Administrators"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UA_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_Administrators");
			strSql.Append(" where UA_ID="+UA_ID+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TTGB.Model.t_Administrators model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.UA_Name != null)
			{
				strSql1.Append("UA_Name,");
				strSql2.Append("'"+model.UA_Name+"',");
			}
			if (model.UA_RealName != null)
			{
				strSql1.Append("UA_RealName,");
				strSql2.Append("'"+model.UA_RealName+"',");
			}
			if (model.UA_Sex != null)
			{
				strSql1.Append("UA_Sex,");
				strSql2.Append(""+(model.UA_Sex? 1 : 0) +",");
			}
			if (model.UA_Birthday != null)
			{
				strSql1.Append("UA_Birthday,");
				strSql2.Append("'"+model.UA_Birthday+"',");
			}
			if (model.UA_Phone != null)
			{
				strSql1.Append("UA_Phone,");
				strSql2.Append("'"+model.UA_Phone+"',");
			}
			if (model.UA_SignUP != null)
			{
				strSql1.Append("UA_SignUP,");
				strSql2.Append("'"+model.UA_SignUP+"',");
			}
			if (model.UA_Email != null)
			{
				strSql1.Append("UA_Email,");
				strSql2.Append("'"+model.UA_Email+"',");
			}
			if (model.UA_Password != null)
			{
				strSql1.Append("UA_Password,");
				strSql2.Append("'"+model.UA_Password+"',");
			}
			if (model.UA_Note != null)
			{
				strSql1.Append("UA_Note,");
				strSql2.Append("'"+model.UA_Note+"',");
			}
			strSql.Append("insert into t_Administrators(");
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
		public bool Update(TTGB.Model.t_Administrators model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_Administrators set ");
			if (model.UA_Name != null)
			{
				strSql.Append("UA_Name='"+model.UA_Name+"',");
			}
			if (model.UA_RealName != null)
			{
				strSql.Append("UA_RealName='"+model.UA_RealName+"',");
			}
			else
			{
				strSql.Append("UA_RealName= null ,");
			}
			if (model.UA_Sex != null)
			{
				strSql.Append("UA_Sex="+ (model.UA_Sex? 1 : 0) +",");
			}
			else
			{
				strSql.Append("UA_Sex= null ,");
			}
			if (model.UA_Birthday != null)
			{
				strSql.Append("UA_Birthday='"+model.UA_Birthday+"',");
			}
			else
			{
				strSql.Append("UA_Birthday= null ,");
			}
			if (model.UA_Phone != null)
			{
				strSql.Append("UA_Phone='"+model.UA_Phone+"',");
			}
			else
			{
				strSql.Append("UA_Phone= null ,");
			}
			if (model.UA_SignUP != null)
			{
				strSql.Append("UA_SignUP='"+model.UA_SignUP+"',");
			}
			else
			{
				strSql.Append("UA_SignUP= null ,");
			}
			if (model.UA_Email != null)
			{
				strSql.Append("UA_Email='"+model.UA_Email+"',");
			}
			else
			{
				strSql.Append("UA_Email= null ,");
			}
			if (model.UA_Password != null)
			{
				strSql.Append("UA_Password='"+model.UA_Password+"',");
			}
			if (model.UA_Note != null)
			{
				strSql.Append("UA_Note='"+model.UA_Note+"',");
			}
			else
			{
				strSql.Append("UA_Note= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where UA_ID="+ model.UA_ID+"");
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
		public bool Delete(int UA_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_Administrators ");
			strSql.Append(" where UA_ID="+UA_ID+"" );
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
		public bool DeleteList(string UA_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_Administrators ");
			strSql.Append(" where UA_ID in ("+UA_IDlist + ")  ");
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
		public TTGB.Model.t_Administrators GetModel(int UA_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" UA_ID,UA_Name,UA_RealName,UA_Sex,UA_Birthday,UA_Phone,UA_SignUP,UA_Email,UA_Password,UA_Note ");
			strSql.Append(" from t_Administrators ");
			strSql.Append(" where UA_ID="+UA_ID+"" );
			TTGB.Model.t_Administrators model=new TTGB.Model.t_Administrators();
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
		public TTGB.Model.t_Administrators DataRowToModel(DataRow row)
		{
			TTGB.Model.t_Administrators model=new TTGB.Model.t_Administrators();
			if (row != null)
			{
				if(row["UA_ID"]!=null && row["UA_ID"].ToString()!="")
				{
					model.UA_ID=int.Parse(row["UA_ID"].ToString());
				}
				if(row["UA_Name"]!=null)
				{
					model.UA_Name=row["UA_Name"].ToString();
				}
				if(row["UA_RealName"]!=null)
				{
					model.UA_RealName=row["UA_RealName"].ToString();
				}
				if(row["UA_Sex"]!=null && row["UA_Sex"].ToString()!="")
				{
					if((row["UA_Sex"].ToString()=="1")||(row["UA_Sex"].ToString().ToLower()=="true"))
					{
						model.UA_Sex=true;
					}
					else
					{
						model.UA_Sex=false;
					}
				}
				if(row["UA_Birthday"]!=null && row["UA_Birthday"].ToString()!="")
				{
					model.UA_Birthday=DateTime.Parse(row["UA_Birthday"].ToString());
				}
				if(row["UA_Phone"]!=null)
				{
					model.UA_Phone=row["UA_Phone"].ToString();
				}
				if(row["UA_SignUP"]!=null && row["UA_SignUP"].ToString()!="")
				{
					model.UA_SignUP=DateTime.Parse(row["UA_SignUP"].ToString());
				}
				if(row["UA_Email"]!=null)
				{
					model.UA_Email=row["UA_Email"].ToString();
				}
				if(row["UA_Password"]!=null)
				{
					model.UA_Password=row["UA_Password"].ToString();
				}
				if(row["UA_Note"]!=null)
				{
					model.UA_Note=row["UA_Note"].ToString();
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
			strSql.Append("select UA_ID,UA_Name,UA_RealName,UA_Sex,UA_Birthday,UA_Phone,UA_SignUP,UA_Email,UA_Password,UA_Note ");
			strSql.Append(" FROM t_Administrators ");
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
			strSql.Append(" UA_ID,UA_Name,UA_RealName,UA_Sex,UA_Birthday,UA_Phone,UA_SignUP,UA_Email,UA_Password,UA_Note ");
			strSql.Append(" FROM t_Administrators ");
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
			strSql.Append("select count(1) FROM t_Administrators ");
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
				strSql.Append("order by T.UA_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_Administrators T ");
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

