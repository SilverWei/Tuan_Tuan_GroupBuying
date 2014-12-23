using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Maticsoft.DBUtility;//Please add references

public partial class OrdersSort : System.Web.UI.Page
{
    TTGB.BLL.t_Orders bllt_Orders = new TTGB.BLL.t_Orders();
    TTGB.Model.t_Orders Modt_Orders = new TTGB.Model.t_Orders();
    TTGB.BLL.t_OrdersGoods bllt_OrdersGoods = new TTGB.BLL.t_OrdersGoods();

    public string OG_TotalPrice="";
    protected void Page_Load(object sender, EventArgs e)
    {
      
        //判断用户是否已登陆，如果没登陆跳转登陆页面
        if (Request.Cookies["UserId"] == null)
        {
            Response.Redirect("Landed.aspx");
        }


        if (Request.QueryString["NewOrders"] != null)
        {
            Response.Write("<script>alert(\"订单生成成功!\");window.location.href=\"OrdersSort.aspx\"</script>");
        }

        string SelText = " Select nullif(isnull(A.OG_TotalPrice,0)+isnull(B.OG_TotalPrice,0),0) as [O_TotalPrice],* From (Select [O_ID],sum(OG_TotalPrice)as OG_TotalPrice From [t_OrdersGoods] group by [O_ID]) as A Left join t_Orders on t_Orders.O_ID=A.O_ID Left join (Select [O_ID],sum(OG_Quantity*GB_GroupPrice)as OG_TotalPrice From [t_OrdersGoods] Left join t_GroupBuying on t_GroupBuying.GB_ID=t_OrdersGoods.GB_ID group by [O_ID]) as B on B.O_ID = t_Orders.O_ID Left join t_OrdersShippingMethod on t_OrdersShippingMethod.OSM_ID = t_Orders.OSM_ID  Left join t_Users on t_Users.U_ID = t_Orders.U_ID  Left join t_OrdersSort on t_OrdersSort.OS_ID = t_Orders.OS_ID  Where t_Orders.OS_ID <=5 and O_GB_Y_N = 0 and t_Users.U_ID = " + Request.Cookies["UserId"].Value + " order by t_Orders.O_ID desc";
        SqlDataSource4.SelectCommand = SelText;

        count();
        //string count = "Select sum(OG_TotalPrice) as [counts] from [dbo].[t_OrdersGoods] Left join [dbo].[t_Orders] on ([dbo].[t_OrdersGoods].O_ID =[dbo].[t_Orders].O_ID and U_ID =1000 )where OS_ID <6";
        //SqlDataSource2.SelectCommand = count;
        
    }


    public void count()
    {
        DataTable Login1 = DbHelperSQL.Query("Select sum(OG_TotalPrice) as [counts] from [dbo].[t_OrdersGoods] Left join [dbo].[t_Orders] on ([dbo].[t_OrdersGoods].O_ID =[dbo].[t_Orders].O_ID )where (OS_ID <6 and OS_ID!=3 ) and  G_ID is not null").Tables[0];
        OG_TotalPrice = Login1.Rows[0]["counts"].ToString ();
    }






    protected void EditOrderButton_Click(object sender, EventArgs e)
    {
        string SQLtext = "UPDATE [t_Orders] SET OS_ID = " + RadioButtonList1.SelectedValue + " WHERE O_ID = " + Request.Cookies["EditOrderID"].Value;
        DbHelperSQL.Query(SQLtext);
        Response.Redirect(Request.Url.ToString());

    }




    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["OrdersSort"] != null)
        {
            HttpCookie OrdersSort_cookie = Request.Cookies["OrdersSort"];
            OrdersSort_cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(OrdersSort_cookie);
        }
        Response.Redirect(Request.Url.ToString());
    }


    public void OrdersSort_Number()
    {

        if (Request.Cookies["OrdersSort"] != null)
        {
            int OrdersSort_Number = 0;

            HttpCookie OrdersSort_cookie = Request.Cookies["OrdersSort"];
            for (int i = 0; i < OrdersSort_cookie.Values.Count; i++)
            {
                //cookies第一条
                //ShoppingCart_cookie.Values.AllKeys[i];

                ////cookies第二条
                //string[] shops = ShoppingCart_cookie.Values[i].Split(',');
                //shops[1]；

                OrdersSort_Number += 1;
            }
            HyperLink2.Text = "普通商品(" + OrdersSort_Number + ")";
        }
        if (Request.Cookies["OrdersSortB"] != null)
        {
            int OrdersSort_Number = 0;

            HttpCookie OrdersSort_cookie = Request.Cookies["OrdersSortB"];
            for (int i = 0; i < OrdersSort_cookie.Values.Count; i++)
            {
                //cookies第一条
                //ShoppingCart_cookie.Values.AllKeys[i];

                ////cookies第二条
                //string[] shops = ShoppingCart_cookie.Values[i].Split(',');
                //shops[1]；

                OrdersSort_Number += 1;
            }
            HyperLink1.Text = "团购商品(" + OrdersSort_Number + ")";

        }
    }
 
}