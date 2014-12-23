using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Landed : System.Web.UI.Page
{
    TTGB.BLL.t_Users bllUsers = new TTGB.BLL.t_Users();
    TTGB.Model.t_Users ModUsers = new TTGB.Model.t_Users();
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断用户是否已登陆，如果登陆跳转首页
        if (Request.Cookies["UserId"] != null && LoginStatus())
        {
            Response.Redirect("Home.aspx");
        }

    }

    /// <summary>
    /// 检测用户状态
    /// </summary>
    public bool LoginStatus()
    {
        DataTable Login1 = bllUsers.GetList("[U_ID]='" + Request.Cookies["UserId"].Value + "'").Tables[0];
        if (Login1.Rows.Count > 0)//是否有数据，有数据则成功否则为游客
            return true;
        else
            return false;
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

    /// <summary>
    /// 验证登录
    /// </summary>
    protected void Login_Button_Click(object sender, EventArgs e)
    {

        if (UserName_Text.Value.ToString() != "" && Password_Text.Value.ToString() != "")
        {
            string UserName = UserName_Text.Value.ToString();
            string passwprdid = Password_Text.Value.ToString();
            DataTable Login1 = bllUsers.GetList("U_Name='" + SqlInsertEncode(UserName) + "' and U_Password='" + SqlInsertEncode(passwprdid) + "'").Tables[0];
            if (Login1.Rows.Count > 0)//是否有数据，有数据则成功否则登陆失败提示用户名或密码错误
            {
                Response.Cookies["UserName"].Value = HttpUtility.UrlEncode(Login1.Rows[0]["U_Name"].ToString());//存储Cookies值
                //中文存Cookies
                //cookie.Value = HttpUtility.UrlEncode("上海");
                //取cookie时候,进行解码:
                //cookieValue = HttpUtility.UrlDecode(cookie.Value);
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(1); //确定Cookies保存时间
                Response.Cookies["UserId"].Value = Login1.Rows[0]["U_ID"].ToString();//读取Login1的第一行U_ID字段数据
                Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(1);


                //Response为存入，Request为读取
                Response.Redirect("Home.aspx?Landed=0");//跳转页面

                //WrongShow.Visible = true;
                //WrongText.InnerText = Request.Cookies["UserName"].Value;
            }
            else//
            {
                WrongShow.Visible = true;
                WrongText.InnerText = "用户名或密码有误！";
            }
        }
        else
        {
            WrongShow.Visible = true;
            WrongText.InnerText = "请输入用户名和密码！";
        }
    }

    /// <summary>
    /// 过滤SQL语句,防止注入
    /// </summary>
    /// <param name="strSql"></param>
    /// <returns>0 - 没有注入, 1 - 有注入 </returns>
    public int filterSql(string sSql)
    {
        int srcLen, decLen = 0;
        sSql = sSql.ToLower().Trim();
        srcLen = sSql.Length;
        sSql = sSql.Replace("exec", "");
        sSql = sSql.Replace("delete", "");
        sSql = sSql.Replace("master", "");
        sSql = sSql.Replace("truncate", "");
        sSql = sSql.Replace("declare", "");
        sSql = sSql.Replace("create", "");
        sSql = sSql.Replace("xp_", "no");
        decLen = sSql.Length;
        if (srcLen == decLen) return 0; else return 1;
    }
}