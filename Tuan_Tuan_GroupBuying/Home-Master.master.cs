using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Maticsoft.DBUtility;//Please add references

public partial class All : System.Web.UI.MasterPage
{
    TTGB.BLL.t_Users bllt_Users = new TTGB.BLL.t_Users();
    TTGB.BLL.t_GroupBuying bllGroupBuying = new TTGB.BLL.t_GroupBuying();
    protected void Page_Load(object sender, EventArgs e)
    {
        ///页面顶部判断是否登陆
        if (Request.Cookies["UserId"] != null && LoginStatus())
        {
            User_Box.Visible = true;
            User_Box_Null.Visible = false;
            User_Text.InnerText = HttpUtility.UrlDecode(Request.Cookies["UserName"].Value);
        }
        else
        {
            User_Box.Visible = false;
            User_Box_Null.Visible = true;
        }
        GroupBuyingDetection();

    }

    /// <summary>
    /// 检测用户状态
    /// </summary>
    public bool LoginStatus()
    {
        DataTable Login1 = bllt_Users.GetList("[U_ID]='" + Request.Cookies["UserId"].Value + "'").Tables[0];
        if (Login1.Rows.Count > 0)//是否有数据，有数据则成功否则为游客
            return true;
        else
            return false;
    }

    /// <summary>
    /// 注销
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void UserId_Close_Click(object sender, EventArgs e)
    {

        //删除Cookies
        HttpCookie myCookie = new HttpCookie("UserId");
        myCookie.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(myCookie);


        Response.Redirect("Home.aspx?Logoff=0");
    }


    protected void SearchButton_Click(object sender, EventArgs e)
    {
        string SearchText = Search_Text.Value;
        if (DropDownList1.Text == "0")
        {
            Response.Redirect("Search.aspx?&Ser=" + SearchText);
        }
        else
        {
            Response.Redirect("SearchGB.aspx?&Ser=" + SearchText);
        }
    }


    /// <summary>
    /// 活动商品页状态检测
    /// </summary>
    public void GroupBuyingDetection()
    {
        DataTable Login1 = bllGroupBuying.GetList("[GB_EndDate] < GetDate() and GB_State = 1").Tables[0];
        for (int i = 0; i < Login1.Rows.Count; i++)
        {
            string SQLtext = "UPDATE [t_GroupBuying] SET [GB_State] = 0 WHERE GB_ID = " + Login1.Rows[i]["GB_ID"].ToString();
            DbHelperSQL.Query(SQLtext);
            SQLtext = "UPDATE [t_Orders] SET [OS_ID] = 8 where O_ID = (select O_ID from [t_OrdersGoods] where GB_ID = " + Login1.Rows[i]["GB_ID"].ToString() + ")";
            DbHelperSQL.Query(SQLtext);
        }
    }
}
