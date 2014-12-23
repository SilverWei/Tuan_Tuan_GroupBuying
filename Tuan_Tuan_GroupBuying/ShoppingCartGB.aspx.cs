using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Maticsoft.DBUtility;//Please add references


public partial class ShoppingCartGB : System.Web.UI.Page
{
    TTGB.BLL.t_Goods bllt_Goods = new TTGB.BLL.t_Goods();
    TTGB.BLL.t_Orders bllt_Orders = new TTGB.BLL.t_Orders();
    protected void Page_Load(object sender, EventArgs e)
    {
        GB_Show();
        ShoppingCart_Number();
    }


    /// <summary>
    /// 单个物品删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DelButton1_Click(object sender, EventArgs e)
    {
        HttpCookie ShoppingCart_cookie = Request.Cookies["ShoppingCartB"];
        ShoppingCart_cookie.Values.Set(Request.Cookies["SC_ID2"].Value.ToString() + Request.Cookies["SC_ID1"].Value.ToString(), Request.Cookies["SC_ID1"].Value.ToString() + "," + Request.Cookies["SC_ID2"].Value.ToString() + "," + NumberEdit.Value.ToString());
        ShoppingCart_cookie.Expires = DateTime.Now.AddDays(1);
        Response.Cookies.Add(ShoppingCart_cookie);
        Response.Redirect(Request.Url.ToString());
    }
    /// <summary>
    /// 删除所有的活动物品
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["ShoppingCartB"] != null)
        {
            HttpCookie ShoppingCart_cookie = Request.Cookies["ShoppingCartB"];
            ShoppingCart_cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(ShoppingCart_cookie);
        }
        Response.Redirect(Request.Url.ToString());
    }


    /// <summary>
    /// 活动显示
    /// </summary>
    public void GB_Show()
    {
        if (Request.Cookies["ShoppingCartB"] != null)
        {
            HttpCookie ShoppingCart_cookie = Request.Cookies["ShoppingCartB"];
            StringBuilder sp = new StringBuilder();
            float TotalPrice=0;
            for (int i = 0; i < ShoppingCart_cookie.Values.Count; i++)
            {
                string[] Box = ShoppingCart_cookie.Values[i].Split(',');
                if (Box[1] == "GB")
                {
                    DataTable Login1 = DbHelperSQL.Query("select * from t_GroupBuying Left Join t_GroupBuyingPicture On t_GroupBuying.GB_ID = t_GroupBuyingPicture.GB_ID Where t_GroupBuying.GB_ID =" + Box[0]).Tables[0];
                    sp.Append("<tr>");
                    sp.Append("<td><a href=\"Goods.aspx?GB_ID=" + Box[0] + "\">" + Login1.Rows[0]["GB_Name"].ToString() + "</a></td>");
                    sp.Append("<td style=\"text-align: center;height: 70px;\"><img style=\"max-width: 70px;max-height: 50px;\" src=\"" + Login1.Rows[0]["GBP_Url"].ToString() + "\" /></td>");
                    sp.Append("<td>" + float.Parse(Login1.Rows[0]["GB_GroupPrice"].ToString()).ToString("C") + "</td>");
                    sp.Append("<td><a class=\"btn btn-setting btn-default\" onclick=\"NumberEdit_Click('" + Box[0] + "','" + Box[1] + "','" + Login1.Rows[0]["GB_Name"].ToString() + "')\">" + Box[2] + " <i class=\"glyphicon glyphicon-edit icon-blue\"></i></a></td>");
                    float Price = float.Parse(Box[2].ToString()) * float.Parse(Login1.Rows[0]["GB_GroupPrice"].ToString());
                    sp.Append("<td runat=\"server\">" + Price.ToString("C") + "</td>");
                    sp.Append("<td>");
                    sp.Append("<a href=\"Orders.aspx?GB=" + ShoppingCart_cookie.Values.AllKeys[i].ToString() + "&Url=ShoppingCartGB.aspx\" class=\"btn btn-success\" style=\"margin-right: 10px;\"><i class=\"glyphicon glyphicon-check\"></i>开始预定</a>");
                    sp.Append("<a href=\"ShoppingCartDel.aspx?Del=" + ShoppingCart_cookie.Values.AllKeys[i].ToString() + "&Url=ShoppingCartGB.aspx\" class=\"btn btn-danger\"><i class=\"glyphicon glyphicon-trash icon-white\"></i>删除</a>");
                    sp.Append("</td>");
                    sp.Append("</tr>");
                    TotalPrice += 2;
                }
            }
            GB_Show_Box.InnerHtml = sp.ToString();
        }
        else
        {
            LinkButton2.Visible = false;
        }
    }

    public void ShoppingCart_Number()
    {

        if (Request.Cookies["ShoppingCart"] != null)
        {
            int ShoppingCart_Number = 0;

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
            HyperLink2.Text = "普通商品(" + ShoppingCart_Number + ")";
        }
        if (Request.Cookies["ShoppingCartB"] != null)
        {
            int ShoppingCart_Number = 0;

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
            HyperLink1.Text = "团购商品(" + ShoppingCart_Number + ")";

        }
    }

}