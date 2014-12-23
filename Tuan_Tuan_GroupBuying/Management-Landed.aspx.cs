using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Management_Landed : System.Web.UI.Page
{
    TTGB.BLL.t_Administrators bllUsers = new TTGB.BLL.t_Administrators();
    TTGB.Model.t_Administrators ModUsers = new TTGB.Model.t_Administrators();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (UA_Name_Text.Value.ToString() == "" && UA_Password_Text.Value.ToString() == "")
        {
            WrongShow.Visible = true;
            WrongText.InnerText = "请输入用户名和密码";
        }
        else
        {
            string userid = UA_Name_Text.Value.ToString();
            string password = UA_Password_Text.Value.ToString();
            DataTable Login1 = bllUsers.GetList(" UA_Name='" + SqlInsertEncode(userid) + "'and UA_Password='" + SqlInsertEncode(password) + "' ").Tables[0];
            if (Login1.Rows.Count>0)
            {
                Response.Cookies["AdminName"].Value = HttpUtility.UrlEncode(Login1.Rows[0]["UA_Name"].ToString());
                //Response.Cookies["AdminName"].Value = Login1.Rows[0]["UA_Name"].ToString();//存储Cookies值,为管理员用户名
                Response.Cookies["AdminName"].Expires = DateTime.Now.AddDays(1); //确定Cookies保存时间
                Response.Cookies["AdminId"].Value = Login1.Rows[0]["UA_ID"].ToString();//读取Login1的第一行U_ID字段数据，为管理员ID
                Response.Cookies["AdminId"].Expires = DateTime.Now.AddDays(1);
                Response.Redirect("Management-Goods.aspx");
            }
            else
            {
                WrongShow.Visible = true;
                WrongText.InnerText = "输入有误";
            }
        }
    }

    /// <summary>
    /// SQL过滤
    /// </summary>
    /// <param name="strFromText"></param>
    /// <returns></returns>
    public static string SqlInsertEncode(string strFromText)
    {
        if (!System.String.IsNullOrEmpty(strFromText) && strFromText != "")
        {
            strFromText = strFromText.Replace(";", "&#59;");
            strFromText = strFromText.Replace("!", "&#33;");
            strFromText = strFromText.Replace("@", "&#64;");
            strFromText = strFromText.Replace("$", "&#36;");
            strFromText = strFromText.Replace("*", "&#42;");
            strFromText = strFromText.Replace("(", "&#40;");
            strFromText = strFromText.Replace(")", "&#41;");
            strFromText = strFromText.Replace("-", "&#45;");
            strFromText = strFromText.Replace("+", "&#43;");
            strFromText = strFromText.Replace("=", "&#61;");
            strFromText = strFromText.Replace("|", "&#124;");
            strFromText = strFromText.Replace("\\", "&#92;");
            strFromText = strFromText.Replace("/", "&#47;");
            strFromText = strFromText.Replace(":", "&#58;");
            strFromText = strFromText.Replace("\"", "&#34;");
            strFromText = strFromText.Replace("'", "&#39;");
            strFromText = strFromText.Replace("<", "&#60;");
            strFromText = strFromText.Replace(" ", "&#32;");
            strFromText = strFromText.Replace(">", "&#62;");
            strFromText = strFromText.Replace(" ", "&#32;");
        }
        return strFromText;
    }

}