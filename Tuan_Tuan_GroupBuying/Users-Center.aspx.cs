using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;//Please add references

public partial class Users_Center : System.Web.UI.Page
{
    TTGB.BLL.t_Users bllUsers = new TTGB.BLL.t_Users();
    TTGB.Model.t_Users ModUsers = new TTGB.Model.t_Users();
    TTGB.BLL.t_Orders bllt_Orders = new TTGB.BLL.t_Orders();
    TTGB.Model.t_Orders Modt_Orders = new TTGB.Model.t_Orders();
    TTGB.BLL.t_OrdersGoods bllt_OrdersGoods = new TTGB.BLL.t_OrdersGoods();

    protected void Page_Load(object sender, EventArgs e)
    {
        //判断用户是否已登陆，如果没登陆跳转登陆页面
        if (Request.Cookies["UserId"] == null)
        {
            Response.Redirect("Landed.aspx");
        }
        UserCenter();
        UsersCenter_Number();


        string SelText = " Select nullif(isnull(A.OG_TotalPrice,0)+isnull(B.OG_TotalPrice,0),0) as [O_TotalPrice],* From (Select [O_ID],sum(OG_TotalPrice)as OG_TotalPrice From [t_OrdersGoods] group by [O_ID]) as A Left join t_Orders on t_Orders.O_ID=A.O_ID Left join (Select [O_ID],sum(OG_Quantity*GB_GroupPrice)as OG_TotalPrice From [t_OrdersGoods] Left join t_GroupBuying on t_GroupBuying.GB_ID=t_OrdersGoods.GB_ID group by [O_ID]) as B on B.O_ID = t_Orders.O_ID Left join t_OrdersShippingMethod on t_OrdersShippingMethod.OSM_ID = t_Orders.OSM_ID  Left join t_Users on t_Users.U_ID = t_Orders.U_ID  Left join t_OrdersSort on t_OrdersSort.OS_ID = t_Orders.OS_ID  Where t_Orders.OS_ID >5 and O_GB_Y_N = 0 and t_Users.U_ID = " + Request.Cookies["UserId"].Value + " order by t_Orders.O_ID desc";
        SqlDataSource4.SelectCommand = SelText;

    }

    /// <summary>
    /// 显示个人信息
    /// </summary>
    public void UserCenter()
    {
        DataTable UserSelect = bllUsers.GetList("U_ID='" + Request.Cookies["UserId"].Value + "'").Tables[0];
        U_Name.InnerText = UserSelect.Rows[0]["U_Name"].ToString();
        U_RealName.InnerText = UserSelect.Rows[0]["U_RealName"].ToString();
        U_Sex.InnerText = UserSelect.Rows[0]["U_Sex"].ToString() == "False"?"男":"女";
        if (UserSelect.Rows[0]["U_Birthday"].ToString() != "")
        {
            U_Birthday.InnerText = Convert.ToDateTime(UserSelect.Rows[0]["U_Birthday"]).ToString("yyyy年MM月dd日");
        }
        U_Phone.InnerText = UserSelect.Rows[0]["U_Phone"].ToString();
        U_Email.InnerText = UserSelect.Rows[0]["U_Email"].ToString();
        U_SignUP.InnerText = Convert.ToDateTime(UserSelect.Rows[0]["U_SignUP"]).ToString("yyyy年MM月dd日");
//         U_Rank.InnerText = UserSelect.Rows[0]["U_Rank"].ToString();
//         U_Points.InnerText = UserSelect.Rows[0]["U_Points"].ToString();

    }

    //protected void EditOrderButton_Click(object sender, EventArgs e)
    //{
    //    string SQLtext = "UPDATE [t_Orders] SET OS_ID = " + RadioButtonList1.SelectedValue + " WHERE O_ID = " + Request.Cookies["EditOrderID"].Value;
    //    DbHelperSQL.Query(SQLtext);
    //    Response.Redirect(Request.Url.ToString());

    //}


    //protected void LinkButton2_Click(object sender, EventArgs e)
    //{
    //    if (Request.Cookies["UsersCenter"] != null)
    //    {
    //        HttpCookie UsersCenter_cookie = Request.Cookies["UsersCenter"];
    //        UsersCenter_cookie.Expires = DateTime.Now.AddDays(-1);
    //        Response.Cookies.Add(UsersCenter_cookie);
    //    }
    //    Response.Redirect(Request.Url.ToString());
    //}


    public void UsersCenter_Number()
    {

        if (Request.Cookies["UsersCenter"] != null)
        {
            int UsersCenter_Number = 0;

            HttpCookie UsersCenter_cookie = Request.Cookies["UsersCenter"];
            for (int i = 0; i < UsersCenter_cookie.Values.Count; i++)
            {
                //cookies第一条
                //ShoppingCart_cookie.Values.AllKeys[i];

                ////cookies第二条
                //string[] shops = ShoppingCart_cookie.Values[i].Split(',');
                //shops[1]；

                UsersCenter_Number += 1;
            }
            HyperLink2.Text = "普通商品(" + UsersCenter_Number + ")";
        }
        if (Request.Cookies["UsersCenterB"] != null)
        {
            int UsersCenter_Number = 0;

            HttpCookie UsersCenter_cookie = Request.Cookies["UsersCenterB"];
            for (int i = 0; i < UsersCenter_cookie.Values.Count; i++)
            {
                //cookies第一条
                //ShoppingCart_cookie.Values.AllKeys[i];

                ////cookies第二条
                //string[] shops = ShoppingCart_cookie.Values[i].Split(',');
                //shops[1]；

                UsersCenter_Number += 1;
            }
            HyperLink1.Text = "团购商品(" + UsersCenter_Number + ")";

        }
    }

}