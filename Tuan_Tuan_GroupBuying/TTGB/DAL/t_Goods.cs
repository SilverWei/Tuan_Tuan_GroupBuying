/**  版本信息模板在安装目录下，可自行修改。
* t_Goods.cs
*
* 功 能： N/A
* 类 名： t_Goods
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
	/// 数据访问类:t_Goods
	/// </summary>
	public partial class t_Goods
	{
		public t_Goods()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("G_ID", "t_Goods"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int G_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_Goods");
			strSql.Append(" where G_ID="+G_ID+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TTGB.Model.t_Goods model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.G_Name != null)
			{
				strSql1.Append("G_Name,");
				strSql2.Append("'"+model.G_Name+"',");
			}
			if (model.GS2_ID != null)
			{
				strSql1.Append("GS2_ID,");
				strSql2.Append(""+model.GS2_ID+",");
			}
			if (model.G_Brand != null)
			{
				strSql1.Append("G_Brand,");
				strSql2.Append("'"+model.G_Brand+"',");
			}
			if (model.G_MarketPrice != null)
			{
				strSql1.Append("G_MarketPrice,");
				strSql2.Append(""+model.G_MarketPrice+",");
			}
			if (model.G_UserPrice != null)
			{
				strSql1.Append("G_UserPrice,");
				strSql2.Append(""+model.G_UserPrice+",");
			}
			if (model.G_BuyPoints != null)
			{
				strSql1.Append("G_BuyPoints,");
				strSql2.Append(""+model.G_BuyPoints+",");
			}
			if (model.G_OfferDate != null)
			{
				strSql1.Append("G_OfferDate,");
				strSql2.Append("'"+model.G_OfferDate+"',");
			}
			if (model.G_Amount != null)
			{
				strSql1.Append("G_Amount,");
				strSql2.Append(""+model.G_Amount+",");
			}
			if (model.G_PictureUrl != null)
			{
				strSql1.Append("G_PictureUrl,");
				strSql2.Append("'"+model.G_PictureUrl+"',");
			}
			if (model.G_Text != null)
			{
				strSql1.Append("G_Text,");
				strSql2.Append("'"+model.G_Text+"',");
			}
			if (model.G_Note != null)
			{
				strSql1.Append("G_Note,");
				strSql2.Append("'"+model.G_Note+"',");
			}
			strSql.Append("insert into t_Goods(");
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
		public bool Update(TTGB.Model.t_Goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_Goods set ");
			if (model.G_Name != null)
			{
				strSql.Append("G_Name='"+model.G_Name+"',");
			}
			else
			{
				strSql.Append("G_Name= null ,");
			}
			if (model.GS2_ID != null)
			{
				strSql.Append("GS2_ID="+model.GS2_ID+",");
			}
			else
			{
				strSql.Append("GS2_ID= null ,");
			}
			if (model.G_Brand != null)
			{
				strSql.Append("G_Brand='"+model.G_Brand+"',");
			}
			else
			{
				strSql.Append("G_Brand= null ,");
			}
			if (model.G_MarketPrice != null)
			{
				strSql.Append("G_MarketPrice="+model.G_MarketPrice+",");
			}
			else
			{
				strSql.Append("G_MarketPrice= null ,");
			}
			if (model.G_UserPrice != null)
			{
				strSql.Append("G_UserPrice="+model.G_UserPrice+",");
			}
			else
			{
				strSql.Append("G_UserPrice= null ,");
			}
			if (model.G_BuyPoints != null)
			{
				strSql.Append("G_BuyPoints="+model.G_BuyPoints+",");
			}
			else
			{
				strSql.Append("G_BuyPoints= null ,");
			}
			if (model.G_OfferDate != null)
			{
				strSql.Append("G_OfferDate='"+model.G_OfferDate+"',");
			}
			else
			{
				strSql.Append("G_OfferDate= null ,");
			}
			if (model.G_Amount != null)
			{
				strSql.Append("G_Amount="+model.G_Amount+",");
			}
			else
			{
				strSql.Append("G_Amount= null ,");
			}
			if (model.G_PictureUrl != null)
			{
				strSql.Append("G_PictureUrl='"+model.G_PictureUrl+"',");
			}
			else
			{
				strSql.Append("G_PictureUrl= null ,");
			}
			if (model.G_Text != null)
			{
				strSql.Append("G_Text='"+model.G_Text+"',");
			}
			else
			{
				strSql.Append("G_Text= null ,");
			}
			if (model.G_Note != null)
			{
				strSql.Append("G_Note='"+model.G_Note+"',");
			}
			else
			{
				strSql.Append("G_Note= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where G_ID="+ model.G_ID+"");
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
		public bool Delete(int G_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_Goods ");
			strSql.Append(" where G_ID="+G_ID+"" );
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
		public bool DeleteList(string G_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_Goods ");
			strSql.Append(" where G_ID in ("+G_IDlist + ")  ");
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
		public TTGB.Model.t_Goods GetModel(int G_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" G_ID,G_Name,GS2_ID,G_Brand,G_MarketPrice,G_UserPrice,G_BuyPoints,G_OfferDate,G_Amount,G_PictureUrl,G_Text,G_Note ");
			strSql.Append(" from t_Goods ");
			strSql.Append(" where G_ID="+G_ID+"" );
			TTGB.Model.t_Goods model=new TTGB.Model.t_Goods();
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
		public TTGB.Model.t_Goods DataRowToModel(DataRow row)
		{
			TTGB.Model.t_Goods model=new TTGB.Model.t_Goods();
			if (row != null)
			{
				if(row["G_ID"]!=null && row["G_ID"].ToString()!="")
				{
					model.G_ID=int.Parse(row["G_ID"].ToString());
				}
				if(row["G_Name"]!=null)
				{
					model.G_Name=row["G_Name"].ToString();
				}
				if(row["GS2_ID"]!=null && row["GS2_ID"].ToString()!="")
				{
					model.GS2_ID=int.Parse(row["GS2_ID"].ToString());
				}
				if(row["G_Brand"]!=null)
				{
					model.G_Brand=row["G_Brand"].ToString();
				}
				if(row["G_MarketPrice"]!=null && row["G_MarketPrice"].ToString()!="")
				{
					model.G_MarketPrice=int.Parse(row["G_MarketPrice"].ToString());
				}
				if(row["G_UserPrice"]!=null && row["G_UserPrice"].ToString()!="")
				{
					model.G_UserPrice=int.Parse(row["G_UserPrice"].ToString());
				}
				if(row["G_BuyPoints"]!=null && row["G_BuyPoints"].ToString()!="")
				{
					model.G_BuyPoints=int.Parse(row["G_BuyPoints"].ToString());
				}
				if(row["G_OfferDate"]!=null && row["G_OfferDate"].ToString()!="")
				{
					model.G_OfferDate=DateTime.Parse(row["G_OfferDate"].ToString());
				}
				if(row["G_Amount"]!=null && row["G_Amount"].ToString()!="")
				{
					model.G_Amount=int.Parse(row["G_Amount"].ToString());
				}
				if(row["G_PictureUrl"]!=null)
				{
					model.G_PictureUrl=row["G_PictureUrl"].ToString();
				}
				if(row["G_Text"]!=null)
				{
					model.G_Text=row["G_Text"].ToString();
				}
				if(row["G_Note"]!=null)
				{
					model.G_Note=row["G_Note"].ToString();
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
			strSql.Append("select G_ID,G_Name,GS2_ID,G_Brand,G_MarketPrice,G_UserPrice,G_BuyPoints,G_OfferDate,G_Amount,G_PictureUrl,G_Text,G_Note ");
			strSql.Append(" FROM t_Goods ");
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
			strSql.Append(" G_ID,G_Name,GS2_ID,G_Brand,G_MarketPrice,G_UserPrice,G_BuyPoints,G_OfferDate,G_Amount,G_PictureUrl,G_Text,G_Note ");
			strSql.Append(" FROM t_Goods ");
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
			strSql.Append("select count(1) FROM t_Goods ");
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
				strSql.Append("order by T.G_ID desc");
			}
			strSql.Append(")AS Row, T.*  from t_Goods T ");
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

