using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;//Please add references


public partial class Home : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["LogOff"] != null)
        {
            Response.Write("<script>alert(\"注销成功!\");window.location.href=\"Home.aspx\"</script>");
        }
        if (Request.QueryString["Landed"] != null)
        {
            Response.Write("<script>alert(\"登录成功!\");window.location.href=\"Home.aspx\"</script>");
        }
        if (Request.QueryString["register"] != null)
        {
            Response.Write("<script>alert(\"注册成功!\");window.location.href=\"Landed.aspx\"</script>");
        }
        ShoppingCart_Show();
    }

    public void ShoppingCart_Show()
    {
        int ShoppingCart_Number = 0;

        if (Request.Cookies["ShoppingCart"] != null)
        {
            HttpCookie ShoppingCart_cookie = Request.Cookies["ShoppingCart"];
            for (int i = 0; i < ShoppingCart_cookie.Values.Count; i++)
            {
                //cookies第一条
                //ShoppingCart_cookie.Values.AllKeys[i];

                ////cookies第二条
                //string[] shops = ShoppingCart_cookie.Values[i].Split(',');
                //shops[1]；

                ShoppingCart_Number += 1;
            }
        }
        if (Request.Cookies["ShoppingCartB"] != null)
        {
            HttpCookie ShoppingCart_cookie = Request.Cookies["ShoppingCartB"];
            for (int i = 0; i < ShoppingCart_cookie.Values.Count; i++)
            {
                //cookies第一条
                //ShoppingCart_cookie.Values.AllKeys[i];

                ////cookies第二条
                //string[] shops = ShoppingCart_cookie.Values[i].Split(',');
                //shops[1]；

                ShoppingCart_Number += 1;
            }
        }
        ShoppingCart_Text.InnerText = ShoppingCart_Number.ToString();
    }


}