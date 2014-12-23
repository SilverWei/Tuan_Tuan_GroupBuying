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
			if (model.UA _Name != null)
			{
				strSql1.Append("UA _Name,");
				strSql2.Append("'"+model.UA _Name+"',");
			}
			if (model.UA _RealName != null)
			{
				strSql1.Append("UA _RealName,");
				strSql2.Append("'"+model.UA _RealName+"',");
			}
			if (model.UA _Sex != null)
			{
				strSql1.Append("UA _Sex,");
				strSql2.Append(""+(model.UA _Sex? 1 : 0) +",");
			}
			if (model.UA _Birthday != null)
			{
				strSql1.Append("UA _Birthday,");
				strSql2.Append("'"+model.UA _Birthday+"',");
			}
			if (model.UA _Phone != null)
			{
				strSql1.Append("UA _Phone,");
				strSql2.Append("'"+model.UA _Phone+"',");
			}
			if (model.UA _SignUP != null)
			{
				strSql1.Append("UA _SignUP,");
				strSql2.Append("'"+model.UA _SignUP+"',");
			}
			if (model.UA _Email != null)
			{
				strSql1.Append("UA _Email,");
				strSql2.Append("'"+model.UA _Email+"',");
			}
			if (model.UA _Password != null)
			{
				strSql1.Append("UA _Password,");
				strSql2.Append("'"+model.UA _Password+"',");
			}
			if (model.UA _Note != null)
			{
				strSql1.Append("UA _Note,");
				strSql2.Append("'"+model.UA _Note+"',");
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
			if (model.UA _Name != null)
			{
				strSql.Append("UA _Name='"+model.UA _Name+"',");
			}
			else
			{
				strSql.Append("UA _Name= null ,");
			}
			if (model.UA _RealName != null)
			{
				strSql.Append("UA _RealName='"+model.UA _RealName+"',");
			}
			else
			{
				strSql.Append("UA _RealName= null ,");
			}
			if (model.UA _Sex != null)
			{
				strSql.Append("UA _Sex="+ (model.UA _Sex? 1 : 0) +",");
			}
			else
			{
				strSql.Append("UA _Sex= null ,");
			}
			if (model.UA _Birthday != null)
			{
				strSql.Append("UA _Birthday='"+model.UA _Birthday+"',");
			}
			else
			{
				strSql.Append("UA _Birthday= null ,");
			}
			if (model.UA _Phone != null)
			{
				strSql.Append("UA _Phone='"+model.UA _Phone+"',");
			}
			else
			{
				strSql.Append("UA _Phone= null ,");
			}
			if (model.UA _SignUP != null)
			{
				strSql.Append("UA _SignUP='"+model.UA _SignUP+"',");
			}
			else
			{
				strSql.Append("UA _SignUP= null ,");
			}
			if (model.UA _Email != null)
			{
				strSql.Append("UA _Email='"+model.UA _Email+"',");
			}
			else
			{
				strSql.Append("UA _Email= null ,");
			}
			if (model.UA _Password != null)
			{
				strSql.Append("UA _Password='"+model.UA _Password+"',");
			}
			else
			{
				strSql.Append("UA _Password= null ,");
			}
			if (model.UA _Note != null)
			{
				strSql.Append("UA _Note='"+model.UA _Note+"',");
			}
			else
			{
				strSql.Append("UA _Note= null ,");
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
			strSql.Append(" UA_ID,UA _Name,UA _RealName,UA _Sex,UA _Birthday,UA _Phone,UA _SignUP,UA _Email,UA _Password,UA _Note ");
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
				if(row["UA _Name"]!=null)
				{
					model.UA _Name=row["UA _Name"].ToString();
				}
				if(row["UA _RealName"]!=null)
				{
					model.UA _RealName=row["UA _RealName"].ToString();
				}
				if(row["UA _Sex"]!=null && row["UA _Sex"].ToString()!="")
				{
					if((row["UA _Sex"].ToString()=="1")||(row["UA _Sex"].ToString().ToLower()=="true"))
					{
						model.UA _Sex=true;
					}
					else
					{
						model.UA _Sex=false;
					}
				}
				if(row["UA _Birthday"]!=null && row["UA _Birthday"].ToString()!="")
				{
					model.UA _Birthday=DateTime.Parse(row["UA _Birthday"].ToString());
				}
				if(row["UA _Phone"]!=null)
				{
					model.UA _Phone=row["UA _Phone"].ToString();
				}
				if(row["UA _SignUP"]!=null && row["UA _SignUP"].ToString()!="")
				{
					model.UA _SignUP=DateTime.Parse(row["UA _SignUP"].ToString());
				}
				if(row["UA _Email"]!=null)
				{
					model.UA _Email=row["UA _Email"].ToString();
				}
				if(row["UA _Password"]!=null)
				{
					model.UA _Password=row["UA _Password"].ToString();
				}
				if(row["UA _Note"]!=null)
				{
					model.UA _Note=row["UA _Note"].ToString();
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
			strSql.Append("select UA_ID,UA _Name,UA _RealName,UA _Sex,UA _Birthday,UA _Phone,UA _SignUP,UA _Email,UA _Password,UA _Note ");
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
			strSql.Append(" UA_ID,UA _Name,UA _RealName,UA _Sex,UA _Birthday,UA _Phone,UA _SignUP,UA _Email,UA _Password,UA _Note ");
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

