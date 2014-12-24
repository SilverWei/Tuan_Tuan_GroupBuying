/**  版本信息模板在安装目录下，可自行修改。
* t_Orders.cs
*
* 功 能： N/A
* 类 名： t_Orders
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
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TTGB.DAL
{
	/// <summary>
	/// 数据访问类:t_Orders
	/// </summary>
	public partial class t_Orders
	{
		public t_Orders()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("O_ID", "t_Orders"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int O_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_Orders");
			strSql.Append(" where O_ID="+O_ID+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TTGB.Model.t_Orders model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.U_ID != null)
			{
				strSql1.Append("U_ID,");
				strSql2.Append(""+model.U_ID+",");
			}
			if (model.O_buyDate != null)
			{
				strSql1.Append("O_buyDate,");
				strSql2.Append("'"+model.O_buyDate+"',");
			}
			if (model.O_Cnsignee != null)
			{
				strSql1.Append("O_Cnsignee,");
				strSql2.Append("'"+model.O_Cnsignee+"',");
			}
			if (model.O_ZipCode != null)
			{
				strSql1.Append("O_ZipCode,");
				strSql2.Append("'"+model.O_ZipCode+"',");
			}
			if (model.O_Address != null)
			{
				strSql1.Append("O_Address,");
				strSql2.Append("'"+model.O_Address+"',");
			}
			if (model.O_Phone != null)
			{
				strSql1.Append("O_Phone,");
				strSql2.Append("'"+model.O_Phone+"',");
			}
			if (model.OSM_ID != null)
			{
				strSql1.Append("OSM_ID,");
				strSql2.Append(""+model.OSM_ID+",");
			}
			if (model.OS_ID != null)
			{
				strSql1.Append("OS_ID,");
				strSql2.Append(""+model.OS_ID+",");
			}
			if (model.O_GB_Y_N != null)
			{
				strSql1.Append("O_GB_Y_N,");
				strSql2.Append(""+(model.O_GB_Y_N? 1 : 0) +",");
			}
			if (model.O_Message != null)
			{
				strSql1.Append("O_Message,");
				strSql2.Append("'"+model.O_Message+"',");
			}
			strSql.Append("insert into t_Orders(");
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
		public bool Update(TTGB.Model.t_Orders model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_Orders set ");
			if (model.U_ID != null)
			{
				strSql.Append("U_ID="+model.U_ID+",");
			}
			if (model.O_buyDate != null)
			{
				strSql.Append("O_buyDate='"+model.O_buyDate+"',");
			}
			if (model.O_Cnsignee != null)
			{
				strSql.Append("O_Cnsignee='"+model.O_Cnsignee+"',");
			}
			if (model.O_ZipCode != null)
			{
				strSql.Append("O_ZipCode='"+model.O_ZipCode+"',");
			}
			if (model.O_Address != null)
			{
				strSql.Append("O_Address='"+model.O_Address+"',");
			}
			if (model.O_Phone != null)
			{
				strSql.Append("O_Phone='"+model.O_Phone+"',");
			}
			if (model.OSM_ID != null)
			{
				strSql.Append("OSM_ID="+model.OSM_ID+",");
			}
			if (model.OS_ID != null)
			{
				strSql.Append("OS_ID="+model.OS_ID+",");
			}
			if (model.O_GB_Y_N != null)
			{
				strSql.Append("O_GB_Y_N="+ (model.O_GB_Y_N? 1 : 0) +",");
			}
			if (model.O_Message != null)
			{
				strSql.Append("O_Message='"+model.O_Message+"',");
			}
			else
			{
				strSql.Append("O_Message= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where O_ID="+ model.O_ID+"");
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
		public bool Delete(int O_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_Orders ");
			strSql.Append(" where O_ID="+O_ID+"" );
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
		public bool DeleteList(string O_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_Orders ");
			strSql.Append(" where O_ID in ("+O_IDlist + ")  ");
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
		public TTGB.Model.t_Orders GetModel(int O_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" O_ID,U_ID,O_buyDate,O_Cnsignee,O_ZipCode,O_Address,O_Phone,OSM_ID,OS_ID,O_GB_Y_N,O_Message ");
			strSql.Append(" from t_Orders ");
			strSql.Append(" where O_ID="+O_ID+"" );
			TTGB.Model.t_Orders model=new TTGB.Model.t_Orders();
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
		public TTGB.Model.t_Orders DataRowToModel(DataRow row)
		{
			TTGB.Model.t_Orders model=new TTGB.Model.t_Orders();
			if (row != null)
			{
				if(row["O_ID"]!=null && row["O_ID"].ToString()!="")
				{
					model.O_ID=int.Parse(row["O_ID"].ToString());
				}
				if(row["U_ID"]!=null && row["U_ID"].ToString()!="")
				{
					model.U_ID=int.Parse(row["U_ID"].ToString());
				}
				if(row["O_buyDate"]!=null && row["O_buyDate"].ToString()!="")
				{
					model.O_buyDate=DateTime.Parse(row["O_buyDate"].ToString());
				}
				if(row["O_Cnsignee"]!=null)
				{
					model.O_Cnsignee=row["O_Cnsignee"].ToString();
				}
				if(row["O_ZipCode"]!=null)
				{
					model.O_ZipCode=row["O_ZipCode"].ToString();
				}
				if(row["O_Address"]!=null)
				{
					model.O_Address=row["O_Address"].ToString();
				}
				if(row["O_Phone"]!=null)
				{
					model.O_Phone=row["O_Phone"].ToString();
				}
				if(row["OSM_ID"]!=null && row["OSM_ID"].ToString()!="")
				{
					model.OSM_ID=int.Parse(row["OSM_ID"].ToString());
				}
				if(row["OS_ID"]!=null && row["OS_ID"].ToString()!="")
				{
					model.OS_ID=int.Parse(row["OS_ID"].ToString());
				}
				if(row["O_GB_Y_N"]!=null && row["O_GB_Y_N"].ToString()!="")
				{
					if((row["O_GB_Y_N"].ToString()=="1")||(row["O_GB_Y_N"].ToString().ToLower()=="true"))
					{
						model.O_GB_Y_N=true;
					}
					else
					{
						model.O_GB_Y_N=false;
					}
				}
				if(row["O_Message"]!=null)
				{
					model.O_Message=row["O_Message"].ToString();
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
			strSql.Append("select O_ID,U_ID,O_buyDate,O_Cnsignee,O_ZipCode,O_Address,O_Phone,OSM_ID,OS_ID,O_GB_Y_N,O_Message ");
			strSql.Append(" FROM t_Orders ");
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
			strSql.Append(" O_ID,U_ID,O_buyDate,O_Cnsignee,O_ZipCode,O_Address,O_Phone,OSM_ID,OS_ID,O_GB_Y_N,O_Message ");
			strSql.Append(" FROM t_Orders ");
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
			strSql.Append("select count(1) FROM t_Orders ");
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
				strSql.Append("order by T.O_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_Orders T ");
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

