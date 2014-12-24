/**  版本信息模板在安装目录下，可自行修改。
* t_GroupBuying.cs
*
* 功 能： N/A
* 类 名： t_GroupBuying
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/24 16:15:49   N/A    初版
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
	/// 数据访问类:t_GroupBuying
	/// </summary>
	public partial class t_GroupBuying
	{
		public t_GroupBuying()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("GB_ID", "t_GroupBuying"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int GB_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_GroupBuying");
			strSql.Append(" where GB_ID="+GB_ID+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TTGB.Model.t_GroupBuying model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.GB_Name != null)
			{
				strSql1.Append("GB_Name,");
				strSql2.Append("'"+model.GB_Name+"',");
			}
			if (model.GS2_ID != null)
			{
				strSql1.Append("GS2_ID,");
				strSql2.Append(""+model.GS2_ID+",");
			}
			if (model.GB_Brand != null)
			{
				strSql1.Append("GB_Brand,");
				strSql2.Append("'"+model.GB_Brand+"',");
			}
			if (model.GB_MarketPrice != null)
			{
				strSql1.Append("GB_MarketPrice,");
				strSql2.Append(""+model.GB_MarketPrice+",");
			}
			if (model.GB_GroupPrice != null)
			{
				strSql1.Append("GB_GroupPrice,");
				strSql2.Append(""+model.GB_GroupPrice+",");
			}
			if (model.GB_OfferDate != null)
			{
				strSql1.Append("GB_OfferDate,");
				strSql2.Append("'"+model.GB_OfferDate+"',");
			}
			if (model.GB_EndDate != null)
			{
				strSql1.Append("GB_EndDate,");
				strSql2.Append("'"+model.GB_EndDate+"',");
			}
			if (model.GB_TotalNumber != null)
			{
				strSql1.Append("GB_TotalNumber,");
				strSql2.Append(""+model.GB_TotalNumber+",");
			}
			if (model.GB_participantsNumber != null)
			{
				strSql1.Append("GB_participantsNumber,");
				strSql2.Append(""+model.GB_participantsNumber+",");
			}
			if (model.GB_State != null)
			{
				strSql1.Append("GB_State,");
				strSql2.Append(""+(model.GB_State? 1 : 0) +",");
			}
			if (model.GB_PictureUrl != null)
			{
				strSql1.Append("GB_PictureUrl,");
				strSql2.Append("'"+model.GB_PictureUrl+"',");
			}
			if (model.GB_Text != null)
			{
				strSql1.Append("GB_Text,");
				strSql2.Append("'"+model.GB_Text+"',");
			}
			if (model.GB_Note != null)
			{
				strSql1.Append("GB_Note,");
				strSql2.Append("'"+model.GB_Note+"',");
			}
			strSql.Append("insert into t_GroupBuying(");
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
		public bool Update(TTGB.Model.t_GroupBuying model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_GroupBuying set ");
			if (model.GB_Name != null)
			{
				strSql.Append("GB_Name='"+model.GB_Name+"',");
			}
			if (model.GS2_ID != null)
			{
				strSql.Append("GS2_ID="+model.GS2_ID+",");
			}
			if (model.GB_Brand != null)
			{
				strSql.Append("GB_Brand='"+model.GB_Brand+"',");
			}
			if (model.GB_MarketPrice != null)
			{
				strSql.Append("GB_MarketPrice="+model.GB_MarketPrice+",");
			}
			if (model.GB_GroupPrice != null)
			{
				strSql.Append("GB_GroupPrice="+model.GB_GroupPrice+",");
			}
			if (model.GB_OfferDate != null)
			{
				strSql.Append("GB_OfferDate='"+model.GB_OfferDate+"',");
			}
			if (model.GB_EndDate != null)
			{
				strSql.Append("GB_EndDate='"+model.GB_EndDate+"',");
			}
			else
			{
				strSql.Append("GB_EndDate= null ,");
			}
			if (model.GB_TotalNumber != null)
			{
				strSql.Append("GB_TotalNumber="+model.GB_TotalNumber+",");
			}
			if (model.GB_participantsNumber != null)
			{
				strSql.Append("GB_participantsNumber="+model.GB_participantsNumber+",");
			}
			if (model.GB_State != null)
			{
				strSql.Append("GB_State="+ (model.GB_State? 1 : 0) +",");
			}
			if (model.GB_PictureUrl != null)
			{
				strSql.Append("GB_PictureUrl='"+model.GB_PictureUrl+"',");
			}
			else
			{
				strSql.Append("GB_PictureUrl= null ,");
			}
			if (model.GB_Text != null)
			{
				strSql.Append("GB_Text='"+model.GB_Text+"',");
			}
			if (model.GB_Note != null)
			{
				strSql.Append("GB_Note='"+model.GB_Note+"',");
			}
			else
			{
				strSql.Append("GB_Note= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where GB_ID="+ model.GB_ID+"");
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
		public bool Delete(int GB_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_GroupBuying ");
			strSql.Append(" where GB_ID="+GB_ID+"" );
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
		public bool DeleteList(string GB_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_GroupBuying ");
			strSql.Append(" where GB_ID in ("+GB_IDlist + ")  ");
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
		public TTGB.Model.t_GroupBuying GetModel(int GB_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" GB_ID,GB_Name,GS2_ID,GB_Brand,GB_MarketPrice,GB_GroupPrice,GB_OfferDate,GB_EndDate,GB_TotalNumber,GB_participantsNumber,GB_State,GB_PictureUrl,GB_Text,GB_Note ");
			strSql.Append(" from t_GroupBuying ");
			strSql.Append(" where GB_ID="+GB_ID+"" );
			TTGB.Model.t_GroupBuying model=new TTGB.Model.t_GroupBuying();
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
		public TTGB.Model.t_GroupBuying DataRowToModel(DataRow row)
		{
			TTGB.Model.t_GroupBuying model=new TTGB.Model.t_GroupBuying();
			if (row != null)
			{
				if(row["GB_ID"]!=null && row["GB_ID"].ToString()!="")
				{
					model.GB_ID=int.Parse(row["GB_ID"].ToString());
				}
				if(row["GB_Name"]!=null)
				{
					model.GB_Name=row["GB_Name"].ToString();
				}
				if(row["GS2_ID"]!=null && row["GS2_ID"].ToString()!="")
				{
					model.GS2_ID=int.Parse(row["GS2_ID"].ToString());
				}
				if(row["GB_Brand"]!=null)
				{
					model.GB_Brand=row["GB_Brand"].ToString();
				}
				if(row["GB_MarketPrice"]!=null && row["GB_MarketPrice"].ToString()!="")
				{
					model.GB_MarketPrice=decimal.Parse(row["GB_MarketPrice"].ToString());
				}
				if(row["GB_GroupPrice"]!=null && row["GB_GroupPrice"].ToString()!="")
				{
					model.GB_GroupPrice=decimal.Parse(row["GB_GroupPrice"].ToString());
				}
				if(row["GB_OfferDate"]!=null && row["GB_OfferDate"].ToString()!="")
				{
					model.GB_OfferDate=DateTime.Parse(row["GB_OfferDate"].ToString());
				}
				if(row["GB_EndDate"]!=null && row["GB_EndDate"].ToString()!="")
				{
					model.GB_EndDate=DateTime.Parse(row["GB_EndDate"].ToString());
				}
				if(row["GB_TotalNumber"]!=null && row["GB_TotalNumber"].ToString()!="")
				{
					model.GB_TotalNumber=int.Parse(row["GB_TotalNumber"].ToString());
				}
				if(row["GB_participantsNumber"]!=null && row["GB_participantsNumber"].ToString()!="")
				{
					model.GB_participantsNumber=int.Parse(row["GB_participantsNumber"].ToString());
				}
				if(row["GB_State"]!=null && row["GB_State"].ToString()!="")
				{
					if((row["GB_State"].ToString()=="1")||(row["GB_State"].ToString().ToLower()=="true"))
					{
						model.GB_State=true;
					}
					else
					{
						model.GB_State=false;
					}
				}
				if(row["GB_PictureUrl"]!=null)
				{
					model.GB_PictureUrl=row["GB_PictureUrl"].ToString();
				}
				if(row["GB_Text"]!=null)
				{
					model.GB_Text=row["GB_Text"].ToString();
				}
				if(row["GB_Note"]!=null)
				{
					model.GB_Note=row["GB_Note"].ToString();
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
			strSql.Append("select GB_ID,GB_Name,GS2_ID,GB_Brand,GB_MarketPrice,GB_GroupPrice,GB_OfferDate,GB_EndDate,GB_TotalNumber,GB_participantsNumber,GB_State,GB_PictureUrl,GB_Text,GB_Note ");
			strSql.Append(" FROM t_GroupBuying ");
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
			strSql.Append(" GB_ID,GB_Name,GS2_ID,GB_Brand,GB_MarketPrice,GB_GroupPrice,GB_OfferDate,GB_EndDate,GB_TotalNumber,GB_participantsNumber,GB_State,GB_PictureUrl,GB_Text,GB_Note ");
			strSql.Append(" FROM t_GroupBuying ");
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
			strSql.Append("select count(1) FROM t_GroupBuying ");
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
				strSql.Append("order by T.GB_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_GroupBuying T ");
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

