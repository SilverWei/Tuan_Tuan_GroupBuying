using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;//Please add references


public partial class Management_OrdersInformation : System.Web.UI.Page
{
    TTGB.BLL.t_Orders bllt_Orders = new TTGB.BLL.t_Orders();
    TTGB.BLL.t_Users bllt_Users = new TTGB.BLL.t_Users();
    TTGB.BLL.t_OrdersShippingMethod bllt_OrdersShippingMethod = new TTGB.BLL.t_OrdersShippingMethod();
    TTGB.BLL.t_OrdersSort bllt_OrdersSort = new TTGB.BLL.t_OrdersSort();
    public string OS_CSS;
    public string Orders_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        OrdersInformationShow();
    }

    public void OrdersInformationShow()
    {
        DataTable Login1 = bllt_Orders.GetList("[O_ID]='" + Request.QueryString["O_ID"].ToString() + "'").Tables[0];
        O_ID.Text = Orders_ID = Login1.Rows[0]["O_ID"].ToString();
        DataTable Login2 = bllt_Users.GetList("[U_ID]='" + Login1.Rows[0]["U_ID"].ToString() + "'").Tables[0];
        if (Login1.Rows.Count != 0)
        {
            U_Name.Text = Login2.Rows[0]["U_Name"].ToString();
        }
        O_Date.Text = Login1.Rows[0]["O_buyDate"].ToString();
        O_Cnsignee.Text = Login1.Rows[0]["O_Cnsignee"].ToString();
        O_ZipCode.Text = Login1.Rows[0]["O_ZipCode"].ToString();
        O_Address.Text = Login1.Rows[0]["O_Address"].ToString();
        O_Phone.Text = Login1.Rows[0]["O_Phone"].ToString();
        DataTable Login3 = bllt_OrdersShippingMethod.GetList("OSM_ID='" + Login1.Rows[0]["OSM_ID"].ToString() + "'").Tables[0];
        OSM_ID.Text = Login3.Rows[0]["OSM_Name"].ToString();
        O_Message.Text = Login1.Rows[0]["O_Message"].ToString();

        //读取相关产品数据

        DataTable Login4;
        if (Login1.Rows[0]["O_GB_Y_N"].ToString() != "True")
        {
            Login4 = DbHelperSQL.Query("Select [O_ID],sum(OG_TotalPrice)as OG_TotalPrice From [t_OrdersGoods] Where O_ID = " + Login1.Rows[0]["O_ID"].ToString() + " group by [O_ID] ;").Tables[0];
            SqlDataSource3.SelectCommand = "Select *,t_Goods.G_ID as ID,t_Goods.G_Name as Name,t_Goods.G_UserPrice as Price,0 as [O_GB_Y_N] From t_OrdersGoods Left Join t_Goods on t_Goods.G_ID = t_OrdersGoods.G_ID Where O_ID = " + Login1.Rows[0]["O_ID"].ToString();
        }
        else
        {
            Login4 = DbHelperSQL.Query("Select [O_ID],sum(OG_TotalPrice)as OG_TotalPrice From [t_OrdersGoods] Where O_ID = " + Login1.Rows[0]["O_ID"].ToString() + " group by [O_ID] ;").Tables[0];
        SqlDataSource3.SelectCommand = "Select *,t_GroupBuying.[GB_ID] as ID,t_GroupBuying.GB_Name as Name,t_GroupBuying.GB_GroupPrice as Price,1 as [O_GB_Y_N] From t_OrdersGoods Left Join t_GroupBuying on t_GroupBuying.GB_ID = t_OrdersGoods.GB_ID Where O_ID = " + Login1.Rows[0]["O_ID"].ToString();
        }
        if (Login4.Rows[0]["OG_TotalPrice"].ToString() != "")
        {
            TotalPriceShow.Text = float.Parse(Login4.Rows[0]["OG_TotalPrice"].ToString()).ToString("C");

        }
        DataTable Login5 = bllt_OrdersSort.GetList("OS_ID = " + Login1.Rows[0]["OS_ID"].ToString()).Tables[0];
        OS_Text.Text = Login5.Rows[0]["OS_Name"].ToString();
        OS_CSS = Login5.Rows[0]["OS_ID"].ToString();
    }

    protected void EditOrderButton_Click(object sender, EventArgs e)
    {
        string SQLtext = "UPDATE [t_Orders] SET OS_ID = " + RadioButtonList1.SelectedValue + " WHERE O_ID = " + Request.Cookies["EditOrderID"].Value;
        DbHelperSQL.Query(SQLtext);
        Response.Redirect(Request.Url.ToString());

    }

}